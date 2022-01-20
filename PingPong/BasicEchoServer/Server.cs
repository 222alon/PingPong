using SocketCommons;
using SocketCommons.Exceptions;
using System.Net;
using System.Net.Sockets;

namespace BasicEchoServer
{
    public class Server
    {
        public int Port { get; set; }

        public Server(int port)
        {
            Port = port;
        }

        public void ExecuteServer()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            var localEndPoint = new IPEndPoint(ipAddress, Port);

            var tcpListener = new TcpListener(localEndPoint);
            tcpListener.Start();

            while (true)
            {
                Socket client = tcpListener.AcceptSocket();

                ExecuteEchoConnection(client);
            }
        }

        private async Task ExecuteEchoConnection(Socket client)
        {
            await Task.Run(() => {
                var handler = new SocketMessageHandler(client);

                while (true)
                {
                    try
                    {
                        string data = handler.RecieveMsg();
                        if (data != "")
                        {
                            handler.SendMsg(data);
                        }
                    }
                    catch (SocketClosedException)
                    {
                        break;
                    }
                }
            });
        }
    }
}