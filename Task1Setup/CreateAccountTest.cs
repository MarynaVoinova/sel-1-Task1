using System;
using System.Drawing.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task1Setup
{
	public class CreateAccountTest
	{
		private IWebDriver driver;

		[SetUp]
		public void Start()
		{
			driver = new ChromeDriver();
		}

		[Test]
		public void CreateAccount()
		{
			driver.Url = "http://localhost:8080/litecart/admin";
			driver.FindElement(By.Name("login")).SendKeys("admin");
			//driver.FindElement(By.CssSelector("form[name = 'login_form'] a")).Click();
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();
			driver.FindElements(By.Name("login"));

		}

		[TearDown]
		public void Stop()
		{
			//driver.Quit();
			//driver = null;
		}

	}

}
