using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace WeatherApiMvcApplication.Models
{
    public class WeatherModel : IWeather
    {
        public LocationWeather location { get; set; }
        public CurrentWeather current { get; set; }
	}
}
