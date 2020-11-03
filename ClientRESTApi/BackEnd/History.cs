using ClientRESTApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRESTApi.BackEnd
{
    class History
    {
        public static List<Request> ListRequest {get;set;}

        public History()
        {
            ListRequest = new List<Request>();
        }

        public static void AddRequest(Request request)
        {
            ListRequest.Add(request);    
        }

    }
}
