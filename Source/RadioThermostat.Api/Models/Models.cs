﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioThermostat.Api.Models
{
    public class ThermostatModel
    {
        public string model { get; set; }
    }

    public class Program
    {
        [JsonProperty("0")]
        public List<int> Day0 { get; set; }

        [JsonProperty("1")]
        public List<int> Day1 { get; set; }

        [JsonProperty("2")]
        public List<int> Day2 { get; set; }

        [JsonProperty("3")]
        public List<int> Day3 { get; set; }

        [JsonProperty("4")]
        public List<int> Day4 { get; set; }

        [JsonProperty("5")]
        public List<int> Day5 { get; set; }

        [JsonProperty("6")]
        public List<int> Day6 { get; set; }
    }

    public class RemoteTemperature
    {
        public int rem_mode { get; set; }
    }

    public class ThermostatLockMode
    {
        public int lock_mode { get; set; }
    }
    public class SimpleMode
    {
        public int simple_mode { get; set; }
    }
    public class SaveEnergy
    {
        public int mode { get; set; }
        public int type { get; set; }
    }

    public class NightLight
    {
        public int intensity { get; set; }
    }


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
