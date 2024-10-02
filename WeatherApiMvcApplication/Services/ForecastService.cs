using Newtonsoft.Json;
using System.Text;
using WeatherApiMvcApplication.Models.WeatherModel;
using WebApiClient;

namespace WeatherApiMvcApplication.Services
{
	public class ForecastService
	{
		private readonly IWebHostEnvironment _webHostEnvironment;

		// Konstruktor z wstrzykniętym IWebHostEnvironment
		public ForecastService(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<IWeather> GetForecastWeather(string city)
		{
			var httpClient = new HttpClient();

			var normalCityToFind = RemoveSigns(city);

			using (UrlBuilder urlBuilder = new UrlBuilder(Consts.url, city))
			{
				string apiUrl = urlBuilder.ReturnUrl();
				var dataFromSite = httpClient.GetAsync(apiUrl).Result;
				var responseFromSite = dataFromSite.Content.ReadAsStringAsync().Result;
				IWeather deserializedData = JsonConvert.DeserializeObject<WeatherData>(responseFromSite);     // tworzenie podstawowego obiektu

				if (deserializedData.location == null) return null;
				deserializedData.location.name = ShortenCityName(deserializedData.location.name, city);     // korekta nazwy miasta
				//deserializedData.current.condition.imagePath = await SaveImage($"https:{deserializedData.current.condition.icon}", city);   // zapisanie ikony pogody

				// if (deserializedData.current == null)

				return deserializedData;
			}
		}

		private string ShortenCityName(string cityFromJson, string inputFromUserCity)
		{
			string shortenCity = null;

			for (int i = 0; i < inputFromUserCity.Length; i++)
			{
				shortenCity += cityFromJson[i];
			}

			return shortenCity;
		}

		string RemoveSigns(string text)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in text)
			{
				switch (c)
				{
					case 'ą': stringBuilder.Append('a'); break;
					case 'ć': stringBuilder.Append('c'); break;
					case 'ę': stringBuilder.Append('e'); break;
					case 'ł': stringBuilder.Append('l'); break;
					case 'ń': stringBuilder.Append('n'); break;
					case 'ó': stringBuilder.Append('o'); break;
					case 'ś': stringBuilder.Append('s'); break;
					case 'ź': stringBuilder.Append('z'); break;
					case 'ż': stringBuilder.Append('z'); break;
					case 'Ą': stringBuilder.Append('A'); break;
					case 'Ć': stringBuilder.Append('C'); break;
					case 'Ę': stringBuilder.Append('E'); break;
					case 'Ł': stringBuilder.Append('L'); break;
					case 'Ń': stringBuilder.Append('N'); break;
					case 'Ó': stringBuilder.Append('O'); break;
					case 'Ś': stringBuilder.Append('S'); break;
					case 'Ź': stringBuilder.Append('Z'); break;
					case 'Ż': stringBuilder.Append('Z'); break;
					default: stringBuilder.Append(c); break;
				}
			}
			return stringBuilder.ToString();
		}
	}
}
