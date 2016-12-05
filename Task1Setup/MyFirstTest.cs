using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task1Setup
{
	namespace csharp_example
	{
		[TestClass]
		public class MyFirstTest
		{
			private IWebDriver driver;

			[SetUp]
			public void Start()
			{
				driver = new ChromeDriver();
			}

			[Test]
			public void FirstTest()
			{
				driver.Url = "https://desktop.github.com";
			}

			[TearDown]
			public void Stop()
			{
				driver.Quit();
				driver = null;
			}
		}
	}

}
