using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StorageDesktopApp.StorageAPIClient
{
    public class StorageHTTPClient
    {
        internal static string baseUri = "https://localhost:7093";
        private static StorageHTTPClient _instance;
        internal HttpClient HttpClient;

        private StorageHTTPClient()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public static StorageHTTPClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StorageHTTPClient();
                }
                return _instance;
            }
        }
    }
}
