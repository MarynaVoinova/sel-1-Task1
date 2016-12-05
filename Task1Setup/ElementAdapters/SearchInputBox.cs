using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Task1Setup.ElementAdapters
{
	public class SearchInputBox
	{
		private IWebElement webElement;
		private IWebDriver driver;

		public SearchInputBox(IWebDriver driver, IWebElement webElement)
		{
			this.driver = driver;
			this.webElement = webElement;
		}

		public void Search(string searchString)
		{
			webElement.Clear();
			var actions = new Actions(driver);
			actions.SendKeys(webElement, searchString);
			actions.SendKeys(Keys.Enter);
			actions.Perform();
		}

		public void Clear()
		{
			webElement.Clear();
		}
	}
}
