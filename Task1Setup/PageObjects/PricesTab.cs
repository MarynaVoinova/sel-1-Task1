using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task1Setup.ElementAdapters;

namespace Task1Setup.PageObjects
{
	public class PricesTab
	{
		public InputBox PurchasePrise { get; }
		public SelectElement PurchaseCurrency { get; }
		public SelectElement TaxClass { get; }
		public InputBox PriceUsd { get; }
		public InputBox TaxPriceUsd { get; }
		public InputBox PriceEur { get; }
		public InputBox TaxPriceEur { get; }

		public PricesTab(IWebElement pricesTab)
		{
			PurchasePrise = new InputBox(pricesTab.FindElement(By.CssSelector("[name='purchase_price']")));
			PurchaseCurrency = new SelectElement(pricesTab.FindElement(By.CssSelector("[name='purchase_price_currency_code']")));
			TaxClass = new SelectElement(pricesTab.FindElement(By.Name("tax_class_id")));
			PriceUsd = new InputBox(pricesTab.FindElement(By.Name("prices[USD]")));
			TaxPriceUsd = new InputBox(pricesTab.FindElement(By.Name("gross_prices[USD]")));
			PriceEur = new InputBox(pricesTab.FindElement(By.Name("prices[EUR]")));
			TaxPriceEur = new InputBox(pricesTab.FindElement(By.Name("gross_prices[EUR]")));
		}
	}
}