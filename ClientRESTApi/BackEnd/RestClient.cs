using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClientRESTApi.BackEnd
{
    class RestClient
    {
        private string Url { get; set; }
        private string HttpMethod { get; set; }
        public RestClient(string url, string method)
        {
            Url = url;
            HttpMethod = method;
            MakeRequest();  
        }
        private HttpWebRequest request; 
        private void MakeRequest()
        {
            request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = HttpMethod;
        }

        public string GetResponce()
        {
            using(HttpWebResponse responce = (HttpWebResponse)request.GetResponse())
            {
                if (responce == null) return "Responce == null"; 
                using(Stream stream = responce.GetResponseStream())
                {
                    if (stream == null) return "Stream == nyll"; 
                    using(StreamReader read = new StreamReader(stream))
                    {
                        string result = read.ReadToEnd();
                        if (result == "") return "Responce result empty";
                        return result; 
                    }
                }
            }
        }


        
    }
}
