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

        public async Task<Sys> GetSys(CancellationToken ct)
        {
            return await this.GetAsync<Sys>("sys", ct);
        }

        public async Task<TStat> GetTStat(CancellationToken ct)
        {
            return await this.GetAsync<TStat>("tstat", ct);
        }

        public async Task<ThermostatModel> GetTStatModel(CancellationToken ct)
        {
            return await this.GetAsync<ThermostatModel>("tstat/model", ct);
        }

        public async Task<Program> GetProgramHeat(CancellationToken ct)
        {
            return await this.GetAsync<Program>("tstat/program/heat", ct);
        }

        public async Task<Program> GetProgramCool(CancellationToken ct)
        {
            return await this.GetAsync<Program>("tstat/program/cool", ct);
        }

        public async Task<RemoteTemperature> GetRemoteTemperature(CancellationToken ct)
        {
            return await this.GetAsync<RemoteTemperature>("tstat/remote_temp", ct);
        }

        public async Task<ThermostatLockMode> GetThermostatLockMode(CancellationToken ct)
        {
            return await this.GetAsync<ThermostatLockMode>("tstat/lock", ct);
        }

        public async Task<SimpleMode> GetSimpleMode(CancellationToken ct)
        {
            return await this.GetAsync<SimpleMode>("tstat/simple_mode", ct);
        }

        public async Task<SaveEnergy> GetSaveEnergy(CancellationToken ct)
        {
            return await this.GetAsync<SaveEnergy>("tstat/save_energy", ct);
        }

        public async Task<NightLight> GetNightLight(CancellationToken ct)
        {
            return await this.GetAsync<NightLight>("tstat/night_light", ct);
        }



        public async Task<Network> GetNetworkInfo(CancellationToken ct)
        {
            return await this.GetAsync<Network>("sys/network", ct);
        }
    }
}
