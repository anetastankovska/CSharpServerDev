using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sedc.Server.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class MyUrlTests
    {
        [TestMethod]
        public void GetValidUrlString()
        {
            //Arrange
            var input = "GET /aaa/?someparam=nope&someotherparam=true HTTP/1.1\r\nHost: localhost:668\r\nConnection: keep-alive\r\nsec-ch-ua: \"Google Chrome\";v=\"105\", \"Not)A;Brand\";v=\"8\", \"Chromium\";v=\"105\"\r\nsec-ch-ua-mobile: ?0\r\nsec-ch-ua-platform: \"Windows\"\r\nUpgrade-Insecure-Requests: 1\r\nUser-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36\r\nAccept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9\r\nSec-Fetch-Site: none\r\nSec-Fetch-Mode: navigate\r\nSec-Fetch-User: ?1\r\nSec-Fetch-Dest: document\r\nAccept-Encoding: gzip, deflate, br\r\nAccept-Language: en-GB,en;q=0.9,mk-MK;q=0.8,mk;q=0.7,en-US;q=0.6,bg;q=0.5,sr;q=0.4,es;q=0.3,bs;q=0.2\r\n\r\n";
            var expectedResult = "/aaa/?someparam=nope&someotherparam=true";

            //Act
            var actualResult = MyRequestParser.Parse(input).Url;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetInValidUrlString()
        {
            //Arrange
            var input = "";
            var expectedResult = new List<string>() { };

            //Act
            var actualResult = MyRequestParser.Parse(input).Url;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void GetValidMethod()
        {
            //Assert
            var input = "GET /aaa/?someparam=nope&someotherparam=true HTTP/1.1";
            var expecdedResult = "GET";

            //Act
            List<string> resutList = MyRequestParser.ParseUrl(input);
            string actualResult = resutList.FirstOrDefault(x => x == "GET").ToString();

            //Assert
            Assert.AreEqual(expecdedResult, actualResult);
        }

        [TestMethod]
        public void GetValidPath()
        {
            //Assert
            var input = "GET /aaa/?someparam=nope&someotherparam=true HTTP/1.1";
            var expecdedResult = "aaa/";

            //Act
            List<string> resutList = MyRequestParser.ParseUrl(input);
            string actualResult = resutList.FirstOrDefault(x => x == "aaa/").ToString();

            //Assert
            Assert.AreEqual(expecdedResult, actualResult);
        }

        [TestMethod]
        public void GetValidQueryParams()
        {
            //Assert
            var input = "GET /aaa/?someparam=nope&someotherparam=true HTTP/1.1";
            var expecdedResult = "someparam=nope&someotherparam=true";

            //Act
            List<string> resutList = MyRequestParser.ParseUrl(input);
            string actualResult = resutList.FirstOrDefault(x => x == "someparam=nope&someotherparam=true").ToString();

            //Assert
            Assert.AreEqual(expecdedResult, actualResult);
        }

        [TestMethod]
        public void GetValidProtocol()
        {
            //Assert
            var input = "GET /aaa/?someparam=nope&someotherparam=true HTTP/1.1";
            var expecdedResult = "HTTP";

            //Act
            List<string> resutList = MyRequestParser.ParseUrl(input);
            string actualResult = resutList.FirstOrDefault(x => x == "HTTP").ToString();

            //Assert
            Assert.AreEqual(expecdedResult, actualResult);
        }

        [TestMethod]
        public void GetValidProtocolVersion()
        {
            //Assert
            var input = "GET /aaa/?someparam=nope&someotherparam=true HTTP/1.1";
            var expecdedResult = "1.1";

            //Act
            List<string> resutList = MyRequestParser.ParseUrl(input);
            string actualResult = resutList.FirstOrDefault(x => x == "1.1").ToString();

            //Assert
            Assert.AreEqual(expecdedResult, actualResult);
        }
    }
}
