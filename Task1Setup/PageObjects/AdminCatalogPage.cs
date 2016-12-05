using System;
using OpenQA.Selenium;
using Task1Setup.ElementAdapters;

namespace Task1Setup.PageObjects
{
	public class AdminCatalogPage
	{
		private IWebDriver driver;
		private IWebElement AddNewProductBtn { get; set; }
		public SearchInputBox SearchBox { get; set; }

		private IWebElement CatalogDataTable { get; set; }
		private IWebElement DataTableFooter { get; set; }

		public AdminCatalogPage(IWebDriver driver)
		{
			this.driver = driver;
			Refresh();
		}

		private void Refresh()
		{
			AddNewProductBtn = driver.FindElement(By.CssSelector("a.button[href*='edit_product']"));
			SearchBox = new SearchInputBox(driver, driver.FindElement(By.CssSelector("[type=search]")));
			CatalogDataTable = driver.FindElement(By.ClassName("dataTable"));
			DataTableFooter = CatalogDataTable.FindElement(By.ClassName("footer"));
		}

		public EditCatalogPage ClickAddNewProduct()
		{
			AddNewProductBtn.Click();
			return new EditCatalogPage(driver);
		}

		private bool IsProductFound()
		{
			if (DataTableFooter.GetAttribute("innerText") != "Products: 0")
			{
				return true;
			}
			return false;
		}

		public int GetNumberOfProducts(string productName)
		{
			SearchBox.Search(productName);
			Refresh();

			if (IsProductFound())
			{
				var footer = DataTableFooter.GetAttribute("innerText");
				int startIndex = footer.LastIndexOf(":");
				return Int32.Parse(footer.Substring(startIndex + 1));
			}
			return 0;
		}
	}
}