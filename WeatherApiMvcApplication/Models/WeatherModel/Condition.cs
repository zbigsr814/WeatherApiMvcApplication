using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiMvcApplication.Models.WeatherModel
{
    public class Condition
    {
        public string text { get; set; }
        public string icon { get; set; }
        public string imagePath { get; set; }
        public int code { get; set; }
    }
}
