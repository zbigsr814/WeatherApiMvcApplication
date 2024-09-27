using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class UrlBuilder : IDisposable
    {
        private string _url;
        private string _city;

        public UrlBuilder(string url, string city)
        {
            _url = url;
            _city = city;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string ReturnUrl()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_url);
            sb.Append(_city);

            return sb.ToString();
        }
    }
}
