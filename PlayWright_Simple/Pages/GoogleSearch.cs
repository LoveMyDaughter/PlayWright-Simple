using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWright_Simple.Pages
{
    public class GoogleSearch
    {
        private readonly IPage _page;
        private readonly ILocator _searchInput;

        public GoogleSearch(IPage page)
        {
            _page = page;
            _searchInput = page.Locator("[title=Пошук]");
        }

        public async Task GotoAsync()
        {
            await _page.GotoAsync("https://google.com");
        }

        public async Task SearchAsync(string text)
        {
            await _searchInput.FillAsync(text);
            //await _searchInput.PressAsync("Enter");
        }

        public async Task GetScreenshot()
        {
            await _page.ScreenshotAsync(new()
            {
                Path = "GoogleSearch.png",
                FullPage = true,
            });
        }
    }
}
