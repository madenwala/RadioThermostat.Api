using RadioThermostat.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

        public async Task<ThermostatModel> GetModelInfo(CancellationToken ct)
        {
            return await this.GetAsync<ThermostatModel>("tstat/model", ct);
        }

        public async Task<Sys> GetSystemInfo(CancellationToken ct)
        {
            return await this.GetAsync<Sys>("sys", ct);
        }

        public async Task<Network> GetNetworkInfo(CancellationToken ct)
        {
            return await this.GetAsync<Network>("sys/network", ct);
        }

        public async Task<ThermostatStatus> GetThermostatStatus(CancellationToken ct)
        {
            var response = await this.GetAsync<ThermostatStatus>("tstat", ct);
            response.ClearPropertiesChangedList();
            return response;
        }

        public async Task<ThermostatStatus> SetThermostatStatus(ThermostatStatus tstat, CancellationToken ct)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(tstat.GetChangedProperties());
            var content = new StringContent(json, Encoding.UTF8);
            var response = await this.PostAsync<ThermostatResponse>("tstat", ct, content);
            return await this.GetThermostatStatus(ct);
        }

        public async Task<ProgramModel> GetProgramHeat(CancellationToken ct)
        {
            return await this.GetAsync<ProgramModel>("tstat/program/heat", ct);
        }

        public async Task<ProgramModel> GetProgramCool(CancellationToken ct)
        {
            return await this.GetAsync<ProgramModel>("tstat/program/cool", ct);
        }

        //public async Task<RemoteTemperature> GetRemoteTemperature(CancellationToken ct)
        //{
        //    return await this.GetAsync<RemoteTemperature>("tstat/remote_temp", ct);
        //}

        //public async Task<ThermostatLockMode> GetThermostatLockMode(CancellationToken ct)
        //{
        //    return await this.GetAsync<ThermostatLockMode>("tstat/lock", ct);
        //}

        //public async Task<SimpleMode> GetSimpleMode(CancellationToken ct)
        //{
        //    return await this.GetAsync<SimpleMode>("tstat/simple_mode", ct);
        //}

        //public async Task<SaveEnergy> GetSaveEnergy(CancellationToken ct)
        //{
        //    return await this.GetAsync<SaveEnergy>("tstat/save_energy", ct);
        //}

        //public async Task<NightLight> GetNightLight(CancellationToken ct)
        //{
        //    return await this.GetAsync<NightLight>("tstat/night_light", ct);
        //}
    }
}
