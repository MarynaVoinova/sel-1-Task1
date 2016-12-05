using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task1Setup.PageObjects;

namespace Task1Setup
{
	[TestFixture]
	class AddProductTest
	{
		private IWebDriver driver;
		private Navigator navigator;
		private AdminPage adminPage;

		[SetUp]
		public void Start()
		{
			driver = new ChromeDriver();
			navigator = new Navigator(driver);
			adminPage = navigator.ToAdminPage();
		}

		[Test]
		public void AddProduct()
		{
			string newProductName = "AliveDuck!";
			var adminCatalogPage = navigator.ToAdminCatalogPage(adminPage);
			var numberOfNewProductsBeforeAdding = adminCatalogPage.GetNumberOfProducts(newProductName);

			var editCatalogPage = adminCatalogPage.ClickAddNewProduct();
			var generalTab = editCatalogPage.ClickGeneralTab();
			generalTab.Status.GetOption("Enabled").Check();
			generalTab.Name.Text = newProductName;
			generalTab.Code.Text = "dd01";
			generalTab.RootCategoty.IsChecked = false;
			generalTab.RubberDucksCategory.IsChecked = true;
			generalTab.SubCategory.IsChecked = true;
			generalTab.DefaultCategory.SelectByText("Subcategory");
			generalTab.FemaleProductGroup.IsChecked = true;
			generalTab.UniSexProductGroup.IsChecked = true;
			generalTab.UploadImage[0].Text = GetFileUploadPath("Images\\duck.jpg");
			generalTab.DateValidFrom.Text = "02.12.2016";
			generalTab.DateValidTo.Text = "02.12.2018";

			var infoTab = editCatalogPage.ClickInformationTab();
			infoTab.Manufacturer.SelectByText("ACME Corp.");
			infoTab.Keywords.Text = "Duck, new added";
			infoTab.ShortDescription.Text = "Alive Duck";
			var description = "There is a special gland called the ‘Preen Gland’ near the ducks tail.This tiny gland produces oil which the duck uses to coat its feathers.Ducks have webbed feet, which are designed for swimming. Their webbed feet act like paddles for the ducks. The reason ducks can swim in cold water is their amazing circulatory system. Their blood vessels are laid out very close to each other in their legs and feet in a network that allows the warm and cool blood to exchange heat. This allows the warm blood going from the body into the feet to warm the cooler blood re-entering the body from the feet, and the blood going to the feet is cooled enough that the cold does not bother the duck";
			//infoTab.SetDescription(description);
			infoTab.Description.Text = description;
			infoTab.HeadTitle.Text = "Alive Duck";
			infoTab.MetaDescription.Text = "alive-duck";

			var pricesTab = editCatalogPage.ClickPricesTab();
			pricesTab.PurchasePrise.Text = "5.56";
			pricesTab.PurchaseCurrency.SelectByValue("USD");
			pricesTab.PriceUsd.Text = "80";

			//editCatalogPage.Save.Сlick();
			adminCatalogPage = editCatalogPage.ClickSaveProductBtn();
			//adminCatalogPage.SearchBox.Search(newProductName);
			//adminCatalogPage=new AdminCatalogPage(driver);
			//Assert.True(adminCatalogPage.IsProductFound());
			Assert.True(numberOfNewProductsBeforeAdding < adminCatalogPage.GetNumberOfProducts(newProductName));
		}

		public string GetFileUploadPath(string relativeFilePath)
		{
			return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);
		}

		[TearDown]
		public void Stop()
		{
			driver.Quit();
			driver = null;
		}
	}
}
