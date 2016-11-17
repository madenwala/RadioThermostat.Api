using Newtonsoft.Json;

namespace RadioThermostat.Api.Models
{
    public sealed class SystemInfo
    {
        #region Properties

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("api_version")]
        public int ApiVersion { get; set; }

        [JsonProperty("fw_version")]
        public string FwVersion { get; set; }

        [JsonProperty("wlan_fw_version")]
        public string WlanFwVersion { get; set; }

        #endregion
    }
}
