using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Search_App
{
    public class QueryControl
    {
        const string Plot = "full";
        const string Format = "json";

        public static string MakeQuery(string title)
        {
            return $"http://www.omdbapi.com/?t={title}&y=&plot={Plot}&r={Format}";
        }
    }
}
