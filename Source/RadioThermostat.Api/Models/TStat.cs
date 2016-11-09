using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioThermostat.Api.Models
{
    public class ThermostatResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public sealed class TStat : ModelBase
    {
        private double _Temp;
        [JsonProperty("temp")]
        public double Temp
        {
            get { return _Temp; }
            set { this.SetProperty(ref _Temp, value); }
        }

        private ThermostatModes _ThermostatMode;
        [JsonProperty("tmode")]
        public ThermostatModes ThermostatMode
        {
            get { return _ThermostatMode; }
            set { this.SetProperty(ref _ThermostatMode, value); }
        }

        [JsonProperty("fmode")]
        public FanOperatingModes FanOperatingMode { get; set; }

        [JsonProperty("override")]
        public Overrides @Override { get; set; }

        [JsonProperty("hold")]
        public bool Hold { get; set; }

        [JsonProperty("t_heat")]
        public double THeat { get; set; }

        [JsonProperty("tstate")]
        public HvacOperatingStates HvacOperatingStates { get; set; }

        [JsonProperty("fstate")]
        public FanOperatingStates FanOperatingStates { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }

        [JsonProperty("t_type_post")]
        public TTypePosts TTypePost { get; set; }
    }

    public class Time
    {
        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("hour")]
        public int Hour { get; set; }

        [JsonProperty("minute")]
        public int Minute { get; set; }
    }

    public enum ThermostatModes
    {
        Off = 0,
        Heat = 1,
        Cool = 2,
        Auto = 3
    }

    public enum Overrides
    {
        Disabled = 0,
        Enabled = 1
    }

    public enum FanOperatingModes
    {
        Auto = 0,
        AutoCirculate = 1,
        On = 2
    }

    public enum HvacOperatingStates
    {
        Off = 0,
        Heat = 1,
        Cool = 2
    }

    public enum FanOperatingStates
    {
        Off = 0,
        On = 1
    }

    public enum TTypePosts
    {
        TemporaryTarget = 0,
        AbsoluteTarget = 1,
        Unknown = 2
    }
}
