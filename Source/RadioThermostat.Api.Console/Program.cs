using RadioThermostat.Api.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RadioThermostat.Api.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Work().Wait();

            Console.ReadKey();
        }

        private static async Task Work()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var client = new ThermostatClient("192.168.1.101");

            //Print(await client.GetName(cts.Token));
            //Print(await client.GetModelInfo(cts.Token));
            //Print(await client.GetSystemInfo(cts.Token));
            //Print(await client.GetNetworkInfo(cts.Token));

            var tstat1 = await client.GetThermostatStatus(cts.Token);
            Print(tstat1);
            
            //tstat1.Mode = ThermostatModes.Off;
            //tstat1.TargetTemporatureHeat = 71;
            //tstat1.FanOperatingMode = FanOperatingModes.Auto;
            //tstat1.FanOperatingState = false;

            //var tstat2 = await client.SetThermostatStatus(tstat1, cts.Token);
            //Print(tstat2);

            //Print(await client.GetProgramHeat(cts.Token));
            //Print(await client.GetProgramCool(cts.Token));
        }

        private static void Print(ThermostatStatus tstat)
        {
            Console.WriteLine("Mode: " + tstat.Mode);
            Console.WriteLine("Fan: " + tstat.FanOperatingMode);
            Console.WriteLine("Current Temp: " + tstat.CurrentTemperature);
            Console.WriteLine("Target Heat: " + tstat.TargetTemperatureHeat);
            Console.WriteLine("Target Cool: " + tstat.TargetTemperatureCool);
            Console.WriteLine("Time: " + tstat.Time);
            Console.WriteLine("***********************************************");
        }

        private static void Print(Network net)
        {
            Console.WriteLine("IP: " + net.ip);
            Console.WriteLine("SSID: " + net.ssid);
            Console.WriteLine("BSSID: " + net.bssid);
            Console.WriteLine("Channel: " + net.channel);
            Console.WriteLine("RSSI: " + net.rssi);
            Console.WriteLine("Security: " + net.security);
            Console.WriteLine("***********************************************");
        }

        private static void Print(SystemInfo sys)
        {
            Console.WriteLine("ApiVersion: " + sys.ApiVersion);
            Console.WriteLine("FwVersion: " + sys.FwVersion);
            Console.WriteLine("Uuid: " + sys.Uuid);
            Console.WriteLine("WlanFwVersion: " + sys.WlanFwVersion);
            Console.WriteLine("***********************************************");
        }

        private static void Print(ThermostatModel tm)
        {
            Console.WriteLine("Model: " + tm.Model);
            Console.WriteLine("***********************************************");
        }

        private static void Print(ProgramModel p)
        {
            Console.WriteLine("Monday: " + string.Join(",", p.Monday));
            Console.WriteLine("Tuesday: " + string.Join(",", p.Tuesday));
            Console.WriteLine("Wednesday: " + string.Join(",", p.Wednesday));
            Console.WriteLine("Thursday: " + string.Join(",", p.Thursday));
            Console.WriteLine("Friday: " + string.Join(",", p.Friday));
            Console.WriteLine("Saturday: " + string.Join(",", p.Saturday));
            Console.WriteLine("Sunday: " + string.Join(",", p.Sunday));
            Console.WriteLine("***********************************************");
        }

        private static void Print(ThermostatName n)
        {
            Console.WriteLine("Name: " + n.Name);
            Console.WriteLine("***********************************************");
        }
    }
}
