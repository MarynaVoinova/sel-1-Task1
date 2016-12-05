using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task1Setup.ElementAdapters;

namespace Task1Setup.PageObjects
{
	public class InformationTab
	{
		public SelectElement Manufacturer { get; }
		public SelectElement Supplier { get; }
		public InputBox Keywords { get; }
		public InputBox ShortDescription { get; }
		public InputBox Description { get; }
		//public IWebElement Description { get; }
		public InputBox HeadTitle { get; }
		public InputBox MetaDescription { get; }

		public InformationTab(IWebElement infoTab)
		{
			Manufacturer = new SelectElement(infoTab.FindElement(By.CssSelector("[name='manufacturer_id']")));
			Supplier = new SelectElement(infoTab.FindElement(By.CssSelector("[name='supplier_id']")));
			Keywords = new InputBox(infoTab.FindElement(By.CssSelector("[name = 'keywords']")));
			ShortDescription = new InputBox(infoTab.FindElement(By.Name("short_description[en]")));
			Description = new InputBox(infoTab.FindElement(By.ClassName("trumbowyg-editor")));
			//Description = infoTab.FindElement(By.ClassName("trumbowyg-editor"));
			HeadTitle = new InputBox(infoTab.FindElement(By.Name("head_title[en]")));
			MetaDescription = new InputBox(infoTab.FindElement(By.Name("meta_description[en]")));
		}

		//public void SetDescription(string text)
		//{
		//	var descriptionWebElement = infoTab.FindElement(By.Name("meta_description[en]"));
		//	Clipboard.SetText(text);//Ctrl+C
		//	Actions ctrlVAction = new Actions(driver);
		//	ctrlVAction.KeyDown(descriptionWebElement, Keys.Control);
		//	ctrlVAction.SendKeys(descriptionWebElement, "v");
		//	ctrlVAction.KeyUp(descriptionWebElement, Keys.Control);
		//	ctrlVAction.Perform();
		//}
	}
}