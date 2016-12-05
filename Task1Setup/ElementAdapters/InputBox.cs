using OpenQA.Selenium;

namespace Task1Setup.ElementAdapters
{
	public class InputBox
	{
		private readonly IWebElement webElement;

		public string Text
		{
			get { return webElement.GetAttribute("value"); }
			set { webElement.SendKeys(value); }
		}

		public InputBox(IWebElement webElement)
		{
			this.webElement = webElement;
		}
	}
}
