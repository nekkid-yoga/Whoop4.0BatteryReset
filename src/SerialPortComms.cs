using System;
using System.IO.Ports;
using System.Threading;

namespace COMSpike
{
    public class SerialPortComms
    {
        private readonly SerialPort _port;

        public SerialPortComms(int portNumber)
        {
            _port = new SerialPort($"COM{portNumber}", 9600, Parity.None, 8, StopBits.One);

            _port.DataReceived += Port_DataReceived;
            _port.ErrorReceived += Port_ErrorReceived;
        }

        public void ResetWhoop()
        {
            _port.Open();

            Console.WriteLine($"IsOpen: {_port.IsOpen}");

            Console.WriteLine("Writing 'Reboot' to _port...");
            _port.Write("Reboot");

            Thread.Sleep(1000);

            Close();
        }

        private void Close()
        {
            Console.WriteLine("Closing _port...");
            _port.Close();
        }

        private static void Port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Console.WriteLine($"Error Received: {e.EventType}");
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the _port's buffer
            Console.WriteLine($"Data Received: {_port.ReadExisting()}");
        }
    }
}