using Microsoft.Playwright;

namespace PlayWright_API
{
    [TestFixture]
    public class APITests
    {
        [Test]
        public async Task APIGetUnitCollection()
        {
            var playwright = await Playwright.CreateAsync();

            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {
                BaseURL = "https://localhost:5005/",
                IgnoreHTTPSErrors = true

            });

            var response = await requestContext.GetAsync(url: "api/Unit/collection");
            var data = await response.JsonAsync();
            Console.WriteLine(data);
        }

        [Test]
        public async Task APIGetUnitById()
        {
            var playwright = await Playwright.CreateAsync();

            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {
                BaseURL = "https://localhost:5005/",
                IgnoreHTTPSErrors = true

            });

            var response = await requestContext.GetAsync(url: "api/Unit/8");
            var data = await response.JsonAsync();
            Console.WriteLine(data);
        }

        [Test]
        public async Task APIGet()
        {
            var playwright = await Playwright.CreateAsync();

            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {
                BaseURL = "https://localhost:5005/",
                IgnoreHTTPSErrors = true

            });

            var response = await requestContext.GetAsync(url: "api/Unit/8");
            var data = await response.JsonAsync();
            Console.WriteLine(data);
        }


    }
}
