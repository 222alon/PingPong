using IOCommons.Inputs;
using IOCommons.Outputs;
using SocketClient;

namespace PingPongClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int port;
            string ip;

            if (args.Length > 1)
            {
                ip = args[0];
                port = int.Parse(args[1]);
            }
            else
            {
                throw new ArgumentException($"Expected 2 args: IP PORT, instead only got {args.Length} arguments!");
            }

            var client = new Client(ip, port);

            var input = new ConsoleInput();
            var output = new ConsoleOutput();

            var intaractor = new ServerIntaractor(output, input, client);

            intaractor.Start();
        }
    }
}