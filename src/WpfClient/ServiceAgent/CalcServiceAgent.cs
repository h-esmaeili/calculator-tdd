using TDDCalculator.WpfClient.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace TDDCalculator.WpfClient.ServiceAgent
{
    public sealed class CalcServiceAgent : ICalcServiceAgent
    {
        public string Add(string calculation)
        {
            using (var httpClient = new RestApiClient())
            {
                var model = new { calculation };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponseMessage = httpClient.PostAsync("api/Calculators/Add", content).GetAwaiter().GetResult();
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseMessage);

                return result;
            }
        }

        public string Subtract(string calculation)
        {
            using (var httpClient = new RestApiClient())
            {
                var model = new { calculation };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponseMessage = httpClient.PostAsync("api/Calculators/Subtract", content).GetAwaiter().GetResult();
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseMessage);

                return result;
            }
        }

        public string Multiply(string calculation)
        {
            using (var httpClient = new RestApiClient())
            {
                var model = new { calculation };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponseMessage = httpClient.PostAsync("api/Calculators/Multiply", content).GetAwaiter().GetResult();
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseMessage);

                return result;
            }
        }

        public string Divide(float param1, float param2)
        {
            using (var httpClient = new RestApiClient())
            {
                var model = new { param1, param2 };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponseMessage = httpClient.PostAsync("api/Calculators/Divide", content).GetAwaiter().GetResult();
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseMessage);

                return result;
            }
        }
        
        public string SplitEq(float param1, float param2)
        {
            using (var httpClient = new RestApiClient())
            {
                var model = new { param1, param2 };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponseMessage = httpClient.PostAsync("api/Calculators/SplitEq", content).GetAwaiter().GetResult();
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseMessage);

                return result;
            }
        }

        public string SplitNum(string calculation)
        {
            using (var httpClient = new RestApiClient())
            {
                var model = new { calculation };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponseMessage = httpClient.PostAsync("api/Calculators/SplitNum", content).GetAwaiter().GetResult();
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseMessage);

                return result;
            }
        }
    }
}
