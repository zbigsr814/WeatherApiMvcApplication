using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using WeatherApiMvcApplication.Services;
using WebApiClient;

namespace WeatherApiMvcApplication.Controllers
{
    [Controller]
    public class WeatherController : Controller
    {
        private WeatherService _weatherService;
        private ForecastService _forecastService;
        public WeatherController(WeatherService weatherService, ForecastService forecastService)
        {
            _weatherService = weatherService;
            _forecastService = forecastService;
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
                IWeather weather = await _weatherService.GetActualWeather(searchingText);

                if (weather != null)
                {
					weatherData.Add(weather);
				}
                else
                {
					weatherData.Add(null);
				}
				return View(weatherData);
			}

			weatherData.AddRange(
            new List<IWeather>()
            {
				await _weatherService.GetActualWeather("krakow"),
				await _weatherService.GetActualWeather("warszawa"),
				await _weatherService.GetActualWeather("gdansk"),
				await _weatherService.GetActualWeather("sucha beskidzka")
			}
			);

            return View(weatherData);
        }

		public async Task<IActionResult> Forecast([FromQuery] string searchingText = null)
        {
			List<IWeather> weatherData = new List<IWeather>();

			if (searchingText != null)
			{
				IWeather weather = await _weatherService.GetActualWeather(searchingText, 3);

				if (weather != null)
				{
					weatherData.Add(weather);
				}
				else
				{
					weatherData.Add(null);
				}
				return View(weatherData);
			}

			weatherData.AddRange(
			new List<IWeather>()
			{
				await _weatherService.GetActualWeather("krakow", 3),
				await _weatherService.GetActualWeather("warszawa", 3),
				await _weatherService.GetActualWeather("gdansk", 3),
				await _weatherService.GetActualWeather("sucha beskidzka", 3)
			}
			);

			return View(weatherData);
		}
	}
}
