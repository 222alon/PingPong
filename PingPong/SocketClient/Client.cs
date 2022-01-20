using SocketCommons;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    public class Client
    {
        public Socket ClientSocket { get; set; }
        private SocketMessageHandler _handler;

        public Client(string ip, int port)
        {
            try
            {
                IPAddress ipAddr = Dns.GetHostEntry(ip).AddressList[0];

                // IPAddress ipAddr = IPAddress.Parse(ip);
                var localEndPoint = new IPEndPoint(ipAddr, port);

                // Creation TCP/IP Socket using
                // Socket Class Constructor
                var sender = new Socket(ipAddr.AddressFamily,
                           SocketType.Stream, ProtocolType.Tcp);

                // Connect Socket to the remote
                // endpoint using method Connect()
                sender.Connect(localEndPoint);
                ClientSocket = sender;
                _handler = new SocketMessageHandler(sender);
            }

            catch (Exception e)
            {
                Console.WriteLine($"Error while creating client socket: {e}");
                throw;
            }
        }

        ~Client()
        {
            // Close Socket using
            // the method Close()
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }

        public string IntaractWithServer(string msg)
        {
            _handler.SendMsg(msg);

            return _handler.RecieveMsg();
        }
    }
}