using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Nuget package System.Text.Json; 
using System.Text.Json; 

namespace ClientRESTApi.Logic
{
    /// <summary>
    /// Class for work with methods of Serialization
    /// </summary>
    public class Serialization
    {
        /// <summary>
        /// json pretty serialization
        /// </summary>
        /// <param name="str">json string</param>
        /// <returns>
        /// pretty json string,
        /// if str not format json -> return str no serialize 
        /// </returns>
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
