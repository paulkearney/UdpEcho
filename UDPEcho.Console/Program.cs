using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPEcho.Server;

namespace UDPEcho.ConsoleApp
{
    class Program
    {
        static UDPServer udpServer;

        static void Main(string[] args)
        {
            int port = 0;
            if (Int32.TryParse(ConfigurationManager.AppSettings["port"], out port) == false)
            {
                Console.WriteLine("Invalid port specified. Press any key");
                Console.ReadKey();
                return;
            }

            udpServer = new UDPServer(port);
            Console.WriteLine("Press Ctrl+C to quit.");
            Console.CancelKeyPress += Console_CancelKeyPress;
            udpServer.Listen();
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            udpServer.Cancel();
        }
    }
}
