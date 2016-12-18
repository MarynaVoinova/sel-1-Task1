using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task1Setup.ElementAdapters;

namespace Task1Setup.PageObjects
{
	public class CartPage
	{
		private IWebDriver driver;
		private List<IWebElement> ProductsWithShortcut { get; set; }
		private Button RemoveBtn { get; set; }
		private List<IWebElement> RemoveButtonsList { get; set; }

		private List<IWebElement> OrderSummaryItems { get; set; }

		public CartPage(IWebDriver driver)
		{
			this.driver = driver;
			ProductsWithShortcut = GetProductsWithShortcut();

			OrderSummaryItems = driver.FindElements(By.CssSelector("[class ='dataTable rounded-corners'] td.item")).ToList();
			RemoveBtn = new Button(driver.FindElement(By.Name("remove_cart_item")));
			RemoveButtonsList = driver.FindElements(By.Name("remove_cart_item")).ToList();
		}

		public void  DeleteAllProductsInCart()
		{
			ProductsWithShortcut[0].Click();
			while (RemoveButtonsList.Count > 0)
			{
				var currentRemovedProduct = driver.FindElement(By.XPath("//*[@name='remove_cart_item']"));
				var currentNumberOfRemoveButtons = GetRemoveButtons().Count;
				var currentNumberOfProductsWithShortkut = GetProductsWithShortcut().Count;
				var removedProductName = driver.FindElement(By.XPath("//*[@name='remove_cart_item']/../..//a")).Text;
				var quantityRemovedProduct = driver.FindElement(By.Name("quantity"));
				if (int.Parse(quantityRemovedProduct.GetAttribute("value")) > 1)
				{
					quantityRemovedProduct.Clear();
					quantityRemovedProduct.SendKeys("1");
				}
				RemoveBtn = GetRemoveButtonForProduct();
				RemoveBtn.Сlick();
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
				wait.Until(
					ExpectedConditions.InvisibilityOfElementWithText(By.CssSelector("[class ='dataTable rounded-corners'] td.item"), removedProductName));
				ProductsWithShortcut = GetProductsWithShortcut();
				RemoveButtonsList = GetRemoveButtons();
				OrderSummaryItems = GetOrderSummaryItems();
			}
		}

		private List<IWebElement> GetRemoveButtons()
		{
			return driver.FindElements(By.Name("remove_cart_item")).ToList();
		}

		private List<IWebElement> GetProductsWithShortcut()
		{
			return driver.FindElements(By.CssSelector("li.shortcut a")).ToList();
		}

		private List<IWebElement> GetOrderSummaryItems()
		{
			return driver.FindElements(By.CssSelector("[class ='dataTable rounded-corners'] td.item")).ToList();
		}


		public Button GetRemoveButtonForProduct()
		{
			return new Button(driver.FindElement(By.Name("remove_cart_item")));
		}
	}
}