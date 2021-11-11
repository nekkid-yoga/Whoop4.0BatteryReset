using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace COMSpike
{
    public class SerialPortComms
    {
        private SerialPort port;

        public SerialPortComms(int portNumber)
        {
            port = new SerialPort($"COM{portNumber}", 9600, Parity.None, 8, StopBits.One);

            port.DataReceived += Port_DataReceived;
            port.ErrorReceived += Port_ErrorReceived;
        }

        public void ResetWhoop()
        {
            port.Open();

            Console.WriteLine($"IsOpen: {port.IsOpen}");

            Console.WriteLine("Writing 'Reboot' to port...");
            port.Write("Reboot");

            Thread.Sleep(1000);

            Close();
        }

        internal void Close()
        {
            Console.WriteLine("Closing port...");
            port.Close();
        }

        private void Port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Console.WriteLine($"Error Received: {e.EventType}");
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            Console.WriteLine($"Data Received: {port.ReadExisting()}");
        }
    }
}