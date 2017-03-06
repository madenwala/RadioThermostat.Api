using RadioThermostat.Api.Models;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RadioThermostat.Api
{
    public sealed class ThermostatClient: ClientApiBase
    {
        /// <summary>
        /// Connects to a RadioThermostat instance.
        /// </summary>
        /// <param name="ipAddress">IP address of the thermostat</param>
        /// <param name="logger">Optional class instance that inherits from ILogger for logging of http data.</param>
        public ThermostatClient(string ipAddress, ILogger logger = null) 
            : base($"http://{ipAddress}", false, logger)
        {
        }

        /// <summary>
        /// Retrieves the model information of the thermostat.
        /// </summary>
        /// <param name="ct">Cancellation token instance.</param>
        /// <returns></returns>
        public async Task<ThermostatModel> GetModelInfo(CancellationToken ct)
        {
            return await this.GetAsync<ThermostatModel>("tstat/model", ct);
        }

        /// <summary>
        /// Retrieves the system information of the thermostat.
        /// </summary>
        /// <param name="ct">Cancellation token instance.</param>
        /// <returns></returns>
        public async Task<SystemInfo> GetSystemInfo(CancellationToken ct)
        {
            return await this.GetAsync<SystemInfo>("sys", ct);
        }

        /// <summary>
        /// Returns the network information related to the network the thermostat is connected to. 
        /// </summary>
        /// <param name="ct">Cancellation token instance.</param>
        /// <returns></returns>
        public async Task<Network> GetNetworkInfo(CancellationToken ct)
        {
            return await this.GetAsync<Network>("sys/network", ct);
        }

        /// <summary>
        /// Gets the current status (temperature, mode, etc) of the thermostat.
        /// </summary>
        /// <param name="ct">Cancellation token instance.</param>
        /// <returns></returns>
        public async Task<ThermostatStatus> GetThermostatStatus(CancellationToken ct)
        {
            var response = await this.GetAsync<ThermostatStatus>("tstat", ct);
            response.ClearPropertiesChangedList();
            return response;
        }

        /// <summary>
        /// Sets the current status (temperature, mode, etc) of the thermostat.
        /// </summary>
        /// <param name="tstat"></param>
        /// <param name="ct">Cancellation token instance.</param>
        /// <returns></returns>
        public async Task<ThermostatStatus> SetThermostatStatus(ThermostatStatus tstat, CancellationToken ct)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(tstat.GetChangedProperties());
            var content = new StringContent(json, Encoding.UTF8);
            var response = await this.PostAsync<ThermostatResponse>("tstat", ct, content);

            if (tstat.Mode == ThermostatModes.Off)
                await Task.Delay(1000);

            return await this.GetThermostatStatus(ct);
        }

        /// <summary>
        /// Gets the heat program for the thermostat.
        /// </summary>
        /// <param name="ct">Cancellation token instance.</param>
        /// <returns></returns>
        public async Task<ProgramModel> GetProgramHeat(CancellationToken ct)
        {
            return await this.GetAsync<ProgramModel>("tstat/program/heat", ct);
        }

        /// <summary>
        /// Sets the heat program for the thermostat.
        /// </summary>
        /// <param name="program">Program instance with heat settings per day.</param>
        /// <param name="ct">Cancellation token instance.</param>
        /// <returns></returns>
        public async Task SetProgramHeat(ProgramModel program, CancellationToken ct)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(program);
            var content = new StringContent(json, Encoding.UTF8);
            var response = await this.PostAsync<ThermostatResponse>("tstat/program/heat", ct, content);
        }

        /// <summary>
        /// Gets the cool program for the thermostat.
        /// </summary>
        /// <param name="ct">Cancellation token instance.</param>
        /// <returns></returns>
        public async Task<ProgramModel> GetProgramCool(CancellationToken ct)
        {
            return await this.GetAsync<ProgramModel>("tstat/program/cool", ct);
        }

        /// <summary>
        /// Sets the cool program for the thermostat.
        /// </summary>
        /// <param name="program">Program instance with cool settings per day.</param>
        /// <param name="ct">Cancellation token instance.</param>
        /// <returns></returns>
        public async Task SetProgramCool(ProgramModel program, CancellationToken ct)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(program.GetChangedProperties());
            var content = new StringContent(json, Encoding.UTF8);
            var response = await this.PostAsync<ThermostatResponse>("tstat/program/cool", ct, content);
        }

        /// <summary>
        /// Gets the name set on the thermostat.
        /// </summary>
        /// <param name="ct">Cancellation token instance.</param>
        /// <returns></returns>
        public async Task<ThermostatName> GetName(CancellationToken ct)
        {
            return await this.GetAsync<ThermostatName>("/sys/name", ct);
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
