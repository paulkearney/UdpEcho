using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpEcho.Talker
{
    class Program
    {
        static void Main(string[] args)
        {
            var udpClient = new UdpClient();
            var line = Console.ReadLine();
            while (line != "quit")
            {
                var bytes = Encoding.ASCII.GetBytes(line);
                udpClient.Send(bytes, bytes.Length, "localhost", 8125);
                line = Console.ReadLine();
            }
        }
    }
}
