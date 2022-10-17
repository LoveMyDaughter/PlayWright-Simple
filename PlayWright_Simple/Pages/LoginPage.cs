using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlayWright_Simple.Pages
{
    public class LoginPage
    {

        private IPage _page;
        private readonly ILocator _lnkLogin;
        private readonly ILocator _txtUserName;
        private readonly ILocator _txtPassword;
        private readonly ILocator _btnLogin;
        private readonly ILocator _lnkEmployeeDetails;

        public LoginPage(IPage page)
        {
            _page = page;
            _lnkLogin = page.Locator(selector: "text=Login");
            _txtUserName = page.Locator(selector: "#UserName");
            _txtPassword = page.Locator(selector: "#Password");
            _btnLogin = page.Locator(selector: "text=Log in");
            _lnkEmployeeDetails = page.Locator(selector: "text='Employee Details'");
        }

        public async Task ClickLogin() => await _lnkLogin.ClickAsync();

        public async Task Login(string userName, string password)
        {
            await _txtUserName.FillAsync(userName);
            await _txtPassword.FillAsync(password);
            await _btnLogin.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();
    }
}
