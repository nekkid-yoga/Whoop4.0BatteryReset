using System;
using System.IO.Ports;

namespace COMSpike
{
    namespace SerialPortExample
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                Console.WriteLine("Find your whoop battery pack COM port in Device Manager by:");

                Console.WriteLine(" 1. Open device manager by clicking the Windows button and typing 'Device Manager'");
                Console.WriteLine(" 2. Find and expand the entry, 'Ports (COM & LPT)'");
                Console.WriteLine(" 3. Find the 'USB Serial Port', and note the COM number");
                Console.WriteLine("     3a. I only have one, but if you have multiple, you will need to figure out which one is your battery");
                Console.WriteLine(" 4. Enter the COM number when prompted below");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter the COM port that your whoop battery is on:");

                var key = Console.ReadKey();
                Console.WriteLine();

                if (int.TryParse(key.KeyChar.ToString(), out var comPort))
                {
                    try
                    {
                        var comms = new SerialPortComms(comPort);

                        comms.ResetWhoop();

                        Console.WriteLine("Hopefully your whoop light has come back on, and everything is groovy.");
                        Console.WriteLine("If the light is on, charge your battery pack, then attach it to your whoop.");

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to exit...");

                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Caught an exception while attempting to access COM{comPort}");
                        Console.WriteLine();
                        Console.WriteLine(ex);
                        Console.WriteLine();
                        Console.WriteLine();

                        Console.WriteLine("Restart this app and try again.");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid port number entered... must be an integer.");

                    Console.WriteLine("Restart this app and try again.");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
        }
    }
}