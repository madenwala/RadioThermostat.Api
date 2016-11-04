using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RadioThermostat.Api.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Work().Wait();
        }

        private static async Task Work()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            var client = new ThermostatClient("192.168.1.101");

            var tstat = await client.GetTStat(cts.Token);
            Console.WriteLine(tstat.Temp);
        }
    }
}
