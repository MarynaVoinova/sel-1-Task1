using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task1Setup.PageObjects
{
	public class Navigator
	{
		IWebDriver driver;

		public Navigator(IWebDriver driver)
		{
			this.driver = driver;
		}
		public ProductsPage ToProductsPage()
		{
			driver.Url = "http://localhost:8080/litecart";
			return new ProductsPage(driver);
		}
		public LoginPage ToLoginPage()
		{
			driver.Url = "http://localhost:8080/litecart";
			return new LoginPage(driver);
		}

		public AdminPage ToAdminPage()
		{
			driver.Url = "http://localhost:8080/litecart/admin";
			return new AdminPage(driver);
		}

		public AdminCatalogPage ToAdminCatalogPage(AdminPage adminPage)
		{
			adminPage.GoToCatalog();
			return new AdminCatalogPage(driver);
		}

		public CartPage ToCartPage()
		{
			var checkout = driver.FindElement(By.CssSelector("a[href*=checkout]"));
			checkout.Click();
			WebDriverWait wait =new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			wait.Until(ExpectedConditions.TitleContains("Checkout"));
			wait = new WebDriverWait(driver, TimeSpan.Zero);
			return new CartPage(driver);
		}

	}
}
