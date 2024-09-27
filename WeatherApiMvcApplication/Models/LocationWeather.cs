using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiMvcApplication.Models
{
    public class LocationWeather
    {
        public string name { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string tz_id { get; set; }
        public long localtime_epoch { get; set; }
        public DateTime localtime { get; set; }
    }
}
