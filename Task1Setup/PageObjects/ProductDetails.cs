using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task1Setup.ElementAdapters;
using Task1Setup.Extensions;

namespace Task1Setup.PageObjects
{
	public class ProductDetails
	{
		private IWebElement product;
		private IWebElement RegularPriceWebElement;
		private IWebElement CampaignPriceWebElement;
		private IWebDriver driver;

		public string Name { get; }
		public int RegularPrice { get; private set; }
		public int CampaignPrice { get; private set; }
		public string RegularPriceColor { get; private set; }
		public string CampaignPriceColor { get; private set; }
		public string RegularPriceFontWeight { get; private set; }
		public string CampaignPriceFontWeight { get; private set; }
		public string RegularPriceFontDecoration { get; private set; }
		public string CampaignPriceFontDecoration { get; private set; }

		public SelectElement DuckSize { get; private set; }

		public Button AddToCurtBtn { get; private set; }

		public ProductDetails(IWebDriver driver, IWebElement productWebElement, bool isProductDetailsPage)
		{
			product = productWebElement;
			this.driver = driver;
			if (!isProductDetailsPage)
			{
				Name = driver.FindElement(By.ClassName("name")).GetAttribute("textContent");
			}
			else
			{
				Name = driver.FindElement(By.CssSelector("h1.title")).GetAttribute("textContent");
			}

			SetProductDetailsProperties();
		}

		private void SetProductDetailsProperties()
		{
			//RegularPriceWebElement = driver.FindElementOrDefault(By.ClassName("regular-price"));
			var regularPriceWebElements = driver.FindElements(By.ClassName("regular-price")).ToList();
			if (regularPriceWebElements.Count != 0)
			{
				RegularPriceWebElement = regularPriceWebElements.First();
				RegularPrice = int.Parse(GetRegularPrice());
				RegularPriceColor = RegularPriceWebElement.GetCssValue("color");
				RegularPriceFontWeight = RegularPriceWebElement.GetCssValue("font-weight");
				RegularPriceFontDecoration = RegularPriceWebElement.TagName;//TagName("s");
			}
			//CampaignPriceWebElement = driver.FindElementOrDefault(By.ClassName("campaign-price"));
			var campaignPriceWebElements = driver.FindElements(By.ClassName("campaign-price")).ToList();
			//if (CampaignPriceWebElement != null)
			if (campaignPriceWebElements.Count != 0)
			{
				CampaignPriceWebElement = campaignPriceWebElements.First();
				CampaignPriceColor = CampaignPriceWebElement.GetCssValue("color");
				CampaignPriceFontWeight = CampaignPriceWebElement.GetCssValue("font-weight");
				CampaignPriceFontDecoration = CampaignPriceWebElement.TagName;
				CampaignPrice = int.Parse(CampaignPriceWebElement.GetAttribute("textContent").Remove(0, 1));
			}
			//var duckSize = driver.FindElementOrDefault(By.CssSelector("[name='options[Size]']"));
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
			var duckSize = driver.FindElements(By.CssSelector("[name='options[Size]']")).ToList();
			if (duckSize.Count != 0)
			{
				DuckSize = new SelectElement(duckSize.First());
				//DuckSize.SelectByIndex(2);
				DuckSize.SelectByValue("Small");
			}
			//var addToCurtButtonEl = driver.FindElementOrDefault(By.Name("add_cart_product"));
			//var addToCurtButtonEl = WebElementExtensions.FindElementOrDefault(product, By.Name("add_cart_product"));
			var addToCurtButtonEl = product.FindElements(By.Name("add_cart_product")).FirstOrDefault();
			if (addToCurtButtonEl != null)
			{
				AddToCurtBtn = new Button(addToCurtButtonEl);
			}
		}

		private string GetRegularPrice()
		{
			var price = RegularPriceWebElement.GetAttribute("textContent");
			int indexOfCurrency = price.IndexOf("$");
			return price.Remove(indexOfCurrency, 1);
		}

		public ProductDetailsPage NavigateToProductDetails()
		{
			product.Click();
			return new ProductDetailsPage(driver);
		}

		private decimal GetRegularPriceFontSize()
		{
			var fontSize = RegularPriceWebElement.GetCssValue("font-size");
			int indexOfSubstring = fontSize.IndexOf("px");
			return decimal.Parse(fontSize.Remove(indexOfSubstring));
		}

		private decimal GetCampaignPriceFontSize()
		{
			var fontSize = CampaignPriceWebElement.GetCssValue("font-size");
			int indexOfSubstring = fontSize.IndexOf("px");
			return decimal.Parse(fontSize.Remove(indexOfSubstring));
		}

		public bool IsCampaignFontSizeBigger()
		{
			return GetCampaignPriceFontSize() > GetRegularPriceFontSize();
		}
	}
}
