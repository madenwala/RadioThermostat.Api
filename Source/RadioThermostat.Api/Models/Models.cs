using Newtonsoft.Json;
using System.Collections.Generic;

namespace RadioThermostat.Api.Models
{
    public class ThermostatModel
    {
        [JsonProperty("model")]
        public string Model { get; set; }
    }

    //public class RemoteTemperature
    //{
    //    public int rem_mode { get; set; }
    //}

    //public class ThermostatLockMode
    //{
    //    public int lock_mode { get; set; }
    //}
    //public class SimpleMode
    //{
    //    public int simple_mode { get; set; }
    //}
    //public class SaveEnergy
    //{
    //    public int mode { get; set; }
    //    public int type { get; set; }
    //}

    //public class NightLight
    //{
    //    public int intensity { get; set; }
    //}


    public class Network
    {
        public string ssid { get; set; }
        public string bssid { get; set; }
        public int channel { get; set; }
        public int security { get; set; }
        public int ip { get; set; }
        public int rssi { get; set; }
    }
}
