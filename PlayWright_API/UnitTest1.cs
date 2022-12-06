using Microsoft.Playwright;
using System.Web;
using static System.Net.WebRequestMethods;

namespace PlayWright_API
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var playwright = await Playwright.CreateAsync();

            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {
                BaseURL = "https://localhost:5005/",
                IgnoreHTTPSErrors = true

            });
            
            var response = await requestContext.GetAsync(url:"api/Unit/collection");
            var data = await response.JsonAsync();
            //Console.WriteLine(data);
            

        }


    }
}