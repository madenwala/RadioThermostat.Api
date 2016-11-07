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

            Console.ReadKey();
        }

        private static async Task Work()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var client = new ThermostatClient("192.168.1.101");

            var sys = await client.GetSys(cts.Token);
            Console.WriteLine(sys.ApiVersion);

            var tstat = await client.GetTStat(cts.Token);
            Console.WriteLine(tstat.Temp);

            var model = await client.GetTStatModel(cts.Token);
            Console.WriteLine(model.model);

            var programHeat = await client.GetProgramHeat(cts.Token);
            Console.WriteLine(programHeat.Day0);

            var programCool = await client.GetProgramCool(cts.Token);
            Console.WriteLine(programCool.Day0);
        }
    }
}
