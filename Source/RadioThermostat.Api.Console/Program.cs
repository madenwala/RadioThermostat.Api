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

            Print(await client.GetModelInfo(cts.Token));
            Print(await client.GetSystemInfo(cts.Token));
            Print(await client.GetNetworkInfo(cts.Token));

            var tstat1 = await client.GetThermostatStatus(cts.Token);
            Print(tstat1);
            
            tstat1.ThermostatMode = ThermostatModes.Heat;
            tstat1.TemperatureHeat = 71;
            tstat1.FanOperatingMode = FanOperatingModes.Auto;
            tstat1.FanOperatingState = FanOperatingStates.Off;

            var tstat2 = await client.SetThermostatStatus(tstat1, cts.Token);
            Print(tstat2);
            
            Print(await client.GetProgramHeat(cts.Token));
            Print(await client.GetProgramCool(cts.Token));
        }

        private static void Print(TStat tstat)
        {
            Console.WriteLine("Mode: " + tstat.ThermostatMode);
            Console.WriteLine("Fan: " + tstat.FanOperatingMode);
            Console.WriteLine("Current Temp: " + tstat.CurrentTemperature);
            Console.WriteLine("Target Heat: " + tstat.TemperatureHeat);
            Console.WriteLine("Target Cool: " + tstat.TemperatureCool);
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

        private static void Print(Sys sys)
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

        private static void Print(ThermostatProgram p)
        {
            Console.WriteLine("Day0: " + string.Join(",", p.Day0));
            Console.WriteLine("Day1: " + string.Join(",", p.Day1));
            Console.WriteLine("Day2: " + string.Join(",", p.Day2));
            Console.WriteLine("Day3: " + string.Join(",", p.Day3));
            Console.WriteLine("Day4: " + string.Join(",", p.Day4));
            Console.WriteLine("Day5: " + string.Join(",", p.Day5));
            Console.WriteLine("Day6: " + string.Join(",", p.Day6));
            Console.WriteLine("***********************************************");
        }
    }
}
