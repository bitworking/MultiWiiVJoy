using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using vJoyInterfaceWrap;

namespace MultiWiiVJoy
{
    public class VirtualJoystick
    {
        public delegate void SuccessHandler(object sender);
        public event SuccessHandler Success;

        public delegate void ErrorHandler(object sender, ErrorArgs e);
        public event ErrorHandler Error;


        // Declaring one joystick (Device id 1) and a position structure. 
        private vJoy joystick;
        private vJoy.JoystickState iReport;
        public uint id = 1;

        private Boolean initialized = false;
        

        public void Init()
        {
            // Create one joystick object and a position structure.
            joystick = new vJoy();
            iReport = new vJoy.JoystickState();


            // Device ID can only be in the range 1-16            
            if (id <= 0 || id > 16)
            {
                RaiseError(String.Format("Illegal device ID {0}\r\nExit!", id));
                return;
            }

            // Get the driver attributes (Vendor ID, Product ID, Version Number)
            if (!joystick.vJoyEnabled())
            {
                RaiseError("vJoy driver not enabled: Failed Getting vJoy attributes.");
                return;
            }
            else
            {
                Console.WriteLine("Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", joystick.GetvJoyManufacturerString(), joystick.GetvJoyProductString(), joystick.GetvJoySerialNumberString());
            }

            // Get the state of the requested device
            VjdStat status = joystick.GetVJDStatus(id);
            switch (status)
            {
                case VjdStat.VJD_STAT_OWN:
                    Console.WriteLine("vJoy Device {0} is already owned by this feeder\n", id);
                    break;
                case VjdStat.VJD_STAT_FREE:
                    Console.WriteLine("vJoy Device {0} is free\n", id);
                    break;
                case VjdStat.VJD_STAT_BUSY:
                    RaiseError(String.Format("vJoy Device {0} is already owned by another feeder\r\nCannot continue", id));
                    return;
                case VjdStat.VJD_STAT_MISS:
                    RaiseError(String.Format("vJoy Device {0} is not installed or disabled\r\nCannot continue", id));
                    return;
                default:
                    RaiseError(String.Format("vJoy Device {0} general error\r\nCannot continue", id));
                    return;
            };

            // Check which axes are supported
            bool AxisX = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_X);
            bool AxisY = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_Y);
            bool AxisZ = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_Z);
            bool AxisRX = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RX);
            bool AxisRZ = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RZ);
            // Get the number of buttons and POV Hat switchessupported by this vJoy device
            int nButtons = joystick.GetVJDButtonNumber(id);
            int ContPovNumber = joystick.GetVJDContPovNumber(id);
            int DiscPovNumber = joystick.GetVJDDiscPovNumber(id);

            // Print results
            Console.WriteLine("\nvJoy Device {0} capabilities:\n", id);
            Console.WriteLine("Numner of buttons\t\t{0}\n", nButtons);
            Console.WriteLine("Numner of Continuous POVs\t{0}\n", ContPovNumber);
            Console.WriteLine("Numner of Descrete POVs\t\t{0}\n", DiscPovNumber);
            Console.WriteLine("Axis X\t\t{0}\n", AxisX ? "Yes" : "No");
            Console.WriteLine("Axis Y\t\t{0}\n", AxisX ? "Yes" : "No");
            Console.WriteLine("Axis Z\t\t{0}\n", AxisX ? "Yes" : "No");
            Console.WriteLine("Axis Rx\t\t{0}\n", AxisRX ? "Yes" : "No");
            Console.WriteLine("Axis Rz\t\t{0}\n", AxisRZ ? "Yes" : "No");

            // Acquire the target
            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!joystick.AcquireVJD(id))))
            {
                RaiseError(String.Format("Failed to acquire vJoy device number {0}.", id));
                return;
            }
            else
            {
                Console.WriteLine("Acquired: vJoy device number {0}.\n", id);
            }

            // Reset this device to default values
            joystick.ResetVJD(id);

            initialized = true;

            RaiseSuccess();

        }

        public void SetAxis(int value, HID_USAGES axis)
        {
            if (!initialized) {
                return;
            }

            joystick.SetAxis(value, id, axis);
        }

        protected virtual void RaiseError(String error)
        {
            if (Error != null)
            {
                Error(this, new ErrorArgs(error));
            }
        }

        protected virtual void RaiseSuccess()
        {
            if (Success != null)
            {
                Success(this);
            }
        }


    }


}
