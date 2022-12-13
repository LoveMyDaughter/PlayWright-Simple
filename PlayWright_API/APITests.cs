using Microsoft.Playwright;

namespace PlayWright_API
{
    [TestFixture]
    public class APITests
    {
/*      
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
*/

        [Test]
        public async Task FCGetToken()
        {
            var playwright = await Playwright.CreateAsync();

            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {
                BaseURL = "https://fctstint1602.qdev.net:60112/",
               // IgnoreHTTPSErrors = true

            });

            var response = await requestContext.PostAsync(url: "tst_flowcal/identity/connect/token", new APIRequestContextOptions()
            {
                DataObject = new
                {
                    grant_type = "client_credentials",
                    client_id = "flowcalclient",
                    client_secret = "F621F470-9731-4A25-80EF-67A6F7C5F4B8",
                    scope = "api"
                }
            });
            var data = await response.JsonAsync();
            Console.WriteLine(data);
        }
    }
}
