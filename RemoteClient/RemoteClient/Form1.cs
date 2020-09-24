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


namespace RemoteClient
{
    public partial class Form1 : Form
    {
        private Form2 client;
        private TcpClient connector;

        public Form1()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            startConnect();
        }

        private void startConnect()
        {
            try
            {
                connector = new TcpClient(ipAddress.Text.ToString(), 6010);
                mouseAndKeyboard.Enabled = true;
                mouseAndKeyboard.Show();
                client = new Form2(connector, this);
                client.Show();
                disconnectButton.Enabled = true;
                mouseAndKeyboard.Enabled = true;
                beep.Enabled = true;
                connectButton.Enabled = false;
            }
            catch (Exception problem)
            {
                MessageBox.Show("Invalid IPAddress, Invalid Port or Failed Internet Connection" + problem.ToString());

            }
        }

        public void form2Closed()
        {
            if (client.Visible)
                client.Dispose();
            connector.Close();

        }

        private void mouseAndKeyboard_Click_1(object sender, EventArgs e)
        {
            if (!client.sendKeysAndMouse)
            {
                client.sendKeysAndMouse = true;
            }
            else
            {
                client.sendKeysAndMouse = false;
            }
        }

        private void beep_Click_1(object sender, EventArgs e)
        {
            client.sendBeep(4);
        }

        private void disconnectButton_Click_1(object sender, EventArgs e)
        {
            if (client.Visible)
            {
                client.Dispose();
            }
            connector.Close();
            disconnectButton.Enabled = false;
            mouseAndKeyboard.Enabled = false;
            beep.Enabled = false;
            connectButton.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void ipAddress_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
