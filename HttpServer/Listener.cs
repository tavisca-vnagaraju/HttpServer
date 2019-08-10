using System;
using System.Net;

namespace HttpServer
{
    public class Listener
    {
        private DomainPath _domainPath;
        private HttpListener _httpListener;
        private HttpListenerContext _context;
        private RequestsQueue _requestsQueue;
        public Listener(DomainPath domainPath, RequestsQueue requestsQueue)
        {
            _domainPath = domainPath;
            _requestsQueue = requestsQueue;
            var domains = _domainPath.GetAllDomains();
            _httpListener = new HttpListener();
            foreach (var domain in domains)
            {
                _httpListener.Prefixes.Add("http://"+domain);
            }
        }
        public void Start()
        {
            Console.WriteLine("Started Server....");
            _httpListener.Start();
            while (true)
            {
                _context = _httpListener.GetContext();
                if(_context != null)
                {
                    _requestsQueue.AddToQueue(_context);
                }
            }
        }
    }
}