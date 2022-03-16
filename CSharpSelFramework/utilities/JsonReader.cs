using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.utilities
{
    public class JsonReader
    {
        public JsonReader()
        {

        }

        public String extractData(String tokenName)
        {
            var myJsonString =File.ReadAllText("utilities/testData.json");

            var jsonObject=JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<String>();
        }

        public String[] extractDataArray(String tokenName)
        {
            var myJsonString = File.ReadAllText("utilities/testData.json");

            var jsonObject = JToken.Parse(myJsonString);
            List<String> products= jsonObject.SelectTokens(tokenName).Values<String>().ToList();
            return products.ToArray();
        }
    }
}
