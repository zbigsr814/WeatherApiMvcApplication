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
                IWeather weather = await _weatherService.GetWeather(searchingText);

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

			_weatherService.ClearImagesFolder();
            weatherData.AddRange(
            new List<IWeather>()
            {
				await _weatherService.GetWeather("krakow"),
				await _weatherService.GetWeather("warszawa"),
				await _weatherService.GetWeather("gdansk"),
				await _weatherService.GetWeather("sucha beskidzka")
			}
			);

            return View(weatherData);
        }

		public async Task<IActionResult> Forecast([FromQuery] string searchingText = null)
        {
			List<IWeather> weatherData = new List<IWeather>();

			if (searchingText != null)
			{
				IWeather weather = await _weatherService.GetWeather(searchingText, 3);

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

			_weatherService.ClearImagesFolder();
            weatherData.AddRange(
			new List<IWeather>()
			{
				await _weatherService.GetWeather("krakow", 3),
				await _weatherService.GetWeather("warszawa", 3),
				await _weatherService.GetWeather("gdansk", 3),
				await _weatherService.GetWeather("sucha beskidzka", 3)
			}
			);

			return View(weatherData);
		}
	}
}
