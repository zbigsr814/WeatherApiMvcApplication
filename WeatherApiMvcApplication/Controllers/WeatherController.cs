using Microsoft.AspNetCore.Components.RenderTree;
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

        public async Task<IActionResult> Cities([FromQuery] string searchingText = null)
        {

            List<IWeather> weatherData = new List<IWeather>();

            if (searchingText != null)
            {
                IWeather weather = await _weatherService.GetData(searchingText);

                if (weather != null)
                {
					weatherData.Add(weather);
					return View(weatherData);
				}
            }

			weatherData.AddRange(
            new List<IWeather>()
            {
				await _weatherService.GetData("krakow"),
				await _weatherService.GetData("warszawa"),
				await _weatherService.GetData("gdansk"),
				await _weatherService.GetData("sucha beskidzka")
			}
			);

            return View(weatherData);
        }
    }
}
