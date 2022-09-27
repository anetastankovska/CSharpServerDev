using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server
{
    public class Server
    {
        public int Port { get; private set; }

        public Server(ServerOptions options)
        {
            Port = options.Port;
        }
        public void Configure(object? configuration = null)
        {
            Console.WriteLine("Server is being configured");
        }

        public void Start()
        {
            Console.WriteLine("Running server");

            var address = IPAddress.Any;

            TcpListener listener = new TcpListener(address, Port);
            listener.Start();

            while (true)
            {
                // wait for a request
                var client = listener.AcceptTcpClient();

                // process request
                TcpSendReceive.ProcessRequest(client);
                // send response
                TcpSendReceive.SendResponse(client);
            }
        }
    }
}
