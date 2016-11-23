namespace Task1Setup
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using OpenQA.Selenium;
	using NUnit.Framework;
	using OpenQA.Selenium.Chrome;

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
