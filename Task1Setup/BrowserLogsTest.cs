using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task1Setup.PageObjects;
using System.Diagnostics;

namespace Task1Setup
{
	[TestFixture]
	class BrowserLogsTest
	{
		private IWebDriver driver;
		private Navigator navigator;
		private AdminPage adminPage;
		private AdminCatalogPage catalogPage;

		[SetUp]
		public void Start()
		{
			ChromeOptions options = new ChromeOptions();
			options.SetLoggingPreference(LogType.Browser, LogLevel.All);
			driver = new ChromeDriver(options);
			navigator = new Navigator(driver);
			adminPage = navigator.ToAdminPage();
			catalogPage = navigator.ToAdminCatalogPage(adminPage);
		}

		[Test]
		public void BrowserLogs()
		{
			var productsInFirstCategory = catalogPage.GetAllProductslinkInCategory(1);
			for (int i = 0; i < productsInFirstCategory.Count; i++)
			{
				productsInFirstCategory[i].Сlick();
				var logs = driver.Manage().Logs.GetLog("browser").ToArray();
				PrintLogs(logs);
				Assert.IsEmpty(logs);
				catalogPage = navigator.ToAdminCatalogPage(adminPage);
				productsInFirstCategory = catalogPage.GetAllProductslinkInCategory(1);
			}
		}

		public void PrintLogs(LogEntry[] browserLogs)
		{
			foreach (var log in browserLogs)
			{
				Console.WriteLine(log.Message);
				Debug.WriteLine(log.Message);
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
