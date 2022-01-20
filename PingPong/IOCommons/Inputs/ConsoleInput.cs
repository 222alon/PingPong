using IOCommons.Inputs.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCommons.Inputs
{
    public class ConsoleInput : IInput
    {
        public string ReadLine()
        {
            string result = Console.ReadLine();
            return result;
        }
    }
}
