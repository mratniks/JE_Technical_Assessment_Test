using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests;

public class OrderTshirt : PageTest
{
    public readonly IPage _page;
        public OrderTshirt(IPage page)
    {
        _page = page;
    }
    private ILocator addToCartButton => _page.Locator("id=add-to-cart-sauce-labs-bolt-t-shirt");
    private ILocator shoppingCartIcon => _page.Locator("//span[@class='shopping_cart_badge']");
    private ILocator checkoutButton => _page.Locator("id=checkout");
    private ILocator NameField => _page.Locator("id=first-name");
    private ILocator surnameField => _page.Locator("id=last-name");
    private ILocator zipField => _page.Locator("id=postal-code");
    private ILocator continueButton => _page.Locator("id=continue");
    private ILocator finishButton => _page.Locator("id=finish");
    private ILocator confirmationText => _page.Locator("text='Thank you for your order!'");

    public async Task OrderOneTShirt()
    {
        await addToCartButton.ClickAsync();
        await Expect(shoppingCartIcon).ToBeVisibleAsync();
        await shoppingCartIcon.ClickAsync();
        await checkoutButton.ClickAsync();
        await NameField.FillAsync("Mikelis");
        await surnameField.FillAsync("Ratniks");
        await zipField.FillAsync("LV1234");
        await continueButton.ClickAsync();
        await finishButton.ClickAsync();
        await Expect(confirmationText).ToBeVisibleAsync();
    }
}
