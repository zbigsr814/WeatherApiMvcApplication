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
                weatherData.Add(await _weatherService.GetData(searchingText));
            }
            else
            {
				weatherData.AddRange(
                new List<IWeather>()
                {
					await _weatherService.GetData("krakow"),
				    await _weatherService.GetData("warszawa"),
				    await _weatherService.GetData("gdansk"),
				    await _weatherService.GetData("sucha beskidzka")
				}
			   );
			}

            return View(weatherData);
        }

   //     public async Task<IActionResult> Search([FromQuery] string searchingText = null)
   //     {
			//var referer = Request.Headers["Referer"].ToString();
			//if (searchingText == null) return RedirectToAction(referer);

   //         List<IWeather> weatherData = new List<IWeather>()
   //         {
			//	await _weatherService.GetData(searchingText);
		 //   };
   //         return RedirectToAction(referer, );
	  //  }
    }
}
