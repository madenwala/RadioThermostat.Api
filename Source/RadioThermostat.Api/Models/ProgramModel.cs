using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RadioThermostat.Api.Models
{
    public class ProgramModel : ModelBase
    {
        internal override Dictionary<string, object> GetChangedProperties()
        {
            throw new NotImplementedException();
        }

        #region Monday

        private List<int> _Monday;
        [JsonProperty("0")]
        public List<int> Monday
        {
            get { return _Monday; }
            set { this.SetProperty(ref _Monday, value); }
        }
        
        public Time MondayTime1
        {
            get { return new Time(Days.Monday, this.Monday[0]); }
            set { if(this.Monday[0] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Monday); }
        }
        public int MondayTemp1
        {
            get { return this.Monday[1]; }
            set { if (this.Monday[1] != value) this.NotifyPropertyChanged(() => this.Monday); }
        }

        public Time MondayTime2
        {
            get { return new Time(Days.Monday, this.Monday[2]); }
            set { if (this.Monday[2] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Monday); }
        }
        public int MondayTemp2
        {
            get { return this.Monday[3]; }
            set { if (this.Monday[3] != value) this.NotifyPropertyChanged(() => this.Monday); }
        }

        public Time MondayTime3
        {
            get { return new Time(Days.Monday, this.Monday[4]); }
            set { if (this.Monday[4] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Monday); }
        }
        public int MondayTemp3
        {
            get { return this.Monday[5]; }
            set { if (this.Monday[5] != value) this.NotifyPropertyChanged(() => this.Monday); }
        }

        public Time MondayTime4
        {
            get { return new Time(Days.Monday, this.Monday[6]); }
            set { if (this.Monday[6] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Monday); }
        }
        public int MondayTemp4
        {
            get { return this.Monday[7]; }
            set { if (this.Monday[7] != value) this.NotifyPropertyChanged(() => this.Monday); }
        }

        #endregion

        #region Tuesday

        private List<int> _Tuesday;
        [JsonProperty("1")]
        public List<int> Tuesday
        {
            get { return _Tuesday; }
            set { this.SetProperty(ref _Tuesday, value); }
        }

        public Time TuesdayTime1
        {
            get { return new Time(Days.Tuesday, this.Tuesday[0]); }
            set { if (this.Tuesday[0] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Tuesday); }
        }
        public int TuesdayTemp1
        {
            get { return this.Tuesday[1]; }
            set { if (this.Tuesday[1] != value) this.NotifyPropertyChanged(() => this.Tuesday); }
        }

        public Time TuesdayTime2
        {
            get { return new Time(Days.Tuesday, this.Tuesday[2]); }
            set { if (this.Tuesday[2] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Tuesday); }
        }
        public int TuesdayTemp2
        {
            get { return this.Tuesday[3]; }
            set { if (this.Tuesday[3] != value) this.NotifyPropertyChanged(() => this.Tuesday); }
        }

        public Time TuesdayTime3
        {
            get { return new Time(Days.Tuesday, this.Tuesday[4]); }
            set { if (this.Tuesday[4] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Tuesday); }
        }
        public int TuesdayTemp3
        {
            get { return this.Tuesday[5]; }
            set { if (this.Tuesday[5] != value) this.NotifyPropertyChanged(() => this.Tuesday); }
        }

        public Time TuesdayTime4
        {
            get { return new Time(Days.Tuesday, this.Tuesday[6]); }
            set { if (this.Tuesday[6] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Tuesday); }
        }
        public int TuesdayTemp4
        {
            get { return this.Tuesday[7]; }
            set { if (this.Tuesday[7] != value) this.NotifyPropertyChanged(() => this.Tuesday); }
        }

        #endregion

        #region Wednesday

        private List<int> _Wednesday;
        [JsonProperty("2")]
        public List<int> Wednesday
        {
            get { return _Wednesday; }
            set { this.SetProperty(ref _Wednesday, value); }
        }

        public Time WednesdayTime1
        {
            get { return new Time(Days.Wednesday, this.Wednesday[0]); }
            set { if (this.Wednesday[0] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Wednesday); }
        }
        public int WednesdayTemp1
        {
            get { return this.Wednesday[1]; }
            set { if (this.Wednesday[1] != value) this.NotifyPropertyChanged(() => this.Wednesday); }
        }

        public Time WednesdayTime2
        {
            get { return new Time(Days.Wednesday, this.Wednesday[2]); }
            set { if (this.Wednesday[2] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Wednesday); }
        }
        public int WednesdayTemp2
        {
            get { return this.Wednesday[3]; }
            set { if (this.Wednesday[3] != value) this.NotifyPropertyChanged(() => this.Wednesday); }
        }

        public Time WednesdayTime3
        {
            get { return new Time(Days.Wednesday, this.Wednesday[4]); }
            set { if (this.Wednesday[4] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Wednesday); }
        }
        public int WednesdayTemp3
        {
            get { return this.Wednesday[5]; }
            set { if (this.Wednesday[5] != value) this.NotifyPropertyChanged(() => this.Wednesday); }
        }

        public Time WednesdayTime4
        {
            get { return new Time(Days.Wednesday, this.Wednesday[6]); }
            set { if (this.Wednesday[6] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Wednesday); }
        }
        public int WednesdayTemp4
        {
            get { return this.Wednesday[7]; }
            set { if (this.Wednesday[7] != value) this.NotifyPropertyChanged(() => this.Wednesday); }
        }

        #endregion

        #region Thursday

        private List<int> _Thursday;
        [JsonProperty("3")]
        public List<int> Thursday
        {
            get { return _Thursday; }
            set { this.SetProperty(ref _Thursday, value); }
        }

        public Time ThursdayTime1
        {
            get { return new Time(Days.Thursday, this.Thursday[0]); }
            set { if (this.Thursday[0] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Thursday); }
        }
        public int ThursdayTemp1
        {
            get { return this.Thursday[1]; }
            set { if (this.Thursday[1] != value) this.NotifyPropertyChanged(() => this.Thursday); }
        }

        public Time ThursdayTime2
        {
            get { return new Time(Days.Thursday, this.Thursday[2]); }
            set { if (this.Thursday[2] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Thursday); }
        }
        public int ThursdayTemp2
        {
            get { return this.Thursday[3]; }
            set { if (this.Thursday[3] != value) this.NotifyPropertyChanged(() => this.Thursday); }
        }

        public Time ThursdayTime3
        {
            get { return new Time(Days.Thursday, this.Thursday[4]); }
            set { if (this.Thursday[4] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Thursday); }
        }
        public int ThursdayTemp3
        {
            get { return this.Thursday[5]; }
            set { if (this.Thursday[5] != value) this.NotifyPropertyChanged(() => this.Thursday); }
        }

        public Time ThursdayTime4
        {
            get { return new Time(Days.Thursday, this.Thursday[6]); }
            set { if (this.Thursday[6] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Thursday); }
        }
        public int ThursdayTemp4
        {
            get { return this.Thursday[7]; }
            set { if (this.Thursday[7] != value) this.NotifyPropertyChanged(() => this.Thursday); }
        }

        #endregion

        #region Friday

        private List<int> _Friday;
        [JsonProperty("4")]
        public List<int> Friday
        {
            get { return _Friday; }
            set { this.SetProperty(ref _Friday, value); }
        }

        public Time FridayTime1
        {
            get { return new Time(Days.Friday, this.Friday[0]); }
            set { if (this.Friday[0] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Friday); }
        }
        public int FridayTemp1
        {
            get { return this.Friday[1]; }
            set { if (this.Friday[1] != value) this.NotifyPropertyChanged(() => this.Friday); }
        }

        public Time FridayTime2
        {
            get { return new Time(Days.Friday, this.Friday[2]); }
            set { if (this.Friday[2] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Friday); }
        }
        public int FridayTemp2
        {
            get { return this.Friday[3]; }
            set { if (this.Friday[3] != value) this.NotifyPropertyChanged(() => this.Friday); }
        }

        public Time FridayTime3
        {
            get { return new Time(Days.Friday, this.Friday[4]); }
            set { if (this.Friday[4] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Friday); }
        }
        public int FridayTemp3
        {
            get { return this.Friday[5]; }
            set { if (this.Friday[5] != value) this.NotifyPropertyChanged(() => this.Friday); }
        }

        public Time FridayTime4
        {
            get { return new Time(Days.Friday, this.Friday[6]); }
            set { if (this.Friday[6] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Friday); }
        }
        public int FridayTemp4
        {
            get { return this.Friday[7]; }
            set { if (this.Friday[7] != value) this.NotifyPropertyChanged(() => this.Friday); }
        }

        #endregion

        #region Saturday

        private List<int> _Saturday;
        [JsonProperty("5")]
        public List<int> Saturday
        {
            get { return _Saturday; }
            set { this.SetProperty(ref _Saturday, value); }
        }

        public Time SaturdayTime1
        {
            get { return new Time(Days.Saturday, this.Saturday[0]); }
            set { if (this.Saturday[0] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Saturday); }
        }
        public int SaturdayTemp1
        {
            get { return this.Saturday[1]; }
            set { if (this.Saturday[1] != value) this.NotifyPropertyChanged(() => this.Saturday); }
        }

        public Time SaturdayTime2
        {
            get { return new Time(Days.Saturday, this.Saturday[2]); }
            set { if (this.Saturday[2] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Saturday); }
        }
        public int SaturdayTemp2
        {
            get { return this.Saturday[3]; }
            set { if (this.Saturday[3] != value) this.NotifyPropertyChanged(() => this.Saturday); }
        }

        public Time SaturdayTime3
        {
            get { return new Time(Days.Saturday, this.Saturday[4]); }
            set { if (this.Saturday[4] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Saturday); }
        }
        public int SaturdayTemp3
        {
            get { return this.Saturday[5]; }
            set { if (this.Saturday[5] != value) this.NotifyPropertyChanged(() => this.Saturday); }
        }

        public Time SaturdayTime4
        {
            get { return new Time(Days.Saturday, this.Saturday[6]); }
            set { if (this.Saturday[6] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Saturday); }
        }
        public int SaturdayTemp4
        {
            get { return this.Saturday[7]; }
            set { if (this.Saturday[7] != value) this.NotifyPropertyChanged(() => this.Saturday); }
        }

        #endregion

        #region Sunday

        private List<int> _Sunday;
        [JsonProperty("6")]
        public List<int> Sunday
        {
            get { return _Sunday; }
            set { this.SetProperty(ref _Sunday, value); }
        }

        public Time SundayTime1
        {
            get { return new Time(Days.Sunday, this.Sunday[0]); }
            set { if (this.Sunday[0] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Sunday); }
        }
        public int SundayTemp1
        {
            get { return this.Sunday[1]; }
            set { if (this.Sunday[1] != value) this.NotifyPropertyChanged(() => this.Sunday); }
        }

        public Time SundayTime2
        {
            get { return new Time(Days.Sunday, this.Sunday[2]); }
            set { if (this.Sunday[2] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Sunday); }
        }
        public int SundayTemp2
        {
            get { return this.Sunday[3]; }
            set { if (this.Sunday[3] != value) this.NotifyPropertyChanged(() => this.Sunday); }
        }

        public Time SundayTime3
        {
            get { return new Time(Days.Sunday, this.Sunday[4]); }
            set { if (this.Sunday[4] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Sunday); }
        }
        public int SundayTemp3
        {
            get { return this.Sunday[5]; }
            set { if (this.Sunday[5] != value) this.NotifyPropertyChanged(() => this.Sunday); }
        }

        public Time SundayTime4
        {
            get { return new Time(Days.Sunday, this.Sunday[6]); }
            set { if (this.Sunday[6] != value?.TotalMinutes) this.NotifyPropertyChanged(() => this.Sunday); }
        }
        public int SundayTemp4
        {
            get { return this.Sunday[7]; }
            set { if (this.Sunday[7] != value) this.NotifyPropertyChanged(() => this.Sunday); }
        }

        #endregion
    }
}
