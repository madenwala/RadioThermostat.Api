using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioThermostat.Api.Models
{
    public sealed class TStat : ModelBase
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("tmode")]
        public int Tmode { get; set; }

        [JsonProperty("fmode")]
        public int Fmode { get; set; }

        [JsonProperty("override")]
        public int @Override { get; set; }

        [JsonProperty("hold")]
        public int Hold { get; set; }

        [JsonProperty("t_heat")]
        public double THeat { get; set; }

        [JsonProperty("tstate")]
        public int Tstate { get; set; }

        [JsonProperty("fstate")]
        public int Fstate { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }

        [JsonProperty("t_type_post")]
        public int TTypePost { get; set; }
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
}
