
var firstLine = "GET /aaa/bbb/?paramone=none&paramtwo=true HTTP/1.1";
var secondLine = "Host: localhost:668";
var method = firstLine.Split(" ")[0];
var protocol = firstLine.Split(" ")[2].Split("/")[0];
var protocolVersion = firstLine.Split($" {protocol}/")[1];
var host = secondLine.Split(": ")[1];
var url = firstLine.Split(" ")[1];
var path = url.Split("?")[0];
var queryParams = url.Split("?")[1].Split("&");
//URL {host} {path} {queryParams}
//Console.WriteLine("Method: " + method);
//Console.WriteLine("Protocol " + protocol);
//Console.WriteLine("Protocol version: " + protocolVersion);
//Console.WriteLine("Host: " + host);
//Console.WriteLine("URL:" + url);
//Console.WriteLine("Path: " + path );
//Console.WriteLine("Query params: ");
//foreach (var param in queryParams)
//{
//    Console.WriteLine(param);
//}


var headers = "GET /aaa/?someparam=nope&someotherparam=true HTTP/1.1\r\nHost: localhost:668\r\nConnection: keep-alive\r\nsec-ch-ua: \"Google Chrome\";v=\"105\", \"Not)A;Brand\";v=\"8\", \"Chromium\";v=\"105\"\r\nsec-ch-ua-mobile: ?0\r\nsec-ch-ua-platform: \"Windows\"\r\nUpgrade-Insecure-Requests: 1\r\nUser-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36\r\nAccept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9\r\nSec-Fetch-Site: none\r\nSec-Fetch-Mode: navigate\r\nSec-Fetch-User: ?1\r\nSec-Fetch-Dest: document\r\nAccept-Encoding: gzip, deflate, br\r\nAccept-Language: en-GB,en;q=0.9,mk-MK;q=0.8,mk;q=0.7,en-US;q=0.6,bg;q=0.5,sr;q=0.4,es;q=0.3,bs;q=0.2\r\n\r\n";

var lines = headers.Split("\r\n");
var headerLines = lines.Skip(1);
//foreach (var line in headerLines)
//{
//    Console.WriteLine(line);
//}

var requestDict = new Dictionary<string, string>();
foreach (var item in headerLines)
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


//foreach (var item in requestDict)
//{
//    Console.WriteLine(item.Key + ":" + item.Value);
//}




