using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests;

public class LoginToMainPage
{
    public readonly IPage _page;

    public LoginToMainPage(IPage page)
    {
        _page = page;
    }
    private ILocator Username => _page.Locator("id=user-name");
    private ILocator Password => _page.Locator("id=password");
    private ILocator LoginButton => _page.Locator("id=login-button");

    public async Task Login()
    {
        await Username.FillAsync("standard_user");
        await Password.FillAsync("secret_sauce");
        await LoginButton.ClickAsync();
    }
}