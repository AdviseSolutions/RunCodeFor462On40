using System;
using System.Threading.Tasks;

namespace AsyncAwaitDoNotRunMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Don't call the async method.");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static async Task DoStuff()
        {
            Console.WriteLine("Waiting 100 ms...");
            await Task.Delay(100);
            Console.WriteLine("Done waiting!");
        }
    }
}
