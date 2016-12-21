using Newtonsoft.Json;
using System;
using System.Linq;
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

        internal ObservableCollection<TimeSpan> Times
        {
            get
            {
                var spans = new ObservableCollection<TimeSpan>();
                for (int i = 0; i < this.Count; i = i + 2)
                    spans.Add(TimeSpan.FromMinutes(this[i]));
                return spans;
            }
        }
        
        internal ObservableCollection<double> Temps
        {
            get
            {
                var temps = new ObservableCollection<double>();
                for (int i = 1; i < this.Count; i = i + 2)
                    temps.Add(this[i]);
                return temps;
            }
        }

        public double Temp1 { get { return this[1]; } set { this[1] = value; } }
        public double Temp2 { get { return this[3]; } set { this[3] = value; } }
        public double Temp3 { get { return this[5]; } set { this[5] = value; } }
        public double Temp4 { get { return this[7]; } set { this[7] = value; } }
        public double Temp5 { get { return this[9]; } set { this[9] = value; } }
        public double Temp6 { get { return this[11]; } set { this[11] = value; } }
        public double Temp7 { get { return this[13]; } set { this[13] = value; } }

        public TimeSpan Time1 { get { return TimeSpan.FromMinutes(this[0]); } set { if (this[0] != value.TotalMinutes) this[0] = value.TotalMinutes; } }
        public TimeSpan Time2 { get { return TimeSpan.FromMinutes(this[2]); } set { if (this[2] != value.TotalMinutes) this[2] = value.TotalMinutes; } }
        public TimeSpan Time3 { get { return TimeSpan.FromMinutes(this[4]); } set { if (this[4] != value.TotalMinutes) this[4] = value.TotalMinutes; } }
        public TimeSpan Time4 { get { return TimeSpan.FromMinutes(this[6]); } set { if (this[6] != value.TotalMinutes) this[6] = value.TotalMinutes; } }
        public TimeSpan Time5 { get { return TimeSpan.FromMinutes(this[8]); } set { if (this[8] != value.TotalMinutes) this[8] = value.TotalMinutes; } }
        public TimeSpan Time6 { get { return TimeSpan.FromMinutes(this[10]); } set { if (this[10] != value.TotalMinutes) this[10] = value.TotalMinutes; } }
        public TimeSpan Time7 { get { return TimeSpan.FromMinutes(this[12]); } set { if (this[12] != value.TotalMinutes) this[12] = value.TotalMinutes; } }

        #endregion

        #region Methods

        public void UpdateProperties()
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Times)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temps)));

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temp1)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temp2)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temp3)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temp4)));

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time1)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time2)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time3)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time4)));

            if (this.Is7Slot)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temp5)));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temp6)));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temp7)));

                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time5)));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time6)));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time7)));
            }
        }

        public void Copy(ProgramDayModel model)
        {
            if (this.Count == model?.Count)
            {
                for (int i = 0; i < model.Count; i++)
                    this[i] = model[i];
                this.UpdateProperties();
            }
        }

        #endregion
    }

    public class ProgramModel : ModelBase
    {
        #region Properties

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

        private ProgramDayModel this[int day]
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

        private ProgramDayModel this[Days day]
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

        #endregion

        #region Methods

        internal override Dictionary<string, object> GetChangedProperties()
        {
            return null;
        }

        public void CopyProgram(Days from, Days to)
        {
            var fromDay = this[from];
            var toDay = this[to];
            toDay.Copy(fromDay);
        }

        public Tuple<string, double> GetNextProgramChange(DateTime dt)
        {
            var pd = this.List.First(f => f.Day == DateTimeHelper.ConvertDateTimeDayOfWeek(dt.DayOfWeek));
            var tsNow = new TimeSpan(dt.Hour, dt.Minute, 0);

            if (pd != null && pd.Times.Last() < tsNow)
            {
                var index = (this.List.IndexOf(pd) + 1) % 7;
                pd = this.List[index];
            }

            if (pd != null)
            {
                for (int i = 0; i < pd.Times.Count; i++)
                {
                    if (pd.Times[i] > tsNow)
                        return new Tuple<string, double>(this.FormatTimeSpanToTime(pd.Times[i]), pd.Temps[i]);
                }
            }

            return null;
        }

        private string FormatTimeSpanToTime(TimeSpan ts)
        {
            var dt = DateTime.Today + ts;
            return dt.ToString("t");
        }

        #endregion
    }
}
