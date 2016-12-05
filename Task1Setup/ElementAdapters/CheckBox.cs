using OpenQA.Selenium;

namespace Task1Setup.ElementAdapters
{
	public class CheckBox
	{
		private readonly IWebElement checkboxWebElement;

		public bool IsChecked
		{
			get
			{
				return checkboxWebElement.GetAttribute("checked") == "true";
			}
			set
			{
				if (value != IsChecked)
				{
					checkboxWebElement.Click();
				}
			}
		}

		public CheckBox(IWebElement checkboxWebElement)
		{
			this.checkboxWebElement = checkboxWebElement;
		}
	}
}