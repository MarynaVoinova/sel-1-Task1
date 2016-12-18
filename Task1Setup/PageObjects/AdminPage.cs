using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Task1Setup.PageObjects
{
	public class AdminPage
	{
		private IWebDriver driver;
		private const string username = "admin";
		private const string password = "admin";

		public AdminPage(IWebDriver driver)
		{
			this.driver = driver;
			Login(username, password);
		}

		private void Login(string username, string password)
		{
			driver.FindElement(By.Name("username")).SendKeys(username);
			driver.FindElement(By.Name("password")).SendKeys(password);
			driver.FindElement(By.Name("login")).Click();
		}

		public void GoToCatalog()
		{
			var temp = GetMainMenuElements().Find(el => el.GetAttribute("textContent") == "Catalog");
			temp.Click();
		}

		public CountriesPage GoToCountries()
		{
			GetMainMenuElements().Find(el => el.GetAttribute("textContent") == "Countries").Click();
			return new CountriesPage(driver);
		}

		private List<IWebElement> GetMainMenuElements()
		{
			return driver.FindElements(By.CssSelector("li#app- > a span.name")).ToList();
		}

		private List<IWebElement> GetSubmenuElements()
		{
			return driver.FindElements(By.CssSelector(".docs li >a .name")).ToList();
		}

	}
}