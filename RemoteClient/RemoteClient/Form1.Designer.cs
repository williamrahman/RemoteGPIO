namespace RemoteClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.mouseAndKeyboard = new System.Windows.Forms.Button();
            this.beep = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipAddress
            // 
            this.ipAddress.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddress.ForeColor = System.Drawing.Color.Black;
            this.ipAddress.Location = new System.Drawing.Point(86, 12);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(108, 20);
            this.ipAddress.TabIndex = 3;
            this.ipAddress.TextChanged += new System.EventHandler(this.ipAddress_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(200, 10);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(61, 23);
            this.connectButton.TabIndex = 5;
            this.connectButton.Text = "Start";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(267, 10);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(65, 23);
            this.disconnectButton.TabIndex = 6;
            this.disconnectButton.Text = "Stop Remote";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click_1);
            // 
            // mouseAndKeyboard
            // 
            this.mouseAndKeyboard.Enabled = false;
            this.mouseAndKeyboard.ForeColor = System.Drawing.Color.Black;
            this.mouseAndKeyboard.Location = new System.Drawing.Point(12, 38);
            this.mouseAndKeyboard.Name = "mouseAndKeyboard";
            this.mouseAndKeyboard.Size = new System.Drawing.Size(173, 64);
            this.mouseAndKeyboard.TabIndex = 11;
            this.mouseAndKeyboard.TabStop = false;
            this.mouseAndKeyboard.Text = "Using Mouse dan Keyboard";
            this.mouseAndKeyboard.UseVisualStyleBackColor = true;
            this.mouseAndKeyboard.Click += new System.EventHandler(this.mouseAndKeyboard_Click_1);
            // 
            // beep
            // 
            this.beep.Enabled = false;
            this.beep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beep.Location = new System.Drawing.Point(191, 38);
            this.beep.Name = "beep";
            this.beep.Size = new System.Drawing.Size(141, 31);
            this.beep.TabIndex = 18;
            this.beep.TabStop = false;
            this.beep.Text = "Check Sound";
            this.beep.UseVisualStyleBackColor = true;
            this.beep.Click += new System.EventHandler(this.beep_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 33);
            this.button1.TabIndex = 19;
            this.button1.Text = "About Apps";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "© Copyright 2018, William Rahman - Unpad";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 133);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.beep);
            this.Controls.Add(this.mouseAndKeyboard);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipAddress);
            this.Name = "Form1";
            this.Text = "Controller (Remote Client)";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button mouseAndKeyboard;
        private System.Windows.Forms.Button beep;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}

