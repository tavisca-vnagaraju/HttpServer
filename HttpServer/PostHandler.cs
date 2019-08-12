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
                var path = dispatcher.UrlAbsolutePath();
                IApiCall apiCall = apiCallFactory.GetApi(path);
                resultJsonObject = apiCall.GetResult(dispatcher.GetBody());
            }
            catch(ApiNotFoundException e)
            {
                resultJsonObject = new JObject();
                dispatcher.GetContext().Response.StatusCode = 404;
                resultJsonObject["statusCode"] = 404;
                resultJsonObject["message"] = "Api Not Found";
            }
            finally
            {
                var jsonString = JsonConvert.SerializeObject(resultJsonObject);
                _bytes = Encoding.ASCII.GetBytes(jsonString);
            }
            return _bytes;
        }
    }
}