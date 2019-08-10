using System.Collections.Generic;

namespace HttpServer
{
    public class DomainPath
    {
        private Dictionary<string, string> _domainPath = new Dictionary<string, string>();
        private List<string> _domains = new List<string>();
        public void MapPathToDomain( int port, string folderName)
        {
            var  domain = "localhost:" + port + "/";
            _domainPath[domain] = folderName;
            _domains.Add(domain);
        }
        public string GetPathByDomain(string domain)
        {
            return _domainPath[domain];
        }
        public Dictionary<string, string> GetAllPathsAndDomains()
        {
            return _domainPath;
        }
        public List<string> GetAllDomains()
        {
            return _domains;
        }
    }
}
