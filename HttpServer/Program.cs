using System;

namespace HttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WebServerApplication webServerApplication = new WebServerApplication();
            webServerApplication.Start();
            Console.ReadKey(true);
        }
    }
}
     