using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiMvcApplication.Models;

namespace WebApiClient
{
    public interface IWeather
    {
        LocationWeather location { get; set; }
        CurrentWeather current { get; set; }
    }
}
