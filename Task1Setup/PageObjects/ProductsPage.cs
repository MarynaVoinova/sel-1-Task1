using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Task1Setup.PageObjects
{
	public class ProductsPage
	{
		private readonly IWebDriver driver;
		private IWebElement campaigns;
		public List<ProductDetails> DetailedProducts;

		private List<IWebElement> CampaignProducts { get; }
		private List<IWebElement> MostPoplarProducts { get; }
		private List<IWebElement> LatestProducts { get; }

		public ProductsPage(IWebDriver driver)
		{
			this.driver = driver;
			campaigns = driver.FindElement(By.Id("box-campaigns"));
			CampaignProducts = campaigns.FindElements(By.CssSelector(".content a.link")).ToList();
			DetailedProducts = GetDetailedProducts();
			MostPoplarProducts = driver.FindElements(By.CssSelector("#box-most-popular a.link")).ToList();
			LatestProducts = driver.FindElements(By.CssSelector("#box-latest-products a.link")).ToList();
		}

		private List<ProductDetails> GetDetailedProducts()
		{
			return CampaignProducts.Select(el => new ProductDetails(driver, el, false)).ToList();
		}

		public ProductDetailsPage ClickAnyProduct()
		{
			List<IWebElement> allProductsInCategories = new List<IWebElement>();
			allProductsInCategories = MostPoplarProducts.ToList();
			//allProductsInCategories.AddRange(CampaignProducts);
			allProductsInCategories.AddRange(LatestProducts);
			Random random = new Random();
			int randomNumber = random.Next(0, allProductsInCategories.Count);
			allProductsInCategories[randomNumber].Click();
			return new ProductDetailsPage(driver);
		}
	}
}
