using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace MultiWiiVJoy
{
    public class Serial
    {
        public delegate void DataReceivedHandler(object sender, DataReceivedArgs e);
        public event DataReceivedHandler DataReceived;

        public delegate void ErrorHandler(object sender, ErrorArgs e);
        public event ErrorHandler Error;

        public delegate void ConnectedHandler(object sender);
        public event ConnectedHandler Connected;

        public delegate void DisconnectedHandler(object sender);
        public event DisconnectedHandler Disconnected;

        protected SerialPort serialPort = null;

        protected int baudRate = 9600;
        protected String portName = "";

        public int BaudRate 
        {
            get { return baudRate; }
            set { baudRate = value; }
        }
        public String PortName
        {
            get { return portName; }
            set { portName = value; }
        }

        public String[] PortNames
        {
            get 
            {
                return SerialPort.GetPortNames();
            }
        }

        protected Boolean initialized = false;

        public void Init()
        {
            if (serialPort != null)
            {
                Disconnect();
                serialPort.DataReceived -= new SerialDataReceivedEventHandler(serialPort_DataReceived);
                serialPort.ErrorReceived -= new SerialErrorReceivedEventHandler(serialPort_ErrorReceived);
            }

            serialPort = new SerialPort();
            serialPort.BaudRate = baudRate;
            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort.DataBits = 8;
            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");

            serialPort.ReadTimeout = 2000;
            serialPort.WriteTimeout = 2000;

            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(serialPort_ErrorReceived);

            initialized = true;
        }

        public void Connect()
        {
            if (initialized == false)
            {                
                RaiseError("Port has to be initialized first!");
                return;
            }
            if (portName == "")
            {                
                RaiseError("Portname missing!");
                return;
            }
            if (baudRate == 0)
            {
                RaiseError("Baudrate missing!");
                return;
            }
            if (serialPort.IsOpen)
            {
                return;
            }

            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;

            try
            {
                serialPort.Open();
            }
            catch (ArgumentException e)
            {               
                RaiseError(e.ToString());
                return;
            }
            catch (Exception e)
            {                
                RaiseError(e.ToString());
                return;
            }
            
            RaiseConnected();
        }

        public void Disconnect()
        {
            if (initialized == false)
            {
                RaiseError("Port has to be initialized first!");
                return;
            }

            if (!serialPort.IsOpen)
            {
                return;
            }

            try
            {
                serialPort.Close();
            }
            catch (Exception e)
            {                
                RaiseError(e.ToString());
                return;
            }
            RaiseDisconnected();          
        }

        public void Write(byte[] data)
        {
            if (!serialPort.IsOpen)
            {
                return;
            }

            try
            {
                serialPort.DiscardOutBuffer();
                serialPort.Write(data, 0, data.Length);                
            }
            catch (Exception e)
            {
                RaiseError(e.Message);
            }
        }

        void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            RaiseError(e.ToString());
        }

        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[serialPort.BytesToRead];
            serialPort.Read(data, 0, data.Length);
            RaiseDataReceived(data);
        }

        protected virtual void RaiseDataReceived(byte[] data)
        {
            if (DataReceived != null)
            {
                DataReceived(this, new DataReceivedArgs(data));
            }
        }

        protected virtual void RaiseError(String error)
        {
            if (Error != null)
            {
                Error(this, new ErrorArgs(error));
            }
        }

        protected virtual void RaiseConnected()
        {
            if (Connected != null)
            {
                Connected(this);
            }
        }

        protected virtual void RaiseDisconnected()
        {
            if (Disconnected != null)
            {
                Disconnected(this);
            }
        }


    }

    public class DataReceivedArgs
    {
        public DataReceivedArgs(byte[] data) { Data = data; }
        public byte[] Data { get; private set; }
    }

    public class ErrorArgs
    {
        public ErrorArgs(String error) { Error = error; }
        public String Error { get; private set; }
    }
}
