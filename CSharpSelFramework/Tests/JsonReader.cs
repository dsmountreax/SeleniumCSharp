using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.Tests
{
    public class JsonReader
    {
        public JsonReader()
        {

        }

        public void extractData()
        {
            var myJsonString =File.ReadAllText("testData.json");

            var jsonObject=JToken.Parse(myJsonString);
            Console.WriteLine(jsonObject.SelectToken("username").Value<String>());
        }
    }
}
