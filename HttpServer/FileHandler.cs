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
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                dispatcher.GetContext().Response.StatusCode = 404;
                return File.ReadAllBytes("NotFound.html");
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                dispatcher.GetContext().Response.StatusCode = 404;
                return File.ReadAllBytes("NotFound.html");
            }
        }
    }
}
     