using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClientRESTApi.Logic.Model; 


namespace ClientRESTApi.Logic
{
    public class RestClient
    {
        private Request request = new Request();
        public RestClient(string url, Methods method)
        {
            request.Url = url;
            request.Method = method;
            request.Responce = string.Empty;
            request.Body = string.Empty; 
        }

        private HttpWebRequest httpWebRequest;
        public void MakeRequest()
        {
           httpWebRequest = (HttpWebRequest)WebRequest.Create(request.Url);
           httpWebRequest.ContentType = "application/json";
           httpWebRequest.Method = request.Method.ToString();
           
        }
        public void SetBody(string json)
        {
            using (StreamWriter sw = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                sw.Write(json);
            }
        }

        public Request GetResponce()
        {            
            using (HttpWebResponse responce = (HttpWebResponse)httpWebRequest.GetResponse())
            {  
                using (Stream stream = responce.GetResponseStream())
                {                    
                    using (StreamReader read = new StreamReader(stream))
                    {
                        request.Responce = read.ReadToEnd();
                    }
                }
            }
            return request; 
        }


    }
}
