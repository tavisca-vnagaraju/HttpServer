namespace HttpServer
{
    public class ApiCallFactory
    {
        public IApiCall GetApi(string apiName)
        {
            switch (apiName)
            {
                case "/IsLeapYear":
                case "/IsLeapYear/":
                    return new LeapYear();
                default:
                    throw new ApiNotFoundException();
            }
        }
    }
}
     