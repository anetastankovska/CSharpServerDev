using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Sedc.Server.Requests
{
    public class MyRequestParser
    {
        public static Request Parse(string requeststr)
        {
            var lines = requeststr.Split("\r\n");
            var urlLine = lines[0];
            var urlParts = urlLine.Split(" ");
            var url = urlParts[1];
            //var method = urlParts[0];
            //var protocol = urlParts[2].Split("/")[0];
            //var protocolVersion = urlLine.Split($" {protocol}/")[1];
            //var path = url.Split("?")[0];
            //var queryParams = url.Split("?")[1].Split("&");

            var remainingLines = lines.Skip(1);

            var urlRegex = new Regex(@"^([A-Z]+)\s\/(.*?)\?(.*?)\s([A-Z]+)\/([0-9]+\.*[0-9]*)");
            var urlMatch = urlRegex.Match(url);
            var method = urlMatch.Groups[1].Value;
            var path = urlMatch.Groups[2].Value;
            var queryParams = urlMatch.Groups[3].Value;
            var protocol = urlMatch.Groups[4].Value;
            var protocolVersion = urlMatch.Groups[5].Value;
            
            var requestDict = new Dictionary<string, string>();
            foreach (var item in remainingLines)
            {
                Console.WriteLine(item);
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                var data = item.Split(": ");
                var key = data[0].Trim();
                var value = data[1].Trim();
                requestDict.Add(key, value);
            }

            var request = new Request
            {
                Url = url,
                Method = Method.FromName(method),
                RawRequest = requeststr,
                Headers = new ReadOnlyDictionary<string, string>(requestDict)
            };
            return request;
        }

        public static List<string> ParseUrl(string urlLine)
        {
            //var urlParts = urlLine.Split(" ");
            //foreach (var item in urlParts)
            //{
            //    Console.WriteLine("Part: " + item);
            //}
            //var url = urlParts[1];

            if(urlLine == null || urlLine == "")
            {
                return new List<string>(){ };
            }
            var urlRegex = new Regex(@"^([A-Z]+)\s\/(.*?)\?(.*?)\s([A-Z]+)\/([0-9]+\.*[0-9]*)");
            var urlMatch = urlRegex.Match(urlLine);
            var method = urlMatch.Groups[1].Value;
            var path = urlMatch.Groups[2].Value;
            var queryParams = urlMatch.Groups[3].Value;
            var protocol = urlMatch.Groups[4].Value;
            var protocolVersion = urlMatch.Groups[5].Value;

            return new List<string> {method, path, queryParams, protocol, protocolVersion };

        }

    }
}
