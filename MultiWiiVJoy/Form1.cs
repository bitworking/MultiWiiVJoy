using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using vJoyInterfaceWrap;

namespace MultiWiiVJoy
{
    public partial class Form1 : Form
    {

        private Serial serial = new Serial();
        private VirtualJoystick vJoy = new VirtualJoystick();

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serial.Connected += new Serial.ConnectedHandler(serial_Connected);
            serial.Disconnected += new Serial.DisconnectedHandler(serial_Disconnected);
            serial.DataReceived += new Serial.DataReceivedHandler(serial_DataReceived);
            serial.Error += new Serial.ErrorHandler(serial_Error);

            vJoy.Success += new VirtualJoystick.SuccessHandler(vJoy_Success);
            vJoy.Error += new VirtualJoystick.ErrorHandler(vJoy_Error);

            serial.Init();
            vJoy.Init();

            fillCbxPortNames();
            if (cbxPortNames.Items.Count > 0) {
                cbxPortNames.SelectedIndex = 0;
            }

            cbxBaudRate.SelectedIndex = 3;            
            cbxInterval.SelectedIndex = 0;
        }

        void vJoy_Error(object sender, ErrorArgs e)
        {
            panelVJoy.BackColor = Color.OrangeRed;
            MessageBox.Show(e.Error);
        }

        void vJoy_Success(object sender)
        {
            panelVJoy.BackColor = Color.GreenYellow;
        }        

        private void btnConnect_Click(object sender, EventArgs e)
        {
            serial.PortName = (cbxPortNames.SelectedItem == null) ? "" : cbxPortNames.SelectedItem.ToString();
            serial.BaudRate = Convert.ToInt32(cbxBaudRate.SelectedItem.ToString());
            serial.Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            serial.Disconnect();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillCbxPortNames();
        }

        private void fillCbxPortNames()
        {
            cbxPortNames.Items.Clear();
            cbxPortNames.Items.AddRange(serial.PortNames);
        }

        void serial_Error(object sender, ErrorArgs e)
        {
            MessageBox.Show(e.Error);
        }

        void serial_DataReceived(object sender, DataReceivedArgs e)
        {
            if (e.Data.Length < 4) {
                // too short
                return;
            }
            
            if( 6 + e.Data[3] != e.Data.Length) {
                // frame length mismatch
                return;
            }
            
            if(e.Data[3] < 8) {
                // need at least four channels
                return;
            }

            byte checksum = 0;

            // calculate checksum
            for (int i = 3; i < (e.Data.Length - 1);i++ )
            {
                checksum ^= e.Data[i];
            }

            if (checksum != e.Data[e.Data.Length - 1])
            {
                return;
            }
            
            int roll = BitConverter.ToInt16(e.Data, 5);
            int pitch = BitConverter.ToInt16(e.Data, 7);
            int yaw = BitConverter.ToInt16(e.Data, 9);
            int throttle = BitConverter.ToInt16(e.Data, 11);
          
            displayRcValueThrottle.Value = throttle;
            displayRcValueYaw.Value = yaw;
            displayRcValuePitch.Value = pitch;
            displayRcValueRoll.Value = roll;

            yaw = (int)(((double)(yaw - 1000) / 1000D) * 32768);
            if (cbxYaw.Checked) {
                yaw = 32768 - yaw;
            }

            throttle = (int)(((double)(throttle - 1000) / 1000D) * 32768);
            if (cbxThrottle.Checked)
            {
                throttle = 32768 - throttle;
            }

            roll = (int)(((double)(roll - 1000) / 1000D) * 32768);
            if (cbxRoll.Checked)
            {
                roll = 32768 - roll;
            }

            pitch = (int)(((double)(pitch - 1000) / 1000D) * 32768);
            if (cbxPitch.Checked)
            {
                pitch = 32768 - pitch;
            }            

            vJoy.SetAxis(throttle, HID_USAGES.HID_USAGE_RX);
            vJoy.SetAxis(yaw, HID_USAGES.HID_USAGE_X);

            vJoy.SetAxis(roll, HID_USAGES.HID_USAGE_RY);
            vJoy.SetAxis(pitch, HID_USAGES.HID_USAGE_Y);
        }

        void serial_Disconnected(object sender)
        {
            btnConnect.Visible = true;
            btnDisconnect.Visible = false;
            timerRc.Enabled = false;
        }

        void serial_Connected(object sender)
        {
            btnConnect.Visible = false;
            btnDisconnect.Visible = true;
            timerRc.Enabled = true;
        }

        private void timerRc_Tick(object sender, EventArgs e)
        {
            byte[] data = new byte[6];
            data[0] = Convert.ToByte('$');
            data[1] = Convert.ToByte('M');
            data[2] = Convert.ToByte('<');
            data[3] = Convert.ToByte(0);
            data[4] = Convert.ToByte(105);
            data[5] = Convert.ToByte(105);

            serial.Write(data);
        }

        private void setTextBox(TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke((MethodInvoker)delegate { textBox.Text = text; });
            }
            else
            {
                textBox.Text = text;
            }
        }

        private void setProgressBar(ProgressBar progressBar, int value)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke((MethodInvoker)delegate { progressBar.Value = value; });
            }
            else
            {
                progressBar.Value = value;
            }
        }

        private void cbxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerRc.Interval = Convert.ToInt32(cbxInterval.SelectedItem);
        }

        
    }
}
