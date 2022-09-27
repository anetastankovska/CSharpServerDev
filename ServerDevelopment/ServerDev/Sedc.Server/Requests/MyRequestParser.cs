using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sedc.Server.Requests
{
    public class MyRequestParser
    {
        public static Request Parse(string requeststr)
        {
            var lines = requeststr.Split("\r\n");
            var urlLine = lines[0];
            var method = urlLine.Split(" ")[0];
            var url = urlLine.Split(" ")[1];

            var remainingLines = lines.Skip(1);

            var urlRegex = new Regex(@"^([A-Z]+)\s\/(.*)\sHTTP\/1.1$");
            var urlMatch = urlRegex.Match(url);

            var request = new Request
            {
                Url = url,
                Method = new Method(method)
            };

            var headersDictionary = new Dictionary<string, string>();
            
            foreach (var line in remainingLines)
            {
                
            }

        }
    }
}
