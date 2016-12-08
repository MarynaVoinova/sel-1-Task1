using OpenQA.Selenium;

namespace Task1Setup.PageObjects
{
	public class BasePage
	{
		public Cart Cart { get; }

		public BasePage(IWebDriver driver)
		{
			Cart = new Cart(driver);
		}
	}
}
