using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TDDCalculator.WebApi.Middlewares
{
    public sealed class InternalServerError
    {
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }
}