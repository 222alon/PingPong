using IOCommons.Outputs.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCommons.Outputs
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string data)
        {
            Console.WriteLine(data);
        }
    }
}
