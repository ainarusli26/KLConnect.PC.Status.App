using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace KLConnect.PC.Status.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int status = 0;
            string pcName = ConfigurationManager.AppSettings.Get("pcName");
            int active = int.Parse(ConfigurationManager.AppSettings.Get("active"));
            int turnOn = int.Parse(ConfigurationManager.AppSettings.Get("pcTurnOn"));
            string appName = ConfigurationManager.AppSettings.Get("appName");

            List<string> appNames = appName.Split(",").ToList() ;
            status = ((List<UpdateStatusModel>)await PcStatusDAL.Instance.sendStatus(pcName, turnOn))[0].RM;

                Process[] processes = Process.GetProcesses();
                foreach (var proc in processes)
                {
                    if (appNames.Contains(proc.MainWindowTitle))
                    {
                        status = ((List<UpdateStatusModel>)await PcStatusDAL.Instance.sendStatus(pcName, active))[0].RM;
                        break;
                    }

                }
            }
    }
}
