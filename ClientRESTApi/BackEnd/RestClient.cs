using ClientRESTApi.Models;
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
        private Request request = new Request(); 
       
        
        public RestClient(string url, string method)
        {
            request.Url = url;
            request.Method = method;
            request.Responce = string.Empty; 
        }
        private HttpWebRequest httpWebRequest; 
        public bool MakeRequest()
        {
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(request.Url);
                httpWebRequest.Method = request.Method;
                return true; 
            }
            catch(UriFormatException ufe)
            {
                SharedClass.MessageBoxError(ufe.Message, "Not valid URI");
            }
            catch(Exception ex)
            {
                SharedClass.MessageBoxError(ex); 
            }

            return false; 
        }

        public Request GetResponce()
        {
            using(HttpWebResponse responce = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (responce == null)
                {
                    request.Responce = "Responce == null";
                    return request; 
                }
                using(Stream stream = responce.GetResponseStream())
                {
                    if (stream == null)
                    {
                        request.Responce = "Stream == null";
                    }

                    using(StreamReader read = new StreamReader(stream))
                    {
                        request.Responce = read.ReadToEnd();
                        if (request.Responce == "")
                        {
                            request.Responce = "Responce result empty";
                        }
                    }
                }
            }
            return request; 
        }


        
    }
}
