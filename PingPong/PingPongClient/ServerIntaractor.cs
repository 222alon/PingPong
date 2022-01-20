using IOCommons.Inputs.Abstracts;
using IOCommons.Outputs.Abstracts;
using SocketClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient
{
    public class ServerIntaractor
    {
        public IOutput Output { get; set; }

        public IInput Input { get; set; }

        public Client Client { get; set; }

        public ServerIntaractor(IOutput output, IInput input, Client client)
        {
            Output = output;
            Input = input;
            Client = client;
        }

        public void Start()
        {
            while (true)
            {
                string msg = Input.ReadLine();

                if (msg == "exit")
                {
                    break;
                }

                string answer = Client.IntaractWithServer(msg);

                Output.WriteLine(answer);
            }
        }
    }
}
