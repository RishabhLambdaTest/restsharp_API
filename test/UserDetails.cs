using System;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using RestSharpAPIAutomationDemo.RestSharpBase;
using System.Collections.Generic;

namespace RestSharpAPIAutomationDemo.Test
{
    [TestFixture]
    class UserDetails : BaseTest
    {
        private IRestResponse response;

        [Test]
        [Description("Verify that the Get User Details API returns userId, name and email")]
        [Author("Osanda Nimalarathna")]
        [Category("Get User Details")]
        public void VerifyGetUserDetailsApi()
        {
            Dictionary<String, String> pathParamMap = new Dictionary<String, String>();
            pathParamMap.Add("id", "2");


            response = RestMethods.GetWithPathParam(pathParamMap, baseUrl);
            var responseJsonObject = JObject.Parse(response.Content);
            Console.WriteLine(responseJsonObject.ToString());
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Console.WriteLine(response.StatusCode);
            Assert.NotNull(responseJsonObject.GetValue("name"));
            Console.WriteLine(responseJsonObject.GetValue("name"));
            Assert.NotNull(responseJsonObject.GetValue("status"));
            Console.WriteLine(responseJsonObject.GetValue("status"));
            Assert.NotNull(responseJsonObject.GetValue("id"));
            Console.WriteLine(responseJsonObject.GetValue("id"));
        }
    }
}