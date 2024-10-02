using WebApiClient;

namespace WeatherApiMvcApplication.Models.WeatherModel
{
	public class WeatherData : IWeather
	{
		public Location location { get; set; }
		public Current current { get; set; }
		public Forecast forecast { get; set; }
	}
}
