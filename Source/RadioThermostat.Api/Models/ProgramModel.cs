using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RadioThermostat.Api.Models
{
    public class ProgramDayModel : ObservableCollection<double>
    {
        #region Events

        /// <summary>
        /// Multicast event for property change notifications.
        /// </summary>
        public new event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public Days Day { get; internal set; }
        public bool Is4Slot { get { return this.Count / 2 == 4; } }
        public bool Is7Slot { get { return this.Count / 2 == 7; } }

        public ObservableCollection<TimeSpan> Times
        {
            get
            {
                var spans = new ObservableCollection<TimeSpan>();
                for (int i = 0; i < this.Count; i = i + 2)
                    spans.Add(TimeSpan.FromMinutes(this[i]));
                spans.CollectionChanged += (o, e) =>
                {
                    int index = 0;
                    foreach (var span in spans)
                    {
                        this[index] = span.TotalMinutes;
                        index = index + 2;
                    }
                };
                return spans;
            }
        }

        private ObservableCollection<double> temps;
        public ObservableCollection<double> Temps
        {
            get
            {
                if (temps == null)
                {
                    temps = new ObservableCollection<double>();
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
                }
                return temps;
            }
        }

        #endregion

        #region Methods

        public void Refresh()
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Times)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temps)));
        }

        #endregion
    }

    public class ProgramModel : ModelBase
    {
        internal override Dictionary<string, object> GetChangedProperties()
        {
            return null;
        }

        [JsonIgnore()]
        public ObservableCollection<ProgramDayModel> List
        {
            get
            {
                var list = new ObservableCollection<ProgramDayModel>();
                list.Add(this.Monday);
                list.Add(this.Tuesday);
                list.Add(this.Wednesday);
                list.Add(this.Thursday);
                list.Add(this.Friday);
                list.Add(this.Saturday);
                list.Add(this.Sunday);
                return list;
            }
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
            set { this.SetProperty(ref _Monday, value); if(this.Monday != null) this.Monday.Day = Days.Monday; }
        }

        private ProgramDayModel _Tuesday;
        [JsonProperty("1")]
        public ProgramDayModel Tuesday
        {
            get { return _Tuesday; }
            set { this.SetProperty(ref _Tuesday, value); if (this.Tuesday != null) this.Tuesday.Day = Days.Tuesday; }
        }

        private ProgramDayModel _Wednesday;
        [JsonProperty("2")]
        public ProgramDayModel Wednesday
        {
            get { return _Wednesday; }
            set { this.SetProperty(ref _Wednesday, value); if (this.Wednesday != null) this.Wednesday.Day = Days.Wednesday; }
        }

        private ProgramDayModel _Thursday;
        [JsonProperty("3")]
        public ProgramDayModel Thursday
        {
            get { return _Thursday; }
            set { this.SetProperty(ref _Thursday, value); if (this.Thursday != null) this.Thursday.Day = Days.Thursday; }
        }

        private ProgramDayModel _Friday;
        [JsonProperty("4")]
        public ProgramDayModel Friday
        {
            get { return _Friday; }
            set { this.SetProperty(ref _Friday, value); if (this.Friday != null) this.Friday.Day = Days.Friday; }
        }

        private ProgramDayModel _Saturday;
        [JsonProperty("5")]
        public ProgramDayModel Saturday
        {
            get { return _Saturday; }
            set { this.SetProperty(ref _Saturday, value); if (this.Saturday != null) this.Saturday.Day = Days.Saturday; }
        }

        private ProgramDayModel _Sunday;
        [JsonProperty("6")]
        public ProgramDayModel Sunday
        {
            get { return _Sunday; }
            set { this.SetProperty(ref _Sunday, value); if (this.Sunday != null) this.Sunday.Day = Days.Sunday; }
        }
    }
}
