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

        public async Task<IActionResult> Cities()
        {
            List<IWeather> weatherData = new List<IWeather>()
            {
                await _weatherService.GetData("krakow"),
				await _weatherService.GetData("warszawa"),
				await _weatherService.GetData("gdansk"),
				await _weatherService.GetData("barcelona"),
		};
            return View(weatherData);
        }
    }
}
