using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task1Setup.ElementAdapters;

namespace Task1Setup.PageObjects
{
	public class CreateAccountPage
	{
		public InputBox TaxId { get; }
		public InputBox Company { get; }
		public InputBox FirstName { get; }
		public InputBox LastName { get; }
		public InputBox Address1 { get; }
		public InputBox Address2 { get; }
		public InputBox PostCode { get; }
		public InputBox City { get; }
		public SelectElement Country { get; }
		public SelectElement ZoneCode { get; }
		public InputBox Email { get; }
		public InputBox Phone { get; }
		public CheckBox SubscribeCheckBox { get; }
		public InputBox DesiredPassword { get; }
		public InputBox ConfirmPassword { get; }
		public Button CreateAccountBtn { get; }
		public InputBox AcceptCookies { get; }

		public CreateAccountPage(IWebDriver driver)
		{
			TaxId = new InputBox(driver.FindElement(By.Name("tax_id")));
			Company = new InputBox(driver.FindElement(By.Name("company")));
			FirstName = new InputBox(driver.FindElement(By.Name("firstname")));
			LastName = new InputBox(driver.FindElement(By.Name("lastname")));
			Address1 = new InputBox(driver.FindElement(By.Name("address1")));
			Address2 = new InputBox(driver.FindElement(By.Name("address2")));
			PostCode = new InputBox(driver.FindElement(By.Name("postcode")));
			City = new InputBox(driver.FindElement(By.Name("city")));
			Country = new SelectElement(driver.FindElement(By.Name("country_code")));
			ZoneCode = new SelectElement(driver.FindElement(By.CssSelector("select[name='zone_code']")));
			Email = new InputBox(driver.FindElement(By.Name("email")));
			Phone = new InputBox(driver.FindElement(By.Name("phone")));
			SubscribeCheckBox = new CheckBox(driver.FindElement(By.Name("newsletter")));
			DesiredPassword = new InputBox(driver.FindElement(By.Name("password")));
			ConfirmPassword = new InputBox(driver.FindElement(By.Name("confirmed_password")));
			CreateAccountBtn = new Button(driver.FindElement(By.Name("create_account")));
			AcceptCookies = new InputBox(driver.FindElement(By.Name("accept_cookies")));
		}
	}
}
