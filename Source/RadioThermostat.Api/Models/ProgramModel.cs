using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RadioThermostat.Api.Models
{
    public class ProgramDayModel : ObservableCollection<double>
    {
        public bool Is4Slot { get { return this.Count / 2 == 4; } }
        public bool Is7Slot { get { return this.Count / 2 == 7; } }

        public ObservableCollection<DateTime> Times
        {
            get
            {
                var times = new ObservableCollection<DateTime>();
                for (int i = 0; i < this.Count; i = i + 2)
                {
                    var now = DateTime.Now;
                    var dt = new DateTime(now.Year, now.Month, now.Day, (int)Math.Floor(this[i] / 60), (int)this[i] % 60, 0);
                    dt.AddMinutes(this[i]);
                    times.Add(dt);
                }
                times.CollectionChanged += (o, e) =>
                {
                    int index = 0;
                    foreach (var time in times)
                    {
                        this[index] = time.Hour * 60 + time.Minute;
                        index = index + 2;
                    }
                };
                return times;
            }
        }

        public ObservableCollection<double> Temps
        {
            get
            {
                var temps = new ObservableCollection<double>();
                for (int i = 1; i < this.Count; i = i + 2)
                    temps.Add(this[i]);
                temps.CollectionChanged += (o, e) =>
                {
                    int index = 1;
                    foreach (var temp in temps)
                    {
                        this[index] = temp;
                        index = index + 2;
                    }
                };
                return temps;
            }
        }
    }

    public class ProgramModel : ModelBase
    {
        internal override Dictionary<string, object> GetChangedProperties()
        {
            return null;
        }

        public ProgramDayModel this[int day]
        {
            get
            {
                switch(day)
                {
                    case 0: return this.Monday;
                    case 1: return this.Tuesday;
                    case 2: return this.Wednesday;
                    case 3: return this.Thursday;
                    case 4: return this.Friday;
                    case 5: return this.Saturday;
                    case 6: return this.Sunday;
                    default: throw new ArgumentOutOfRangeException(nameof(day));
                }
            }
        }

        public ProgramDayModel this[Days day]
        {
            get
            {
                return this[(int)day];
            }
        }

        private ProgramDayModel _Monday;
        [JsonProperty("0")]
        public ProgramDayModel Monday
        {
            get { return _Monday; }
            set { this.SetProperty(ref _Monday, value); }
        }

        private ProgramDayModel _Tuesday;
        [JsonProperty("1")]
        public ProgramDayModel Tuesday
        {
            get { return _Tuesday; }
            set { this.SetProperty(ref _Tuesday, value); }
        }

        private ProgramDayModel _Wednesday;
        [JsonProperty("2")]
        public ProgramDayModel Wednesday
        {
            get { return _Wednesday; }
            set { this.SetProperty(ref _Wednesday, value); }
        }

        private ProgramDayModel _Thursday;
        [JsonProperty("3")]
        public ProgramDayModel Thursday
        {
            get { return _Thursday; }
            set { this.SetProperty(ref _Thursday, value); }
        }

        private ProgramDayModel _Friday;
        [JsonProperty("4")]
        public ProgramDayModel Friday
        {
            get { return _Friday; }
            set { this.SetProperty(ref _Friday, value); }
        }

        private ProgramDayModel _Saturday;
        [JsonProperty("5")]
        public ProgramDayModel Saturday
        {
            get { return _Saturday; }
            set { this.SetProperty(ref _Saturday, value); }
        }

        private ProgramDayModel _Sunday;
        [JsonProperty("6")]
        public ProgramDayModel Sunday
        {
            get { return _Sunday; }
            set { this.SetProperty(ref _Sunday, value); }
        }
    }
}
