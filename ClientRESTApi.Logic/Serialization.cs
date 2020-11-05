using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Nuget package
using System.Text.Json; 

namespace ClientRESTApi.Logic
{
    public class Serialization
    {
        //common serialization for get pretty JSON 
        public static string GetJsonSerialize(string str)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(str)) return str;

                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
                var jsonElement = JsonSerializer.Deserialize<JsonElement>(str);
                return JsonSerializer.Serialize(jsonElement, options);
            }
            catch(JsonException je)
            {
                return str; 
            }
           
        }

    }
}
