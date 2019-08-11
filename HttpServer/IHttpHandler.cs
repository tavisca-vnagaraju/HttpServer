namespace HttpServer
{
    public interface IHttpHandler
    {
        byte[] GetBytes(Dispatcher dispatcher);
    }
}
     