using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioThermostat.Api.Models
{
    public class Time : ModelBase
    {
        private Days _Day;
        [JsonProperty("day")]
        public Days Day
        {
            get { return _Day; }
            set { this.SetProperty(ref _Day, value); }
        }

        private int _Hour;
        [JsonProperty("hour")]
        public int Hour
        {
            get { return _Hour; }
            set { this.SetProperty(ref _Hour, value); }
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

        public Time()
        {
        }

        public Time(Days day, int totalMinutes)
        {
            this.Day = day;
            this.TotalMinutes = totalMinutes;
        }

        public override string ToString()
        {
            return string.Format("{0} {1:00}:{2:00}", Day, Hour, Minute);
        }

        internal override Dictionary<string, object> GetChangedProperties()
        {
            throw new NotImplementedException();
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
}
