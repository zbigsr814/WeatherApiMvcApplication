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
        public IWeather GetData(string city)
        {
            var httpClient = new HttpClient();

            while (true)
            {
                var inputFromUser = city; //InputText().Result;
                var normalCityToFind = RemoveSigns(inputFromUser);

                using (UrlBuilder urlBuilder = new UrlBuilder(Consts.url, inputFromUser))
                {
                    string apiUrl = urlBuilder.ReturnUrl();
                    var dataFromSite = httpClient.GetAsync(apiUrl).Result;
                    var responseFromSite = dataFromSite.Content.ReadAsStringAsync().Result;
                    IWeather deserializedData = JsonConvert.DeserializeObject<WeatherModel>(responseFromSite);     // tworzenie podstawowego obiektu

                    // if (deserializedData.current == null)

                    return deserializedData;
                }
            }
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
