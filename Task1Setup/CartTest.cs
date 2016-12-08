using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task1Setup.PageObjects;

namespace Task1Setup
{
	public class CartTest
	{
		private IWebDriver driver;
		private Navigator navigator;

		[SetUp]
		public void Start()
		{
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
			navigator = new Navigator(driver);
		}

		[Test]
		public void Cart()
		{
			var productsPage = navigator.ToProductsPage();
			for (int i = 0; i < 3; i++)
			{
				ProductDetailsPage productDetailedPage = productsPage.ClickAnyProduct();
				int currentNumberOfProductsInCart = productDetailedPage.Cart.NumberOfProductsInCart;
				ProductDetails product = productDetailedPage.Product;
				product.AddToCurtBtn.Сlick();
				productDetailedPage.Cart.WaitUntilCartNumberOfProductsIsRefreshed(i + 1);
				Assert.AreNotSame(currentNumberOfProductsInCart, productDetailedPage.Cart.NumberOfProductsInCart);
				productsPage = navigator.ToProductsPage();
			}
			var cartPage = navigator.ToCartPage();
			cartPage.DeleteAllProductsInCart();

		}

		[TearDown]
		public void Stop()
		{
			driver.Quit();
			driver = null;
		}
	}
}
