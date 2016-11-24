using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task1Setup
{
	[TestFixture]
	public class StickerTest
	{
		private IWebDriver driver;

		[SetUp]
		public void Start()
		{
			driver = new ChromeDriver();
			driver.Url = "http://localhost:8080/litecart/";
		}

		[Test]
		public void CheckStickers()
		{
			var incorrectProducts = new List<IWebElement>();
			var productElements = GetProductItemsList();
			foreach (var product in productElements)
			{
				var numberOfStickers = product.FindElements(By.ClassName("sticker")).Count;
				if (numberOfStickers != 1)
				{
					incorrectProducts.Add(product);
				}
			}
			if (incorrectProducts.Count != 0)
			{
				var incorrectProductNames = incorrectProducts.Select(product => product.Text);
				var incorrectProductNamesText = string.Join(",", incorrectProductNames);
				throw new Exception(
					$"The # of stickers is not 1 in following products: {incorrectProductNamesText}");
			}
		}

		List<IWebElement> GetProductItemsList()
		{
			return driver.FindElements(By.CssSelector(".content a.link")).ToList();
		}

		[TearDown]
		public void Stop()
		{
			driver.Quit();
			driver = null;
		}
	}
}
