using OpenQA.Selenium;

namespace Task1Setup.ElementAdapters
{
	public class Button
	{
		private readonly IWebElement webElementButton;

		public Button(IWebElement webElementButton)
		{
			this.webElementButton = webElementButton;
		}

		public void Сlick()
		{
			webElementButton.Click();
		}
	}
}