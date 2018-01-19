using System;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;

namespace LoadPropertyInSameMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            foreach (var service in ServiceController.GetServices().Where(f => f.DisplayName.Contains("Microsoft")))
            {
                var name = service.DisplayName;
                var startupMode = "";
                if (RunCodeThatCrashesOnLowerFrameworks())
                {
                    startupMode = service.StartType.ToString();
                }
                else
                {
                    startupMode = "Unknown";
                }

                Console.WriteLine("Name : " + name);
                Console.WriteLine("StartMode   : " + startupMode);
                Console.WriteLine("----------------------------------------------------------------------");
            }

            Console.WriteLine("Press key to continue.");
            Console.ReadKey();
        }

        private static bool RunCodeThatCrashesOnLowerFrameworks()
        {
            return ConfigurationManager.AppSettings["RunCodeThatCrashesOnLowerFrameworks"] == "true";
        }
    }
}
