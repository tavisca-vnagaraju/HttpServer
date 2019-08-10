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
            _domainPath.MapPathToDomain(8080,"WebPages");
            _domainPath.MapPathToDomain(4000, "MyProject");
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
                        continue;
                    Dispatcher dispatcher = new Dispatcher(httpListenerContext, _domainPath);
                    dispatcher.ParseUrl();
                    if(dispatcher.GetHttpMethod() == "GET")
                    {
                        FileHandler fileHandler = new FileHandler();
                        if (dispatcher.GetFilePath().Contains("favicon"))
                            continue;
                        _bytes = fileHandler.GetFileBytes(dispatcher.GetFilePath());
                    }
                    else if(dispatcher.GetHttpMethod() == "POST")
                    {
                        PostHandler postHandler = new PostHandler(dispatcher.GetFilePath());
                        _bytes = postHandler.GetBytes(dispatcher.GetBody());
                    }
                    Response response = new Response(httpListenerContext);
                    response.WriteResponse(_bytes);

                }
            }
        }
    }
}
     