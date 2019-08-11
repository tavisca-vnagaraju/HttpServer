using Newtonsoft.Json.Linq;
using System;

namespace HttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WebServerApplication webServerApplication = new WebServerApplication();
            webServerApplication.Start();
            Console.ReadKey(true);
        }
    }
    public interface IApiCall
    {
        JObject GetResult(JObject jObject);
    }
    public class ApiCallFactory
    {
        public IApiCall GetApi(string apiName)
        {
            switch (apiName)
            {
                case "/IsLeapYear":
                    return new LeapYear();
                default:
                    throw new ApiNotFoundException();
            }
        }
    }
}
     