using System;

namespace HttpServer
{
    public class HttpHandlerFactory
    {
        public IHttpHandler GetHttpHandler(string httpMethod)
        {
            switch (httpMethod.ToLowerInvariant())
            {
                case "get":
                    return new FileHandler();
                case "post":
                    return new PostHandler();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
     