using System.Net;
using System.Net.Sockets;

var address = IPAddress.Any;
var port = 668; // the neighbour of the beast
TcpListener listener = new TcpListener(address, port);
listener.Start();

//listener.Stop();
Console.WriteLine("Starting server loop");
while (true)
{
    //wait for a request
    Console.WriteLine($"Waiting for tcp client");
    var client = listener.AcceptTcpClient();
    Console.WriteLine($"Accepted tcp client");
    //process request and send response
    using var stream = client.GetStream();
    byte[] buffer = new byte[1024];
    Span<byte> bytes = new Span<byte>(buffer);
    var byteCount = stream.Read(bytes);

    //send out response
    if (byteCount == -1)
    {
        Console.WriteLine("The stream has ended");
    }
    else
    {
        Console.WriteLine($"We read the value {byteCount}");
    }

}