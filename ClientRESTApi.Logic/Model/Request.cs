using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRESTApi.Logic.Model
{
    public class Request
    {
        public string Url { get; set; }
        public Methods Method { get; set; }
        public string Body { get; set; }
        public string Responce { get; set; }

        
    }

    public class MethodsRepository{
        public static List<Methods> GetMethods()
        {
            List<Methods> methods = new List<Methods>();
            methods.Add(Methods.GET);
            methods.Add(Methods.POST);
            methods.Add(Methods.PUT);
            methods.Add(Methods.DELETE);
            return methods;
        }
    }
    public enum Methods
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}
