using System.Threading;

namespace HttpServer
{
    public class WebServerApplication
    {
        private DomainPath _domainPath;
        private RequestsQueue _requestsQueue;
        private byte[] _bytes;
        public void Start()
        { 
            _domainPath = new DomainPath();
            _requestsQueue = new RequestsQueue();
            _domainPath.MapPathToDomain(8080,"WebPages","GET");
            _domainPath.MapPathToDomain(4000, "MyProject","GET");
            _domainPath.MapPathToDomain(4000, "/IsLeapYear","POST");
            var listen = new Thread(Listen);
            var response = new Thread(GetContext);
            listen.Start();
            response.Start();
        }
        public void Listen()
        {
            Listener listener = new Listener(_domainPath, _requestsQueue);
            listener.Start();
        }
        public void GetContext()
        {
            while (true)
            {
                while(_requestsQueue._requestQueue.Count > 0)
                {
                    var httpListenerContext = _requestsQueue.GetRequest();
                    if (httpListenerContext == null)
                    {
                        continue;
                    }
                    Dispatcher dispatcher = new Dispatcher(httpListenerContext, _domainPath);
                    dispatcher.ParseRequest();
                    //if (dispatcher.UrlAbsolutePath().Contains("favicon"))
                    //{
                    //    continue;
                    //}
                    HttpHandlerFactory httpHandlerFactory = new HttpHandlerFactory();
                    IHttpHandler httpHandler = httpHandlerFactory.GetHttpHandler(dispatcher.GetHttpMethod());
                    _bytes = httpHandler.GetBytes(dispatcher);
                    Response response = new Response(httpListenerContext);
                    response.WriteResponse(_bytes);
                }
            }
        }
    }
}
     