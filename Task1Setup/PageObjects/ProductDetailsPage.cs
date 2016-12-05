using System;
using OpenQA.Selenium;

namespace Task1Setup.PageObjects
{
	public class ProductDetailsPage
	{
		private IWebElement boxProduct;

		public ProductDetails Product { get; }
		public string Title { get; }

		public ProductDetailsPage(IWebDriver driver)
		{
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(45));
			boxProduct = driver.FindElement(By.CssSelector("#box-product"));
			Title = boxProduct.FindElement(By.CssSelector("h1.title")).GetAttribute("textContent");
			Product = new ProductDetails(driver, boxProduct, true);
		}
	}
}
