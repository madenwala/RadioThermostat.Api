﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RadioThermostat.Api.Models
{
    public class Time : ModelBase
    {
        #region Properties

        private Days _Day;
        [JsonProperty("day")]
        public Days Day
        {
            get { return _Day; }
            set
            {
                if(this.SetProperty(ref _Day, value))
                    this.NotifyPropertyChanged(()=>this.TotalMinutes);
            }
        }

        private int _Hour;
        [JsonProperty("hour")]
        public int Hour
        {
            get { return _Hour; }
            set
            {
                if (this.SetProperty(ref _Hour, value))
                    this.NotifyPropertyChanged(() => this.TotalMinutes);
            }
        }

        private int _Minute;
        [JsonProperty("minute")]
        public int Minute
        {
            get { return _Minute; }
            set { this.SetProperty(ref _Minute, value); }
        }

        public int TotalMinutes
        {
            get { return this.Hour * 60 + this.Minute; }
            set
            {
                this.Hour = (int)Math.Floor(value / 60.0f);
                this.Minute = value % 60;
            }
        }

        #endregion

        #region Constructors

        public Time()
        {
        }

        public Time(Days day, int totalMinutes)
        {
            this.Day = day;
            this.TotalMinutes = totalMinutes;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            var dt = DateTime.Today + new TimeSpan(this.Hour, this.Minute, 0);
            return string.Format("{0} {1:t}", Day, dt);
        }

        internal override Dictionary<string, object> GetChangedProperties()
        {
            throw new NotImplementedException();
        }

        public DateTime AsDateTime()
        {
            var now = DateTime.Today;
            return new DateTime(now.Year, now.Month, now.Day, this.Hour, this.Minute, 0);
        }

        #endregion
    }

    #region Enums

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

    #endregion
}