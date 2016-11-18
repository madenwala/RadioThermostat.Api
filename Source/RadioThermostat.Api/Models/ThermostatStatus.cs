using System.Collections.Generic;
using Newtonsoft.Json;

namespace RadioThermostat.Api.Models
{
    public class ThermostatResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public sealed class ThermostatStatus : ModelBase
    {
        #region Properties

        private double _currentTemp;
        [JsonProperty("temp")]
        public double CurrentTemperature
        {
            get { return _currentTemp; }
            set { this.SetProperty(ref _currentTemp, value); }
        }

        private ThermostatModes _mode;
        [JsonProperty("tmode")]
        public ThermostatModes Mode
        {
            get { return _mode; }
            set
            {
                if(this.SetProperty(ref _mode, value))
                {
                    this.NotifyPropertyChanged(() => this.IsModeOff);
                    this.NotifyPropertyChanged(() => this.IsModeHeat);
                    this.NotifyPropertyChanged(() => this.IsModeCool);
                    this.NotifyPropertyChanged(() => this.IsModeAuto);
                    this.NotifyPropertyChanged(() => this.TargetTemperature);
                }
            }
        }

        private FanOperatingModes _FanOperatingMode;
        [JsonProperty("fmode")]
        public FanOperatingModes FanOperatingMode
        {
            get { return _FanOperatingMode; }
            set
            {
                if(this.SetProperty(ref _FanOperatingMode, value))
                {
                    this.NotifyPropertyChanged(() => this.IsFanAuto);
                    this.NotifyPropertyChanged(() => this.IsFanAutoCirculate);
                    this.NotifyPropertyChanged(() => this.IsFanOn);
                }
            }
        }

        private bool _Override;
        [JsonProperty("override")]
        public bool @Override
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
        public double TargetTemperatureCool
        {
            get { return _targetCool; }
            set
            {
                if (this.SetProperty(ref _targetCool, value))
                    this.NotifyPropertyChanged(() => this.TargetTemperature);
            }
        }

        private double _targetHeat;
        [JsonProperty("t_heat")]
        public double TargetTemperatureHeat
        {
            get { return _targetHeat; }
            set
            {
                if (this.SetProperty(ref _targetHeat, value))
                    this.NotifyPropertyChanged(() => this.TargetTemperature);
            }
        }

        private HvacOperatingStates _HvacOperatingStates;
        [JsonProperty("tstate")]
        public HvacOperatingStates HvacOperatingStates
        {
            get { return _HvacOperatingStates; }
            set { this.SetProperty(ref _HvacOperatingStates, value); }
        }

        private bool _FanOperatingStates;
        [JsonProperty("fstate")]
        public bool FanOperatingState
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

        //private TTypePosts _TTypePost;
        //[JsonProperty("t_type_post")]
        //public TTypePosts TTypePost
        //{
        //    get { return _TTypePost; }
        //    set { this.SetProperty(ref _TTypePost, value); }
        //}

        public bool IsModeOff { get { return this.Mode == ThermostatModes.Off; } set { if (value) this.Mode = ThermostatModes.Off; } }
        public bool IsModeHeat { get { return this.Mode == ThermostatModes.Heat; } set { if (value) this.Mode = ThermostatModes.Heat; } }
        public bool IsModeCool { get { return this.Mode == ThermostatModes.Cool; } set { if (value) this.Mode = ThermostatModes.Cool; } }
        public bool IsModeAuto { get { return this.Mode == ThermostatModes.Auto; } set { if (value) this.Mode = ThermostatModes.Auto; } }

        public bool IsFanAuto { get { return this.FanOperatingMode == FanOperatingModes.Auto; } set { if (value) this.FanOperatingMode = FanOperatingModes.Auto; } }
        public bool IsFanAutoCirculate { get { return this.FanOperatingMode == FanOperatingModes.AutoCirculate; } set { if (value) this.FanOperatingMode = FanOperatingModes.AutoCirculate; } }
        public bool IsFanOn { get { return this.FanOperatingMode == FanOperatingModes.On; } set { if (value) this.FanOperatingMode = FanOperatingModes.On; } }

        #endregion
        
        public double TargetTemperature
        {
            get
            {
                switch(this.Mode)
                {
                    case ThermostatModes.Heat:
                        return this.TargetTemperatureHeat;
                    case ThermostatModes.Cool:
                        return this.TargetTemperatureCool;
                    case ThermostatModes.Auto:
                        if (this.HvacOperatingStates == HvacOperatingStates.Heat)
                            return this.TargetTemperatureHeat;
                        else if (this.HvacOperatingStates == HvacOperatingStates.Cool)
                            return this.TargetTemperatureCool;
                        else
                            return 0;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (this.Mode)
                {
                    case ThermostatModes.Heat:
                        this.TargetTemperatureHeat = value;
                        break;

                    case ThermostatModes.Cool:
                        this.TargetTemperatureCool = value;
                        break;

                    case ThermostatModes.Auto:
                        this.TargetTemperatureCool = value;
                        this.TargetTemperatureHeat = value;
                        break;
                }
            }
        }

        #region Methods

        internal override Dictionary<string, object> GetChangedProperties()
        {
            var dic = new Dictionary<string, object>();

            foreach (var property in _changedProperties)
            {
                switch (property)
                {
                    case nameof(Mode):
                        dic.Add("tmode", (int)this.Mode);
                        break;

                    case nameof(TargetTemperatureHeat):
                        dic.Add("t_heat", this.TargetTemperatureHeat);
                        break;

                    case nameof(TargetTemperatureCool):
                        dic.Add("t_cool", this.TargetTemperatureCool);
                        break;

                    case nameof(Hold):
                        dic.Add("hold", this.Hold ? 1 : 0);
                        break;

                    case nameof(FanOperatingMode):
                        dic.Add("fmode", (int)this.FanOperatingMode);
                        break;

                    case nameof(FanOperatingState):
                        dic.Add("fstate", this.FanOperatingState ? 1 : 0);
                        break;
                }
            }

            return dic;
        }

        #endregion
    }

    #region Enums

    public enum ThermostatModes
    {
        Off = 0,
        Heat = 1,
        Cool = 2,
        Auto = 3
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

    //public enum TTypePosts
    //{
    //    TemporaryTarget = 0,
    //    AbsoluteTarget = 1,
    //    Unknown = 2
    //}

    #endregion
}