using SocketCommons.Exceptions;
using System.Net.Sockets;
using System.Text;

namespace SocketCommons
{
    public class SocketMessageHandler
    {
        public Socket Socket { get; set; }

        public SocketMessageHandler(Socket socket)
        {
            Socket = socket;
        }

        ~SocketMessageHandler()
        {
            Socket.Shutdown(SocketShutdown.Both);
            Socket.Close();
        }

        private void VerifyConnection()
        {
            bool part1 = Socket.Poll(1000, SelectMode.SelectRead);
            bool part2 = (Socket.Available == 0);
            if (part1 && part2)
                throw new SocketClosedException($"The socket has been closed!");
        }

        public void SendMsg(string data)
        {
            VerifyConnection();

            byte[] msg = Encoding.ASCII.GetBytes($"{data}<EOF>");

            Socket.Send(msg);
        }

        public string RecieveMsg()
        {
            VerifyConnection();

            // Incoming data from the client.
            string data = "";
            byte[] bytes;

            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = Socket.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    data = data[..(data.Length - 5)];
                    break;
                }
            }

            return data;
        }
    }
}