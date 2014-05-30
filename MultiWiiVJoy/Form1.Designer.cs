namespace MultiWiiVJoy
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbxPortNames = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.timerRc = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelVJoy = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxThrottle = new System.Windows.Forms.CheckBox();
            this.cbxYaw = new System.Windows.Forms.CheckBox();
            this.cbxPitch = new System.Windows.Forms.CheckBox();
            this.cbxRoll = new System.Windows.Forms.CheckBox();
            this.displayRcValueRoll = new MultiWiiVJoy.DisplayRcValue();
            this.displayRcValuePitch = new MultiWiiVJoy.DisplayRcValue();
            this.displayRcValueYaw = new MultiWiiVJoy.DisplayRcValue();
            this.displayRcValueThrottle = new MultiWiiVJoy.DisplayRcValue();
            this.cbxInterval = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbxPortNames
            // 
            this.cbxPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPortNames.FormattingEnabled = true;
            this.cbxPortNames.Location = new System.Drawing.Point(108, 11);
            this.cbxPortNames.Name = "cbxPortNames";
            this.cbxPortNames.Size = new System.Drawing.Size(121, 24);
            this.cbxPortNames.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(235, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 24);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "57600",
            "115200"});
            this.cbxBaudRate.Location = new System.Drawing.Point(316, 11);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(121, 24);
            this.cbxBaudRate.TabIndex = 4;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(12, 11);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(90, 24);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Visible = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // timerRc
            // 
            this.timerRc.Interval = 200;
            this.timerRc.Tick += new System.EventHandler(this.timerRc_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Throttle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Yaw";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Pitch";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Roll";
            // 
            // panelVJoy
            // 
            this.panelVJoy.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelVJoy.Location = new System.Drawing.Point(108, 50);
            this.panelVJoy.Name = "panelVJoy";
            this.panelVJoy.Size = new System.Drawing.Size(20, 20);
            this.panelVJoy.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "vJoy Ready";
            // 
            // cbxThrottle
            // 
            this.cbxThrottle.AutoSize = true;
            this.cbxThrottle.Checked = true;
            this.cbxThrottle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxThrottle.Location = new System.Drawing.Point(316, 86);
            this.cbxThrottle.Name = "cbxThrottle";
            this.cbxThrottle.Size = new System.Drawing.Size(83, 21);
            this.cbxThrottle.TabIndex = 21;
            this.cbxThrottle.Text = "Reverse";
            this.cbxThrottle.UseVisualStyleBackColor = true;
            // 
            // cbxYaw
            // 
            this.cbxYaw.AutoSize = true;
            this.cbxYaw.Location = new System.Drawing.Point(316, 112);
            this.cbxYaw.Name = "cbxYaw";
            this.cbxYaw.Size = new System.Drawing.Size(83, 21);
            this.cbxYaw.TabIndex = 22;
            this.cbxYaw.Text = "Reverse";
            this.cbxYaw.UseVisualStyleBackColor = true;
            // 
            // cbxPitch
            // 
            this.cbxPitch.AutoSize = true;
            this.cbxPitch.Checked = true;
            this.cbxPitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPitch.Location = new System.Drawing.Point(316, 138);
            this.cbxPitch.Name = "cbxPitch";
            this.cbxPitch.Size = new System.Drawing.Size(83, 21);
            this.cbxPitch.TabIndex = 23;
            this.cbxPitch.Text = "Reverse";
            this.cbxPitch.UseVisualStyleBackColor = true;
            // 
            // cbxRoll
            // 
            this.cbxRoll.AutoSize = true;
            this.cbxRoll.Location = new System.Drawing.Point(316, 164);
            this.cbxRoll.Name = "cbxRoll";
            this.cbxRoll.Size = new System.Drawing.Size(83, 21);
            this.cbxRoll.TabIndex = 24;
            this.cbxRoll.Text = "Reverse";
            this.cbxRoll.UseVisualStyleBackColor = true;
            // 
            // displayRcValueRoll
            // 
            this.displayRcValueRoll.BackColor = System.Drawing.SystemColors.ControlDark;
            this.displayRcValueRoll.Location = new System.Drawing.Point(108, 165);
            this.displayRcValueRoll.Name = "displayRcValueRoll";
            this.displayRcValueRoll.Size = new System.Drawing.Size(202, 20);
            this.displayRcValueRoll.TabIndex = 14;
            this.displayRcValueRoll.Value = 0;
            // 
            // displayRcValuePitch
            // 
            this.displayRcValuePitch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.displayRcValuePitch.Location = new System.Drawing.Point(108, 139);
            this.displayRcValuePitch.Name = "displayRcValuePitch";
            this.displayRcValuePitch.Size = new System.Drawing.Size(202, 20);
            this.displayRcValuePitch.TabIndex = 13;
            this.displayRcValuePitch.Value = 0;
            // 
            // displayRcValueYaw
            // 
            this.displayRcValueYaw.BackColor = System.Drawing.SystemColors.ControlDark;
            this.displayRcValueYaw.Location = new System.Drawing.Point(108, 113);
            this.displayRcValueYaw.Name = "displayRcValueYaw";
            this.displayRcValueYaw.Size = new System.Drawing.Size(202, 20);
            this.displayRcValueYaw.TabIndex = 12;
            this.displayRcValueYaw.Value = 0;
            // 
            // displayRcValueThrottle
            // 
            this.displayRcValueThrottle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.displayRcValueThrottle.Location = new System.Drawing.Point(108, 87);
            this.displayRcValueThrottle.Name = "displayRcValueThrottle";
            this.displayRcValueThrottle.Size = new System.Drawing.Size(202, 20);
            this.displayRcValueThrottle.TabIndex = 11;
            this.displayRcValueThrottle.Value = 0;
            // 
            // cbxInterval
            // 
            this.cbxInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInterval.FormattingEnabled = true;
            this.cbxInterval.Items.AddRange(new object[] {
            "100",
            "200",
            "500"});
            this.cbxInterval.Location = new System.Drawing.Point(316, 46);
            this.cbxInterval.Name = "cbxInterval";
            this.cbxInterval.Size = new System.Drawing.Size(121, 24);
            this.cbxInterval.TabIndex = 25;
            this.cbxInterval.SelectedIndexChanged += new System.EventHandler(this.cbxInterval_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Interval (ms)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(9, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "bitWorking 2014";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 231);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxInterval);
            this.Controls.Add(this.cbxRoll);
            this.Controls.Add(this.cbxPitch);
            this.Controls.Add(this.cbxYaw);
            this.Controls.Add(this.cbxThrottle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelVJoy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayRcValueRoll);
            this.Controls.Add(this.displayRcValuePitch);
            this.Controls.Add(this.displayRcValueYaw);
            this.Controls.Add(this.displayRcValueThrottle);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.cbxBaudRate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbxPortNames);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MultiWii vJoy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbxPortNames;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Timer timerRc;
        private DisplayRcValue displayRcValueThrottle;
        private DisplayRcValue displayRcValueYaw;
        private DisplayRcValue displayRcValuePitch;
        private DisplayRcValue displayRcValueRoll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelVJoy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxThrottle;
        private System.Windows.Forms.CheckBox cbxYaw;
        private System.Windows.Forms.CheckBox cbxPitch;
        private System.Windows.Forms.CheckBox cbxRoll;
        private System.Windows.Forms.ComboBox cbxInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

