using RadioThermostat.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RadioThermostat.Api
{
    public sealed class ThermostatClient: ClientApiBase
    {
        public ThermostatClient(string ipAddress) 
            : base($"http://{ipAddress}")
        {
        }

        public async Task<TStat> GetTStat(CancellationToken ct)
        {
            return await this.GetAsync<TStat>("tstat", ct);
        }
    }
}
