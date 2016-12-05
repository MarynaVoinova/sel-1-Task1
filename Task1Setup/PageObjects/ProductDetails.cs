using OpenQA.Selenium;

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

		public ProductDetails(IWebDriver driver, IWebElement productWebElement, bool isProductDetailsPage)
		{
			product = productWebElement;
			this.driver = driver;
			if (!isProductDetailsPage)
			{
				Name = product.FindElement(By.ClassName("name")).GetAttribute("textContent");
			}
			else
			{
				Name = product.FindElement(By.CssSelector("h1.title")).GetAttribute("textContent");
			}

			SetProductDetailsProperties();

		}

		private void SetProductDetailsProperties()
		{
			RegularPriceWebElement = product.FindElement(By.ClassName("regular-price"));
			CampaignPriceWebElement = product.FindElement(By.ClassName("campaign-price"));
			RegularPrice = int.Parse(GetRegularPrice());
			CampaignPrice = int.Parse(CampaignPriceWebElement.GetAttribute("textContent").Remove(0, 1));
			RegularPriceColor = RegularPriceWebElement.GetCssValue("color");
			CampaignPriceColor = CampaignPriceWebElement.GetCssValue("color");
			RegularPriceFontWeight = RegularPriceWebElement.GetCssValue("font-weight");
			CampaignPriceFontWeight = CampaignPriceWebElement.GetCssValue("font-weight");
			RegularPriceFontDecoration = RegularPriceWebElement.TagName;//TagName("s");
			CampaignPriceFontDecoration = CampaignPriceWebElement.TagName;
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
