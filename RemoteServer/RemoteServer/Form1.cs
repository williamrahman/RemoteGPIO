using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Threading;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;
using System.Diagnostics;

namespace RemoteServer
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        private const int MOUSE_LEFTDOWN = 0x0002;
        private const int MOUSE_LEFTUP = 0x0004;
        private const int MOUSE_RIGTDOWN = 0x0008;
        private const int MOUSE_RIGHTUP = 0x0010;

        private TcpListener listener;
        private Socket mainSocket;
        private int port;
        private Stream s;
        private Thread eventWatcher;
        private int imageDelay;


        public Form1()
        {
            InitializeComponent();
            port = 1338;
            imageDelay = 0;
        }
        public Form1(int p)
        {
            port = p;
            imageDelay = 1000;
            InitializeComponent();
        }
        
        public void startListening()
        {
            try
            {
                listener = new TcpListener(port);
                listener.Start();
                mainSocket = listener.AcceptSocket();
                s = new NetworkStream(mainSocket);
                eventWatcher = new Thread(new ThreadStart(waitForKeys));
                eventWatcher.Start();
                while (true)
                {
                    Rectangle bounds = Screen.PrimaryScreen.Bounds;
                    Bitmap screeny = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
                    Graphics theShot = Graphics.FromImage(screeny);
                    theShot.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(s, screeny);
                    Thread.Sleep(imageDelay);
                    theShot.Dispose();
                    screeny.Dispose();
                }
            }
            catch (Exception)
            {
                if (mainSocket.IsBound)
                    mainSocket.Close();
                if (listener != null)
                    listener.Stop();
            }
        }

        private void waitForKeys()
        {
            try
            {
                String temp = "";
                StreamReader reader = new StreamReader(s);
                do
                {
                    temp = reader.ReadLine();
                    if (temp.StartsWith("CDELAY"))
                    {
                        imageDelay = int.Parse(temp.Substring(6, temp.Length - 6));
                    }
                    else if (temp.StartsWith("LMB"))
                    {
                        mouse_event(MOUSE_LEFTDOWN | MOUSE_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    }
                    else if (temp.StartsWith("BEEP"))
                    {
                        SystemSounds.Hand.Play();
                    }
                    else if (temp.StartsWith("SHUTDOWN"))
                    {
                        mainSocket.Close();
                        listener.Stop();
                        Environment.Exit(0);
                    }
                    else if (temp.StartsWith("LDOWN"))
                    {
                        mouse_event(MOUSE_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    }
                    else if (temp.StartsWith("LUP"))
                    {
                        mouse_event(MOUSE_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    }
                    else if (temp.StartsWith("M"))
                    {
                        int xPos = 0, yPos = 0;
                        try
                        {
                            xPos = int.Parse(temp.Substring(1, temp.IndexOf(' ')));
                            yPos = int.Parse(temp.Substring(temp.IndexOf(' '), temp.Length - temp.IndexOf(' ')));
                            Cursor.Position = new Point(xPos, yPos);

                            continue;
                        }
                        catch (Exception) { }
                    }
                    else
                    {
                        SendKeys.SendWait(temp);
                    }
                }
                while (temp != null);
            }
            catch (Exception) { }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            port = 6010;
            startListening();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}