using Newtonsoft.Json.Linq;

namespace HttpServer
{
    public class LeapYear: IApiCall
    {
        private JObject resultJsonObject;
        public JObject GetResult(JObject jObject)
        {
            resultJsonObject = new JObject();
            var year = jObject["year"];
            var isLeapYear = this.IsLeapYear(int.Parse(year.ToString()));
            resultJsonObject["isLeapYear"] = isLeapYear;
            resultJsonObject["year"] = year;
            return resultJsonObject;
        }

        public bool IsLeapYear(int year)
        {
            if (year % 4 ==0 && year % 100 == 0)
            {
                return true;
            }
            else if (year % 400 == 0)
            {
                return true;
            }
            return false;
        }
    }
}