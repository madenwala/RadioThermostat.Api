using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioThermostat.Api.Models
{
    public sealed class Sys : ModelBase
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("api_version")]
        public int ApiVersion { get; set; }

        [JsonProperty("fw_version")]
        public string FwVersion { get; set; }

        [JsonProperty("wlan_fw_version")]
        public string WlanFwVersion { get; set; }
    }
}
