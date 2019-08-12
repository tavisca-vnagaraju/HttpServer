using Newtonsoft.Json.Linq;

namespace HttpServer
{
    public interface IApiCall
    {
        JObject GetResult(JObject jObject);
    }
}