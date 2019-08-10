using System.Collections.Generic;
using System.Net;

namespace HttpServer
{
    public class RequestsQueue
    {
        public List<HttpListenerContext> _requestQueue = new List<HttpListenerContext>();
        public void AddToQueue(HttpListenerContext context)
        {
            _requestQueue.Add(context);
        }
        public HttpListenerContext GetRequest()
        {
            var context = _requestQueue[0];
            _requestQueue.RemoveAt(0);
            return context;
        }
    }
}
     