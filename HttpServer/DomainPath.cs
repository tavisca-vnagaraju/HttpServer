using System;
using System.Collections.Generic;

namespace HttpServer
{
    public class DomainPath
    {
        private Dictionary<string, string> _getDomainPath = new Dictionary<string, string>();
        private Dictionary<string, string> _postDomainPath = new Dictionary<string, string>();

        private List<string> _domains = new List<string>();
        public void MapPathToDomain( int port, string folderName,string httpMethodName)
        {
            var  domain = "localhost:" + port + "/";
            if(httpMethodName == "GET")
            {
                _getDomainPath[domain] = folderName;
                if (!_domains.Contains(domain))
                {
                    _domains.Add(domain);
                }
            }
            else if(httpMethodName == "POST")
            {
                _postDomainPath[domain] = folderName;
                if (!_domains.Contains(domain))
                {
                    _domains.Add(domain);
                }
            }
        }
        public string GetPathByDomain(string domain,string httpMethodName)
        {
            if(httpMethodName == "GET")
            {
                if (_getDomainPath.ContainsKey(domain))
                {
                    return _getDomainPath[domain];
                }
            }
            else if(httpMethodName == "POST")
            {
                if (_postDomainPath.ContainsKey(domain))
                {
                    return _postDomainPath[domain];
                }
            }
            return null;
        }
        public Dictionary<string, string> GetAllPathsAndDomains()
        {
            return _getDomainPath;
        }
        public List<string> GetAllDomains()
        {
            return _domains;
        }
    }
}
