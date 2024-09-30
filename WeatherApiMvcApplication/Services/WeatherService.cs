using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApiMvcApplication.Models;

namespace WebApiClient
{
    public class WeatherService
    {
		private readonly IWebHostEnvironment _webHostEnvironment;

		// Konstruktor z wstrzykniętym IWebHostEnvironment
		public WeatherService(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<IWeather> GetData(string city)
        {
            var httpClient = new HttpClient();

            var normalCityToFind = RemoveSigns(city);

            using (UrlBuilder urlBuilder = new UrlBuilder(Consts.url, city))
            {
                string apiUrl = urlBuilder.ReturnUrl();
                var dataFromSite = httpClient.GetAsync(apiUrl).Result;
                var responseFromSite = dataFromSite.Content.ReadAsStringAsync().Result;
                IWeather deserializedData = JsonConvert.DeserializeObject<WeatherModel>(responseFromSite);     // tworzenie podstawowego obiektu

                deserializedData.location.name = ShortenCityName(deserializedData.location.name, city);
                deserializedData.current.condition.imagePath = await SaveImage($"https:{deserializedData.current.condition.icon}", city);   // zapisanie ikony pogody

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

		public async Task<string> SaveImage(string url, string city)
		{
			// Pobranie ścieżki do folderu wwwroot
			var wwwRootPath = _webHostEnvironment.WebRootPath;

			// Połączenie ścieżki wwwroot z folderem images
			var imagesPath = Path.Combine(wwwRootPath, $"images/weatherIcons");

			// Tworzenie katalogu, jeśli nie istnieje
			Directory.CreateDirectory(imagesPath);

            // Pełna ścieżka do zapisu pliku
            city = city.Replace(" ", "_");
			string outputFile = Path.Combine(imagesPath, $"image_{city}.jpg");

			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();

				using (var stream = await response.Content.ReadAsStreamAsync())
				using (var fileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
				{
					await stream.CopyToAsync(fileStream);
				}
			}

			// Zwróć ścieżkę względną, która jest dostępna z przeglądarki
			return $"/images/weatherIcons/image_{city}.jpg";
		}


		async Task<string> InputText()
        {
            await Console.Out.WriteLineAsync("Podaj miasto dla którego chcesz wyszukać pogodę\nlub wpisz 'quit' aby zakończyć aplikację");
            var cityToFind = Console.ReadLine();
            isUserWantToQuit(cityToFind);
            return cityToFind;
        }

        private void isUserWantToQuit(string? cityToFind)
        {
            if (cityToFind == "quit") System.Environment.Exit(1);
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
