using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task1Setup.PageObjects;

namespace Task1Setup
{
	public class CreateAccountTest
	{
		private IWebDriver driver;
		private Navigator navigator;
		private LoginPage loginPage;
		private Random randomIdEmail;

		[SetUp]
		public void Start()
		{
			driver = new ChromeDriver();
			navigator = new Navigator(driver);
			randomIdEmail = new Random();
		}

		[Test]
		public void CreateAccountLogoutLogin()
		{
			loginPage = navigator.ToLoginPage();
			var createAccount = loginPage.ClickToCreateAccountLink();
			Account newAccount = CreateAccount(createAccount);
			Logout();
			loginPage = navigator.ToLoginPage();
			loginPage.Login(newAccount.Email, newAccount.Password);
			Logout();
		}

		private void Logout()
		{
			driver.FindElement(By.CssSelector("#box-account [href*=logout]")).Click();
		}

		public Account CreateAccount(CreateAccountPage createAccount)
		{
			createAccount.TaxId.Text = "NLdddddddddBdd";
			createAccount.Company.Text = "FantomCompany";
			createAccount.FirstName.Text = "Fantomas";
			createAccount.LastName.Text = "Green";
			createAccount.Address1.Text = "Den Haag";
			createAccount.Address2.Text = "Rijswijk";
			createAccount.PostCode.Text = "4900";
			createAccount.City.Text = "Amsterdam";
			createAccount.Country.SelectByText("Netherlands");
			//createAccount.Country.SelectByText("United States");
			//createAccount.ZoneCode.SelectByText("Colorado");
			createAccount.Email.Text = $"fiona.zo@mail{randomIdEmail.Next(1, 1000)}.ru";
			createAccount.Phone.Text = "+316123456789";
			createAccount.DesiredPassword.Text = "Password01";
			createAccount.ConfirmPassword.Text = "Password01";
			createAccount.SubscribeCheckBox.IsChecked = false;
			Account newAccount = new Account(createAccount);
			createAccount.CreateAccountBtn.Сlick();
			return newAccount;
		}

		[TearDown]
		public void Stop()
		{
			driver.Quit();
			driver = null;
		}
	}
}
