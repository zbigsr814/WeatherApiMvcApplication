using Microsoft.AspNetCore.Mvc;
using WebApiClient;

namespace WeatherApiMvcApplication.Controllers
{
    [Controller]
    public class WeatherController : Controller
    {
        private WeatherService _weatherService;
        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cities()
        {
            List<IWeather> weatherData = new List<IWeather>()
            {
                _weatherService.GetData("krakow"),
				_weatherService.GetData("warszawa"),
				_weatherService.GetData("gdansk"),
				_weatherService.GetData("katowice"),
		};
            return View(weatherData);
        }
    }
}
