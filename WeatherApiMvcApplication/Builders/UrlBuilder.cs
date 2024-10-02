using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WeatherApiMvcApplication.Models.WeatherModel;

namespace WebApiClient
{
    public class UrlBuilder : IDisposable
    {
        private string _url;
		private string _keyNumber;
		private string _city;
        private int _days;

		public UrlBuilder(string url, string city, int days = 0)
		{
			_url = url;
			_keyNumber = "bd55db8073f645cfa6381817241205";
			_city = city;
            _days = days;
		}

		public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string ReturnUrl()
        {
            StringBuilder sb = new StringBuilder();
			sb.Append(_url);

            if (_days == 0) sb.Append("current.json");
            else sb.Append("forecast.json");

            sb.Append("?key=" + _keyNumber);
            sb.Append("&q=" + _city);
            if (_days != 0) sb.Append("&days=" + _days);

            return sb.ToString();
        }
    }
}
