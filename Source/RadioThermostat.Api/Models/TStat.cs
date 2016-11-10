using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RadioThermostat.Api.Models
{
    public class ThermostatResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public sealed class TStat : ModelBase
    {
        internal override Dictionary<string, object> GetChangedProperties()
        {
            var dic = new Dictionary<string, object>();

            foreach(var property in _changedProperties)
            {
                switch(property)
                {
                    case nameof(ThermostatMode):
                        dic.Add("tmode", (int)this.ThermostatMode);
                        break;

                    case nameof(TargetHeat):
                        dic.Add("t_heat", this.TargetHeat);
                        break;

                    case nameof(TargetCool):
                        dic.Add("t_cool", this.TargetCool);
                        break;

                    case nameof(Hold):
                        dic.Add("hold", this.Hold ? 1 : 0);
                        break;

                    case nameof(FanOperatingMode):
                        dic.Add("fmode", (int)this.FanOperatingMode);
                        break;

                    case nameof(FanOperatingState):
                        dic.Add("fstate", (int)this.FanOperatingState);
                        break;
                }
            }

            return dic;
        }

        private double _currentTemp;
        [JsonProperty("temp")]
        public double CurrentTemperature
        {
            get { return _currentTemp; }
            set { this.SetProperty(ref _currentTemp, value); }
        }

        private ThermostatModes _ThermostatMode;
        [JsonProperty("tmode")]
        public ThermostatModes ThermostatMode
        {
            get { return _ThermostatMode; }
            set { this.SetProperty(ref _ThermostatMode, value); }
        }

        private FanOperatingModes _FanOperatingMode;
        [JsonProperty("fmode")]
        public FanOperatingModes FanOperatingMode
        {
            get { return _FanOperatingMode; }
            set { this.SetProperty(ref _FanOperatingMode, value); }
        }

        private Overrides _Override;
        [JsonProperty("override")]
        public Overrides @Override
        {
            get { return _Override; }
            set { this.SetProperty(ref _Override, value); }
        }

        private bool _Hold;
        [JsonProperty("hold")]
        public bool Hold
        {
            get { return _Hold; }
            set { this.SetProperty(ref _Hold, value); }
        }

        private double _targetCool;
        [JsonProperty("t_cool")]
        public double TargetCool
        {
            get { return _targetCool; }
            set { this.SetProperty(ref _targetCool, value); }
        }

        private double _targetHeat;
        [JsonProperty("t_heat")]
        public double TargetHeat
        {
            get { return _targetHeat; }
            set { this.SetProperty(ref _targetHeat, value); }
        }

        private HvacOperatingStates _HvacOperatingStates;
        [JsonProperty("tstate")]
        public HvacOperatingStates HvacOperatingStates
        {
            get { return _HvacOperatingStates; }
            set { this.SetProperty(ref _HvacOperatingStates, value); }
        }

        private FanOperatingStates _FanOperatingStates;
        [JsonProperty("fstate")]
        public FanOperatingStates FanOperatingState
        {
            get { return _FanOperatingStates; }
            set { this.SetProperty(ref _FanOperatingStates, value); }
        }

        private Time _Time;
        [JsonProperty("time")]
        public Time Time
        {
            get { return _Time; }
            set { this.SetProperty(ref _Time, value); }
        }

        private TTypePosts _TTypePost;
        [JsonProperty("t_type_post")]
        public TTypePosts TTypePost
        {
            get { return _TTypePost; }
            set { this.SetProperty(ref _TTypePost, value); }
        }
    }

    public class Time
    {
        [JsonProperty("day")]
        public Days Day { get; set; }

        [JsonProperty("hour")]
        public int Hour { get; set; }

        [JsonProperty("minute")]
        public int Minute { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1:00}:{2:00}", Day, Hour, Minute);
        }
    }

    public enum Days
    {
        Monday = 0,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
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

    public enum HvacOperatingStates
    {
        Off = 0,
        Heat = 1,
        Cool = 2
    }

    public enum FanOperatingModes
    {
        Auto = 0,
        AutoCirculate = 1,
        On = 2
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
