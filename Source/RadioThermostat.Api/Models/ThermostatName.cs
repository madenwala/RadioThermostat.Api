using Newtonsoft.Json;

namespace RadioThermostat.Api.Models
{
    public class ThermostatName
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}