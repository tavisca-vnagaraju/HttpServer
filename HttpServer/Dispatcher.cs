using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HttpServer
{
    public class Dispatcher
    {
        private string _domainUrl;
        private DomainPath _domainPath;
        private string _filePath;
        private HttpListenerContext _httpListenerContext;
        private string _method;
        private JObject _jsonBody;

        public Dispatcher(HttpListenerContext httpListenerContext, DomainPath domainPath)
        {
            _httpListenerContext = httpListenerContext;
            _domainPath = domainPath;
        }
        public void ParseUrl()
        {
            _domainUrl = _httpListenerContext.Request.Url.Authority;
            _method = _httpListenerContext.Request.HttpMethod;
            if("GET" == _method)
            {
                var absoluteFilePath = _httpListenerContext.Request.Url.AbsolutePath;
                if(absoluteFilePath == "/")
                {
                    absoluteFilePath = "/index.html";
                }
                _filePath = _domainPath.GetPathByDomain(_domainUrl+"/") + absoluteFilePath;
            }
            if("POST" == _method)
            {
                _filePath = _httpListenerContext.Request.Url.AbsolutePath;
                var hasBody = _httpListenerContext.Request.HasEntityBody;
                if (hasBody)
                {
                    var bodyStream = _httpListenerContext.Request.InputStream;
                    StreamReader streamReader = new StreamReader(bodyStream);

                    var text = streamReader.ReadToEnd();
                    _jsonBody = JObject.Parse(text);

                }
            }
        }
        public string GetFilePath()
        {
            return _filePath;
        }
        public string GetHttpMethod()
        {
            return _method;
        }
        public JObject GetBody()
        {
            return _jsonBody;
        }
    }
}
     