using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Task1Setup.ElementAdapters;

namespace Task1Setup.PageObjects
{
	public class CountriesPage
	{
		private const int CountryColumn = 5;
		private IWebDriver driver;

		public CountriesPage(IWebDriver driver)
		{
			this.driver = driver;
		}
		public List<Button> GetCountriesColumnButtons()
		{
			return driver.FindElements(By.CssSelector($"[name='countries_form'] .dataTable td:nth-child({CountryColumn}) a")).Select(el=>new Button(el)).ToList();
		}
	}
}
