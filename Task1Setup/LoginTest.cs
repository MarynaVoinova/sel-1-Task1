using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task1Setup
{
	[TestFixture]
	public class LoginTest
	{
		private IWebDriver driver;

		[SetUp]
		public void Start()
		{
			driver = new ChromeDriver();
		}

		[Test]
		public void LoginTestAdmin()
		{
			driver.Url = "http://localhost:8080/litecart/admin/";
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();
		}

		[TearDown]
		public void Stop()
		{
			driver.Quit();
			driver = null;
		}
	}
}
