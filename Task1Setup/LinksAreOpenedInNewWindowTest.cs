using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Task1Setup.PageObjects;

namespace Task1Setup
{
	class LinksAreOpenedInNewWindowTest
	{
		private IWebDriver driver;
		private Navigator navigator;
		private WebDriverWait wait;

		[SetUp]
		public void Start()
		{
			driver = new ChromeDriver();
			//FirefoxOptions options = new FirefoxOptions();
			//options.UseLegacyImplementation = true;
			//driver = new FirefoxDriver(options);
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
			navigator = new Navigator(driver);
		}

		[Test]
		public void LinksAreOpenedInNewWindow()
		{
			var adminPage = navigator.ToAdminPage();
			var countriesPage = adminPage.GoToCountries();
			countriesPage.GetCountriesColumnButtons().First().Сlick();
			var countryEditPage = new EditCountryPage(driver);
			var externalLinks = countryEditPage.GetExternalLinks();
			var mainWindow = driver.CurrentWindowHandle;
			List<string> oldWindows = driver.WindowHandles.ToList();
			for (int i = 0; i < externalLinks.Count; i++)
			{
				externalLinks[i].Сlick();
				string newWindow = wait.Until(AnyWindowOtherThanThat(oldWindows));
				driver.SwitchTo().Window(newWindow);
				driver.Close();
				driver.SwitchTo().Window(mainWindow);
			}
			driver.Close();
		}
		private Func<IWebDriver, string> AnyWindowOtherThanThat(List<string> oldWindows)
		{
			return d =>
			{
				var currentWindows = d.WindowHandles.ToList();
				currentWindows.RemoveAll(el => oldWindows.Contains(el));
				return currentWindows.Count > 0 ? currentWindows.First() : null;
			};
		}

		[TearDown]
		public void Stop()
		{
			driver.Quit();
			driver = null;
		}
	}
}
