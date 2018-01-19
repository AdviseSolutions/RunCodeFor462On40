using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace LoadPropertyInDifferentMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Runtime version: " + Environment.Version);
            foreach (var service in ServiceController.GetServices().Where(f => f.DisplayName.Contains("Microsoft")))
            {
                var name = service.DisplayName;
                var startMode = "";

                if (RunCodeThatCrashesOnLowerFrameworks())
                {
                    startMode = GetServiceStartMode(service);
                }
                else
                {
                    startMode = "Unknown";
                }
                Console.WriteLine("Name : " + name);
                Console.WriteLine("StartMode   : " + startMode);
                Console.WriteLine("----------------------------------------------------------------------");
            }

            Console.WriteLine("Press key to continue.");
            Console.ReadKey();
        }

        public static bool RunCodeThatCrashesOnLowerFrameworks()
        {
            return ConfigurationManager.AppSettings["RunCodeThatCrashesOnLowerFrameworks"] == "true";
        }

        private static String GetServiceStartMode(ServiceController _service)
        {
            return _service.StartType.ToString();
        }
    }
}
