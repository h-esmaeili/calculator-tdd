using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TDDCalculator.WpfClient.Http
{
    public sealed class RestApiClient: HttpClient
    {
        private string baseApiUrl = "https://localhost:44344";
        public RestApiClient()
        {
            this.BaseAddress = new Uri(baseApiUrl);
            this.DefaultRequestHeaders.ConnectionClose = false;
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
