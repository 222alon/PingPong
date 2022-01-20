using BasicEchoServer;

namespace PingPong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int port = 6666;
            if (args.Length > 0)
            {
                port = int.Parse(args[0]);
            }
            else
            {
                throw new ArgumentException("No port arguments received!");
            }

            Console.WriteLine($"Running server at port {port}");
            var server = new Server(port);

            server.ExecuteServer();
        }
    }
}