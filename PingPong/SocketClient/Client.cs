using SocketCommons;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    public class Client
    {
        public TcpClient TcpClient { get; set; }
        private SocketMessageHandler _handler;

        public Client(string ip, int port)
        {
            IPAddress ipAddr = Dns.GetHostEntry(ip).AddressList[0];

            var localEndPoint = new IPEndPoint(ipAddr, port);

            TcpClient = new TcpClient();

            TcpClient.Connect(localEndPoint);

            _handler = new SocketMessageHandler(TcpClient.Client);
        }

        ~Client()
        {
            TcpClient.Close();
        }

        public string IntaractWithServer(string msg)
        {
            _handler.SendMsg(msg);

            return _handler.RecieveMsg();
        }
    }
}