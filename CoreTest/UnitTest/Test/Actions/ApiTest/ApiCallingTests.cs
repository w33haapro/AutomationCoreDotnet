using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;

namespace Core.UnitTest.Test.ApiTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class ApiCallingTests : BaseFixture
    {
        [Test]
        public void Api_Call_Get_Successfully()
        {
            string url = "http://api.zippopotam.us/nl/3825";
            IRestResponse response = ApiRest.Call(Method.GET, url);
        }

        [Test]
        public void Api_Call_Put_Successfully()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "p", 0 }
            };

            string jsonBody = "{ \"createdAt\": \"2020-10-31T00:30:13.711Z\", \"name\": \"W33Haa\", \"avatar\": \"https://s3.amazonaws.com/uifaces/faces/twitter/ciaranr/33.jpg\" }";
            string url = "https://5f9cbdef6dc8300016d3139b.mockapi.io/w33/users/50";
            IRestResponse response = ApiRest.Call(Method.PUT, url, jsonBody, headers, parameters);
        }
    }
}
