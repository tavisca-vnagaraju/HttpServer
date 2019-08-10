using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json.Linq;

namespace HttpServer
{
    public class PostHandler
    {
        private JObject _jObject;
        private byte[] _bytes;
        private string _path;

        public PostHandler(string path)
        {
            _path = path;
        }

        public byte[] GetBytes(JObject jObject)
        {
            if(_path == "/IsLeapYear")
            {
                _jObject = new JObject();
                var year = jObject["year"];
                LeapYear leapYear = new LeapYear();
                var isLeapYear = leapYear.IsLeapYear(int.Parse(year.ToString()));
                _jObject["isLeapYear"] = isLeapYear;
                _bytes = ObjectToByteArray(_jObject.ToString());
            }
            else
            {
                return File.ReadAllBytes("NotFound.html");
            }
            return _bytes;
        }
        public byte[] ObjectToByteArray(object objectName)
        {
            if (objectName == null)
                return null;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, objectName);
                return memoryStream.ToArray();
            }
        }
    }
}