using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClientRESTApi.Logic.Model; 

namespace ClientRESTApi.BackEnd
{
    class History
    {
        public static List<Request> ListRequest { get; set; }
        public static int MAXLENGHTRESPONCE { get; private set; }

        public History()
        {
            ListRequest = new List<Request>();
            MAXLENGHTRESPONCE = 100; 
        }

        
        public static void AddRequest(Request request)
        {
            ListRequest.Add(request);    
        }

    }
}
