using NUnit.Framework;
using Task1Setup.PageObjects;

namespace Task1Setup
{
	public class CartTest
	{
		private Navigator navigator;

		[SetUp]
		public void Start()
		{
			navigator = new Navigator();
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
			navigator.StopDriver();
		}
	}
}
