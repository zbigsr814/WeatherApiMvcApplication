using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiMvcApplication.Models
{
    public class ConditionWeather
    {
        public string text { get; set; }
        public string icon { get; set; }
        public int code { get; set; }
    }
}
