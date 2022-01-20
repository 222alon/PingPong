using IOCommons.Inputs.Abstracts;

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
