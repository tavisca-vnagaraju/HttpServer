using System.IO;

namespace HttpServer
{
    public class FileHandler
    {
        public byte[] GetFileBytes(string filePath)
        {
            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch(FileNotFoundException e)
            {
                return File.ReadAllBytes("NotFound.html");
            }
        }
    }
}
     