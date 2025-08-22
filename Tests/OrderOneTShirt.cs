using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests;

[TestClass]
public class Test : PageTest
{
    [TestMethod]
    public async Task HasTitle()
    {
        await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.saucedemo.com/");


        var LoginToMainPage = new LoginToMainPage(page);
        await LoginToMainPage.Login();

        var OrderTshirt = new OrderTshirt(page);
        await OrderTshirt.OrderOneTShirt();
        


    }
}