using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlayWright_Simple.Pages
{
    public class LoginPageUpgraded
    {

        private IPage _page;
        public LoginPageUpgraded(IPage page) => _page = page;
        public ILocator LnkLogin => _page.Locator("text=Login");
        public ILocator TxtUserName => _page.Locator("#UserName");
        public ILocator TxtPassword => _page.Locator("#Password");
        public ILocator BtnLogin => _page.Locator("text=Log in");
        public ILocator LnkEmployeeDetails => _page.Locator("text='Employee Details'");
        public ILocator LnkEmployeeList=> _page.Locator("text='Employee List'");


        //Use ClickLoginAndWaitNavigation() instead
        public async Task ClickLogin() => await LnkLogin.ClickAsync();

        public async Task ClickLoginAndWaitNavigation()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await LnkLogin.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/Login"
            });
        }

        public async Task Login(string userName, string password)
        {
            await TxtUserName.FillAsync(userName);
            await TxtPassword.FillAsync(password);
            await BtnLogin.ClickAsync();
        }

        public async Task ClickEmployeeList() => await LnkEmployeeList.ClickAsync();

        public async Task<bool> IsEmployeeDetailsExists() => await LnkEmployeeDetails.IsVisibleAsync();
    }
}
