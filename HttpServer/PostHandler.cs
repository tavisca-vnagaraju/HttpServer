using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HttpServer
{
    public class PostHandler: IHttpHandler
    {
        private JObject resultJsonObject;
        private byte[] _bytes;

        public byte[] GetBytes(Dispatcher dispatcher)
        {
            try
            {
                ApiCallFactory apiCallFactory = new ApiCallFactory();
                IApiCall apiCall = apiCallFactory.GetApi(dispatcher.UrlAbsolutePath());
                resultJsonObject = apiCall.GetResult(dispatcher.GetBody());
                var jsonString = JsonConvert.SerializeObject(resultJsonObject);
                _bytes = Encoding.ASCII.GetBytes(jsonString);
            }
            catch(ApiNotFoundException e)
            {
                _bytes = File.ReadAllBytes("NotFound.html");
            }
            return _bytes;
        }
    }
}