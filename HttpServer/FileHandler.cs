using System.IO;

namespace HttpServer
{
    public class FileHandler:IHttpHandler
    {
        public byte[] GetBytes(Dispatcher dispatcher)
        {
            try
            {
                return File.ReadAllBytes(dispatcher.UrlAbsolutePath());
            }
            catch(FileNotFoundException e)
            {
                return File.ReadAllBytes("NotFound.html");
            }
        }
    }
}
     