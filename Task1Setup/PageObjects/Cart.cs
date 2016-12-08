using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task1Setup.PageObjects
{
	public class Cart
	{
		private IWebDriver driver;
		public int NumberOfProductsInCart { get; private set; }
		private IWebElement NumberOfProductsInCartWebElement { get; set; }

		public Cart(IWebDriver driver)
		{
			this.driver = driver;
			RefreshNumberOfProductsInCart();
		}

		private void RefreshNumberOfProductsInCart()
		{
			NumberOfProductsInCartWebElement = driver.FindElement(By.CssSelector("span.quantity"));
			NumberOfProductsInCart = int.Parse(NumberOfProductsInCartWebElement.GetAttribute("textContent"));
		}

		public void WaitUntilCartNumberOfProductsIsRefreshed(int expectedNumberOfProductsInCart)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			//var temp = NumberOfProductsInCartWebElement;
			wait.Until(ExpectedConditions.TextToBePresentInElement(GetNumperOfProduct(), expectedNumberOfProductsInCart.ToString()));
			RefreshNumberOfProductsInCart();
		}

		private IWebElement GetNumperOfProduct()
		{
			NumberOfProductsInCartWebElement = driver.FindElement(By.CssSelector("span.quantity"));
			return NumberOfProductsInCartWebElement;
		}
	}
}
