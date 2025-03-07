using Microsoft.VisualStudio.TestTools.UnitTesting;
using RifopAPI.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RifopAPI.BLL.Tests
{
    [TestClass()]
    public class ONIResponseParserTests
    {
        [TestMethod()]
        public void ParseFaceRecognitionResponseTest()
        {
            string jsonResponse =File.ReadAllText(@"D:\Sides International\MEF-HAITI\2024\test api\reponse facial.json");

            var (isSuccess, result, errorMessage) = RifopAPI.BLL.ONIResponseParser.ParseFaceRecognitionResponse(jsonResponse);

            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(result);
           
        }
    }
}