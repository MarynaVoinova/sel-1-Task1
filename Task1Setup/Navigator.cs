using OpenQA.Selenium;

namespace Task1Setup
{
	public class Navigator
	{
		IWebDriver driver;

		public Navigator(IWebDriver driver)
		{
			this.driver = driver;
		}
		public ProductsPage ToProductsPage()
		{
			driver.Url = "http://localhost:8080/litecart";
			return new ProductsPage(driver);
		}

	}
}
