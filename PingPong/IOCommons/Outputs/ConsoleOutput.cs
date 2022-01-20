using IOCommons.Outputs.Abstracts;

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
