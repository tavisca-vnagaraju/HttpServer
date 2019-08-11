using System.IO;
using System.Net;

namespace HttpServer
{
    public class Response
    {
        private HttpListenerContext _httpListenerContext;

        public Response(HttpListenerContext httpListenerContext)
        {
            _httpListenerContext = httpListenerContext;
        }
        public void WriteResponse(byte[] bytes)
        {
            var response = _httpListenerContext.Response;
            var request = _httpListenerContext.Request;
            response.ContentLength64 = bytes.Length;
            response.ContentType = request.ContentType;
            response.ContentEncoding = request.ContentEncoding;
            Stream output = response.OutputStream;
            output.Write(bytes, 0, bytes.Length);
            output.Close();
        }
    }

}
     