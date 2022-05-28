using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace APITests
{
    [TestClass]
    public class HappyTests
    {
        [TestMethod]
        public async Task TestGet()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/posts");
            var request = new RestRequest("/1", Method.Get);

            var response = await client.ExecuteAsync(request);
            Assert.AreEqual("OK", response.StatusCode.ToString());
        }
    }
}