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
            IWeather weatherData = _weatherService.GetData();
            return View(weatherData);
        }
    }
}
