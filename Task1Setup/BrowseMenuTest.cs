using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task1Setup
{
	[TestFixture]
	public class BrowseMenuTest
	{
		private IWebDriver driver;

		[SetUp]
		public void Start()
		{
			driver = new ChromeDriver();
			driver.Url = "http://localhost:8080/litecart/admin/";
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();
		}

		[Test]
		public void BrowseMenu()
		{
			List<IWebElement> mainMenuElements = GetMainMenuElements();

			for (int i = 0; i < mainMenuElements.Count; i++)
			{
				mainMenuElements[i].Click();
				mainMenuElements = GetMainMenuElements();
				ValidateTitle(mainMenuElements[i]);
				//driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
				var submenuElements = GetSubmenuElements();
				if (submenuElements.Count != 0)
				{
					TraverseSubmenu(submenuElements);
				}
				mainMenuElements = GetMainMenuElements();
			}
		}
		private List<IWebElement> GetMainMenuElements()
		{
			return driver.FindElements(By.CssSelector("li#app- > a span.name")).ToList();
		}

		private List<IWebElement> GetSubmenuElements()
		{
			return driver.FindElements(By.CssSelector(".docs li >a .name")).ToList();
		}

		private void TraverseSubmenu(List<IWebElement> subMenuElements)
		{
			for (int j = 0; j < subMenuElements.Count; j++)
			{
				subMenuElements[j].Click();
				subMenuElements = GetSubmenuElements();
				ValidateTitle(subMenuElements[j]);
			}
		}

		private void ValidateTitle(IWebElement menuElement)
		{
			if (string.IsNullOrEmpty(driver.Title))
			{
				throw new Exception($"The page corresponding to the menu item '{menuElement.Text}' has no Title");
			}
		}

		[TearDown]
		public void Stop()
		{
			driver.Quit();
			driver = null;
		}
	}
}
