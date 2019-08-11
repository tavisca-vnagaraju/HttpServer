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
            if (dispatcher.UrlAbsolutePath() == "/IsLeapYear")
            {
                resultJsonObject = new JObject();
                var jObject = dispatcher.GetBody();
                var year = jObject["year"];
                LeapYear leapYear = new LeapYear();
                var isLeapYear = leapYear.IsLeapYear(int.Parse(year.ToString()));
                resultJsonObject["isLeapYear"] = isLeapYear;
                resultJsonObject["year"] = year;

                var jsonString = JsonConvert.SerializeObject(resultJsonObject);
                _bytes = Encoding.ASCII.GetBytes(jsonString);
            }
            else
            {
                _bytes = File.ReadAllBytes("NotFound.html");
            }
            return _bytes;
        }
    }
}