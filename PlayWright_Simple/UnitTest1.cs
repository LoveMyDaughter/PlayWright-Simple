using Microsoft.Playwright;
using PlayWright_Simple.Pages;

namespace PlayWright_Simple

{
    public class UnitTest1
    {
        [SetUp]
        public void Setup()
        {
            
        }

        //[Test]
        public async Task HomePageAvailabilityTest()
        {
            //Playwright
            using var playwright = await Playwright.CreateAsync();

            //Browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            //Page
            var page = await browser.NewPageAsync();
            await page.GotoAsync(url: "http://www.eaapp.somee.com");
            await page.ClickAsync(selector: "text=Login");
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "EAApp.jpg"
            });
            await page.FillAsync(selector: "#UserName", value: "admin");
            await page.FillAsync(selector: "#Password", value: "        password");
            await page.ClickAsync(selector: "text='Log in'");
            var isExist = await page.Locator(selector: "text='Employee Details'").IsVisibleAsync();

            //Assert
            Assert.IsTrue(isExist);

        }
    
        [Test]
        public async Task GoogleSearchTest()
        {
            //Playwright
            using var playwright = await Playwright.CreateAsync();

            //Browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var page = new GoogleSearch(await browser.NewPageAsync());
            await page.GotoAsync();
            await page.SearchAsync("Tesla S");
            await page.GetScreenshot();

        }
    }
}