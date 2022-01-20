using IOCommons.Inputs.Abstracts;
using IOCommons.Outputs.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Persons;
using SocketClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                Output.WriteLine("Enter person name:");
                string name = Input.ReadLine();

                if (name == "exit")
                {
                    break;
                }

                Output.WriteLine("Enter person age:");
                string age = Input.ReadLine();

                if (age == "exit")
                {
                    break;
                }

                var person = new Person(name, int.Parse(age));

                var settings = new JsonSerializerSettings() { ContractResolver = new MyContractResolver() };
                var msg = JsonConvert.SerializeObject(person, settings);

                string answer = Client.IntaractWithServer(msg);

                var responsePerson = JsonConvert.DeserializeObject<Person>(answer, settings);



                Output.WriteLine(responsePerson.ToString());
            }
        }
    }
    public class MyContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .Select(p => base.CreateProperty(p, memberSerialization))
                        .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                   .Select(f => base.CreateProperty(f, memberSerialization)))
                        .ToList();
            props.ForEach(p => { p.Writable = true; p.Readable = true; });
            return props;
        } 
    }
}
