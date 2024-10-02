using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiMvcApplication.Models;
using WeatherApiMvcApplication.Models.WeatherModel;

namespace WebApiClient
{
    public interface IWeather
    {
        Location location { get; set; }
        Current current { get; set; }
		public Forecast forecast { get; set; }
	}
}
