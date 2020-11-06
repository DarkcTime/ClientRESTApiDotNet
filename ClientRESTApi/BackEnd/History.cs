using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClientRESTApi.Logic.Model; 

namespace ClientRESTApi.BackEnd
{
    /// <summary>
    /// Client class. Work with history requests
    /// </summary>
    class History
    {
        public static List<Request> ListRequest { get; set; }
        public static int MAXLENGHTRESPONCE { get; private set; }
        
        //create list and set MaxLenght
        public History()
        {
            ListRequest = new List<Request>();
            MAXLENGHTRESPONCE = 100; 
        }

        //add request object in list history
        public static void AddRequest(Request request)
        {
            ListRequest.Add(request);    
        }

    }
}
