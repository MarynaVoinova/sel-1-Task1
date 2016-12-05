using OpenQA.Selenium;
using Task1Setup.ElementAdapters;

namespace Task1Setup.PageObjects
{
	public class EditCatalogPage
	{
		private IWebDriver driver;
		private Button Save { get; }

		public EditCatalogPage(IWebDriver driver)
		{
			this.driver = driver;
			Save = new Button(driver.FindElement(By.CssSelector("[name='save']")));
		}

		public AdminCatalogPage ClickSaveProductBtn()
		{
			Save.Сlick();
			return new AdminCatalogPage(driver);
		}

		public GeneralTab ClickGeneralTab()
		{
			var generalTabBtn = new Button(driver.FindElement(By.CssSelector("[href *= '#tab-general']")));
			generalTabBtn.Сlick();
			var generalTab = driver.FindElement(By.CssSelector("div #tab-general"));
			return new GeneralTab(generalTab);
		}

		public InformationTab ClickInformationTab()
		{
			var infoTabBtn = driver.FindElement(By.CssSelector("[href *= '#tab-information']"));
			infoTabBtn.Click();
			var infoTab = driver.FindElement(By.CssSelector("div #tab-information"));
			return new InformationTab(infoTab);
		}

		public PricesTab ClickPricesTab()
		{
			var pricesTabBtn = driver.FindElement(By.CssSelector("[href *= '#tab-prices']"));
			pricesTabBtn.Click();
			var pricesTab = driver.FindElement(By.CssSelector("div #tab-prices"));
			return new PricesTab(pricesTab);
		}
	}
}