using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Task1Setup
{
	public class ProductsPage
	{
		private readonly IWebDriver driver;
		private IWebElement campaigns;
		public List<ProductDetails> DetailedProducts;
		private List<IWebElement> CampaignProducts { get; }

		public ProductsPage(IWebDriver driver)
		{
			this.driver = driver;
			campaigns = driver.FindElement(By.Id("box-campaigns"));
			CampaignProducts = campaigns.FindElements(By.CssSelector(".content a.link")).ToList();
			DetailedProducts = GetDetailedProducts();
		}

		private List<ProductDetails> GetDetailedProducts()
		{
			return CampaignProducts.Select(el => new ProductDetails(driver, el, false)).ToList();
		}
	}
}
