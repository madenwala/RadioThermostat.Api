using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioThermostat.Api.Models
{
    public class ThermostatName
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
