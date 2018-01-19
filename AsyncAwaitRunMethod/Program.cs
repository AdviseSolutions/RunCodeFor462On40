using System;
using System.Threading.Tasks;

namespace AsyncAwaitRunMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoStuff().Wait();
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
