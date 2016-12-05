using System;
using OpenQA.Selenium;

namespace Task1Setup.PageObjects
{
	public class LoginPage
	{
		private IWebDriver driver;
		public string url = "http://localhost:8080/litecart/en/";
		private IWebElement LoginForm { get; }
		private IWebElement EmailAddress { get; }
		private IWebElement Password { get;}
		public IWebElement LoginBtn { get; }
		public IWebElement CreateAccountLink { get; }

		public LoginPage(IWebDriver driver)
		{
			this.driver = driver;
			driver.Url = url;
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
			LoginForm = driver.FindElement(By.Name("login_form"));
			EmailAddress = LoginForm.FindElement(By.Name("email"));
			Password = LoginForm.FindElement(By.Name("password"));
			LoginBtn = LoginForm.FindElement(By.Name("login"));
			CreateAccountLink = LoginForm.FindElement(By.CssSelector("a"));
		}

		public void Login(string email, string password)
		{
			EmailAddress.SendKeys(email);
			Password.SendKeys(password);
			LoginBtn.Click();
		}

		public CreateAccountPage ClickToCreateAccountLink()
		{
			CreateAccountLink.Click();
			return new CreateAccountPage(driver);
		}

	}
}