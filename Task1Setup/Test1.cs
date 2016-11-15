using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1Setup
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using OpenQA.Selenium;
	using OpenQA.Selenium.Support.UI;
	using NUnit.Framework;
	using OpenQA.Selenium.Chrome;

	namespace csharp_example
	{
		[TestClass]
		public class MyFirstTest
		{
			private IWebDriver driver;

			[SetUp]
			public void start()
			{
				driver = new ChromeDriver();
			}

			[Test]
			public void FirstTest()
			{
				driver.Url = "https://desktop.github.com";
			}

			[TearDown]

			public void stop()
			{
				driver.Quit();
				driver = null;
			}
		}
	}

}
