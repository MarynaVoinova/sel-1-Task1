using OpenQA.Selenium;

namespace Task1Setup.ElementAdapters
{
	public class RadioButton
	{
		private readonly IWebElement radioButtonElement;
		public string OptionName { get; }

		public bool IsChecked => radioButtonElement.GetAttribute("checked") == "true";

		public RadioButton(IWebElement radioButtonElement)
		{
			this.radioButtonElement = radioButtonElement;
			//OptionName = radioButtonElement.FindElement(By.XPath("..//*[@outerText]")).ToString();
			OptionName = radioButtonElement.FindElement(By.XPath("..")).Text;
		}

		public void Check()
		{
			if (!IsChecked)
			{
				radioButtonElement.Click();
			}
		}
	}
}