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

            var tstat1 = await client.GetTStat(cts.Token);
            Console.WriteLine(tstat1.ThermostatMode);

            var tstatNew = new Models.TStat();
            tstatNew.ThermostatMode = Models.ThermostatModes.Heat;
            var response = await client.PostTStat(tstatNew, cts.Token);

            var tstat2 = await client.GetTStat(cts.Token);
            Console.WriteLine(tstat2.ThermostatMode);


            //var model = await client.GetTStatModel(cts.Token);
            //Console.WriteLine(model.model);

            //var programHeat = await client.GetProgramHeat(cts.Token);
            //Console.WriteLine(programHeat.Day0);

            //var programCool = await client.GetProgramCool(cts.Token);
            //Console.WriteLine(programCool.Day0);
        }
    }
}
