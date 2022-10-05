using Sedc.Server.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualServer
{
    internal class CustomRequest : IRequest
    {
        public override string ToString()
        {
            return "I'm so custom, OMG!";
        }
    }
    internal class CustomRequestParser : IRequestParser
    {
        public CustomRequestParser()
        {
            Console.WriteLine("CustomRequestParser reporting for duty");
        }

        public IRequest TryParse(string requestData)
        {
            return new CustomRequest();
        }
    }
}
