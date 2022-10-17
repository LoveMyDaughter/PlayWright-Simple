using Microsoft.Playwright.NUnit;
using PlayWright_Simple.Pages;
using Microsoft.Playwright;

namespace PlayWright_Simple

{
    public class NUnitPlaywright
    {
        [SetUp]
        public async Task Setup()
        {
            //await Page.GotoAsync(url: "http://www.eaapp.somee.com", new PageGotoOptions
            //{
            //    WaitUntil = WaitUntilState.DOMContentLoaded
            //});

            //await Page.GotoAsync(url: "http://www.eaapp.somee.com");
        }

        //[Test]
        //public async Task LoginTest()
        //{
        //    //Page.SetDefaultTimeout(10);
            
        //    //Using Locators
        //    var lnkLogin = Page.Locator(selector: "text=Login");
        //    await lnkLogin.ClickAsync();

        //    //Act
        //    await Page.FillAsync(selector: "#UserName", value: "admin");
        //    await Page.FillAsync(selector: "#Password", value: "password");
        //    //await Page.ClickAsync(selector: "text='Log in'");
        //    var btnLogin = Page.Locator(selector: "input", new PageLocatorOptions { HasTextString = "Log in" });
        //    await btnLogin.ClickAsync();

        //    //Assert
        //    await Expect(Page.Locator(selector: "text='Employee Details'")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
        //    {
        //        Timeout = 1000
        //    });
        //}

        
        [Test]
        public async Task LoginWithPOMTest()
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

            LoginPage loginPage = new LoginPage(page);
            await loginPage.ClickLogin();
            await loginPage.Login("admin", "password");
            var isExist = await loginPage.IsEmployeeDetailsExists();
            Assert.IsTrue(isExist);
        }
        
        [Test]
        public async Task LoginWithPOMUpgradedTest()
        {
            //Playwright
            using var playwright = await Playwright.CreateAsync();

            //Browser
            await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            
            //Page
            var page = await browser.NewPageAsync();  
            await page.GotoAsync(url: "http://www.eaapp.somee.com");

            var loginPage = new LoginPageUpgraded(page);
            //await loginPage.ClickLogin();
            await loginPage.ClickLoginAndWaitNavigation();
            await loginPage.Login("admin", "password");
            var isExist = await loginPage.IsEmployeeDetailsExists();
            Assert.IsTrue(isExist);
        }


        [Test]
        public async Task TestNetworkTest()
        {
            //Playwright
            using var playwright = await Playwright.CreateAsync();

            //Browser
            await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            //Page
            var page = await browser.NewPageAsync();
            await page.GotoAsync(url: "http://www.eaapp.somee.com");

            var loginPage = new LoginPageUpgraded(page);
            await loginPage.ClickLoginAndWaitNavigation();
            await loginPage.Login("admin", "password");
            //var waitResponse = page.WaitForRequestAsync("**/Employee");
            
            //var waitResponse = page.WaitForResponseAsync("**/Employee");
            //await loginPage.ClickEmployeeList();
            //var getResponse = await waitResponse;

            var respone = await page.RunAndWaitForResponseAsync(async () =>
            {
                await loginPage.ClickEmployeeList();
            }, x => x.Url.Contains("/Employee") && x.Status == 200);

            
            var isExist = await loginPage.IsEmployeeDetailsExists();
            Assert.IsTrue(isExist);
        }
    }
}