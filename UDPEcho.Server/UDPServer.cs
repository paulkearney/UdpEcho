using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UdpEcho.Server
{
    public class UdpServer
    {
        private UdpClient client;
        private IPEndPoint groupEndPoint;
        private bool cancelSignal;
        private int port;

        public UdpServer(int listenPort)
        {
            port = listenPort;
            client = new UdpClient(port);
            groupEndPoint = new IPEndPoint(IPAddress.Any, port);
        }

        public void Listen()
        {
            Console.WriteLine("Listening on port {0}...", port);
            while (cancelSignal == false)
            {
                while (cancelSignal == false)
                {
                    var result = BeginListenAsync();
                    while (result.IsCompleted == false)
                    {
                        Thread.Sleep(100);
                        if (cancelSignal == true)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private IAsyncResult BeginListenAsync()
        {
            var result = client.BeginReceive(dataReceived, null);
            return result;
        }

        private void dataReceived(IAsyncResult ar)
        {
            var receivedBytes = client.EndReceive(ar, ref groupEndPoint);
            var receivedData = Encoding.ASCII.GetString(receivedBytes, 0, receivedBytes.Length);
            Console.WriteLine(receivedData);
        }


        public void Cancel()
        {
            cancelSignal = true;
        }
    }
}
