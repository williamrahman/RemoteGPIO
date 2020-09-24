using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiringPi;

namespace RemoteServer
{
    public partial class Form2 : Form
    {
        //initiate GPIO
        const int livRoomLamp = 3;
        const int bedRoomLamp = 5;
        const int bathRoomLamp = 7;
        const int deskRoomLamp = 11;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*if (Init.WiringPiSetupPhys() >= 0)
            {
                //livRoomLamp
                GPIO.pinMode(livRoomLamp, (int)GPIO.GPIOpinmode.Output);
                GPIO.digitalWrite(livRoomLamp, (int)GPIO.GPIOpinvalue.High);

                //bedRoomLamp
                GPIO.pinMode(bedRoomLamp, (int)GPIO.GPIOpinmode.Output);
                GPIO.digitalWrite(bedRoomLamp, (int)GPIO.GPIOpinvalue.High);

                //bathRoomLamp
                GPIO.pinMode(bathRoomLamp, (int)GPIO.GPIOpinmode.Output);
                GPIO.digitalWrite(bathRoomLamp, (int)GPIO.GPIOpinvalue.High);

                //deskRoomLamp
                GPIO.pinMode(deskRoomLamp, (int)GPIO.GPIOpinmode.Output);
                GPIO.digitalWrite(deskRoomLamp, (int)GPIO.GPIOpinvalue.High);

                Console.WriteLine("GPIO Initialization Complete");
            }
            else
            {
                Console.WriteLine("GPIO Initialization Failed!");
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = true;
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                GPIO.digitalWrite(livRoomLamp, (int)GPIO.GPIOpinvalue.Low);
            }
            else
            {
                GPIO.digitalWrite(livRoomLamp, (int)GPIO.GPIOpinvalue.High);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                GPIO.digitalWrite(bedRoomLamp, (int)GPIO.GPIOpinvalue.Low);
            }
            else
            {
                GPIO.digitalWrite(bedRoomLamp, (int)GPIO.GPIOpinvalue.High);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                GPIO.digitalWrite(bathRoomLamp, (int)GPIO.GPIOpinvalue.Low);
            }
            else
            {
                GPIO.digitalWrite(bathRoomLamp, (int)GPIO.GPIOpinvalue.High);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                GPIO.digitalWrite(deskRoomLamp, (int)GPIO.GPIOpinvalue.Low);
            }
            else
            {
                GPIO.digitalWrite(deskRoomLamp, (int)GPIO.GPIOpinvalue.High);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
