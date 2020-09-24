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

namespace RemoteClient
{
    public partial class Form2 : Form
    {

        private Stream stream;
        private StreamWriter eventSender;
        private Thread theThread;
        private TcpClient client;
        private Form1 mForm;
        private int resolutionX;
        private int resolutionY;
        public bool sendKeysAndMouse = false;

        public Form2(TcpClient s, Form1 callingForm)
        {
            client = s;
            mForm = callingForm;
            InitializeComponent();
            theThread = new Thread(new ThreadStart(startRead));
            theThread.Start();
        }

        public void sendBeep(int x)
        {
            eventSender.Write("BEEP\n");
            eventSender.Flush();
        }


        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (theThread.IsAlive)
                theThread.Abort();
            mForm.form2Closed();
        }
        private void startRead()
        {
            try
            {
                stream = client.GetStream();
                eventSender = new StreamWriter(stream);
                while (true)
                {

                    BinaryFormatter bFormat = new BinaryFormatter();
                    Bitmap inImage = bFormat.Deserialize(stream) as Bitmap;
                    resolutionX = inImage.Width;
                    resolutionY = inImage.Height;
                    theImage.Image = (Image)inImage;
                }
            }
            catch (Exception)
            {

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (!sendKeysAndMouse)
                return;
            try
            {
                String keysToSend = "";
                if (e.Shift)
                    keysToSend += "+";
                if (e.Alt)
                    keysToSend += "%";
                if (e.Control)
                    keysToSend += "^";

                if (e.KeyValue >= 65 && e.KeyValue <= 90)
                    keysToSend += e.KeyCode.ToString().ToLower();
                else if (e.KeyCode.ToString().Equals("Back"))
                    keysToSend += "{BS}";
                else if (e.KeyCode.ToString().Equals("Pause"))
                    keysToSend += "{BREAK}";
                else if (e.KeyCode.ToString().Equals("Capital"))
                    keysToSend += "{CAPSLOCK}";
                else if (e.KeyCode.ToString().Equals("Space"))
                    keysToSend += " ";
                else if (e.KeyCode.ToString().Equals("Home"))
                    keysToSend += "{HOME}";
                else if (e.KeyCode.ToString().Equals("Return"))
                    keysToSend += "{ENTER}";
                else if (e.KeyCode.ToString().Equals("End"))
                    keysToSend += "{END}";
                else if (e.KeyCode.ToString().Equals("Tab"))
                    keysToSend += "{TAB}";
                else if (e.KeyCode.ToString().Equals("Escape"))
                    keysToSend += "{ESC}";
                else if (e.KeyCode.ToString().Equals("Insert"))
                    keysToSend += "{INS}";
                else if (e.KeyCode.ToString().Equals("Up"))
                    keysToSend += "{UP}";
                else if (e.KeyCode.ToString().Equals("Down"))
                    keysToSend += "{DOWN}";
                else if (e.KeyCode.ToString().Equals("Left"))
                    keysToSend += "{LEFT}";
                else if (e.KeyCode.ToString().Equals("Right"))
                    keysToSend += "{RIGHT}";
                else if (e.KeyCode.ToString().Equals("PageUp"))
                    keysToSend += "{PGUP}";
                else if (e.KeyCode.ToString().Equals("Next"))
                    keysToSend += "{PGDN}";
                else if (e.KeyCode.ToString().Equals("Tab"))
                    keysToSend += "{TAB}";
                else if (e.KeyCode.ToString().Equals("D1"))
                    keysToSend += "1";
                else if (e.KeyCode.ToString().Equals("D2"))
                    keysToSend += "2";
                else if (e.KeyCode.ToString().Equals("D3"))
                    keysToSend += "3";
                else if (e.KeyCode.ToString().Equals("D4"))
                    keysToSend += "4";
                else if (e.KeyCode.ToString().Equals("D5"))
                    keysToSend += "5";
                else if (e.KeyCode.ToString().Equals("D6"))
                    keysToSend += "6";
                else if (e.KeyCode.ToString().Equals("D7"))
                    keysToSend += "7";
                else if (e.KeyCode.ToString().Equals("D8"))
                    keysToSend += "8";
                else if (e.KeyCode.ToString().Equals("D9"))
                    keysToSend += "9";
                else if (e.KeyCode.ToString().Equals("D0"))
                    keysToSend += "0";
                else if (e.KeyCode.ToString().Equals("F1"))
                    keysToSend += "{F1}";
                else if (e.KeyCode.ToString().Equals("F2"))
                    keysToSend += "{F2}";
                else if (e.KeyCode.ToString().Equals("F3"))
                    keysToSend += "{F3}";
                else if (e.KeyCode.ToString().Equals("F4"))
                    keysToSend += "{F4}";
                else if (e.KeyCode.ToString().Equals("F5"))
                    keysToSend += "{F5}";
                else if (e.KeyCode.ToString().Equals("F6"))
                    keysToSend += "{F6}";
                else if (e.KeyCode.ToString().Equals("F7"))
                    keysToSend += "{F7}";
                else if (e.KeyCode.ToString().Equals("F8"))
                    keysToSend += "{F8}";
                else if (e.KeyCode.ToString().Equals("F9"))
                    keysToSend += "{F9}";
                else if (e.KeyCode.ToString().Equals("F10"))
                    keysToSend += "{F10}";
                else if (e.KeyCode.ToString().Equals("F11"))
                    keysToSend += "{F11}";
                else if (e.KeyCode.ToString().Equals("F12"))
                    keysToSend += "{F12}";
                else if (e.KeyValue == 186)
                    keysToSend += "{;}";
                else if (e.KeyValue == 222)
                    keysToSend += "'";
                else if (e.KeyValue == 191)
                    keysToSend += "/";
                else if (e.KeyValue == 190)
                    keysToSend += ".";
                else if (e.KeyValue == 188)
                    keysToSend += ",";
                else if (e.KeyValue == 219)
                    keysToSend += "{[}";
                else if (e.KeyValue == 221)
                    keysToSend += "{]}";
                else if (e.KeyValue == 220)
                    keysToSend += "\\";
                else if (e.KeyValue == 187)
                    keysToSend += "{=}";
                else if (e.KeyValue == 189)
                    keysToSend += "{-}";

                e.SuppressKeyPress = true;
                eventSender.Write(keysToSend + "\n");
                eventSender.Flush();
            }
            catch (Exception)
            {

            }
        }

        private void theImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!sendKeysAndMouse)
                return;
            try
            {
                float correctX = (float)resolutionX * ((float)e.Location.X / theImage.Width);
                float correctY = (float)resolutionY * ((float)e.Location.Y / theImage.Height);
                correctX = ((int)correctX);
                correctY = ((int)correctY);
                eventSender.Write("M" + correctX + " " + correctY + "\n");
                eventSender.Flush();
            }
            catch (Exception) { }
        }

        private void theImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (!sendKeysAndMouse)
                return;
            eventSender.Write("LMB\n");
            eventSender.Flush();
        }

        private void theImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (!sendKeysAndMouse)
                return;
            eventSender.Write("LDOWN\n");
            eventSender.Flush();
        }

        private void theImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (!sendKeysAndMouse)
                return;
            eventSender.Write("LUP\n");
            eventSender.Flush();
        }
    }
}
