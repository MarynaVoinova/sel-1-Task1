using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Task1Setup
{
	[TestFixture]
	public class CheckProductTest
	{
		private IWebDriver driver;
		private Navigator navigator;
		private ProductsPage productPage;

		[SetUp]
		public void Start()
		{
			driver = new ChromeDriver();
			navigator = new Navigator(driver);
			productPage = navigator.ToProductsPage();
		}

		[Test]
		public void CheckProduct()
		{
			var products = productPage.DetailedProducts;
			for (int i = 0; i < products.Count; i++)
			{
				CheckCampaignPriceFontSizeBiggerRegularPrice(products[i]);
				var productDetailsPage = products[i].NavigateToProductDetails();
				Assert.AreEqual(
					products[i].Name, productDetailsPage.Title, "the wrong page is opened");
				ProductDetails productDetails = productDetailsPage.Product;
				CheckCampaignPriceFontSizeBiggerRegularPrice(productDetails);
				CompareProducts(products[i], productDetails);
				productPage = navigator.ToProductsPage();
				products = productPage.DetailedProducts;
			}
		}

		private static void CheckCampaignPriceFontSizeBiggerRegularPrice(ProductDetails product)
		{
			if (!product.IsCampaignFontSizeBigger())
			{
				Assert.Fail($"The CampaignPriseFontSize is bigger for {product.Name} ");
			}
		}

		private void CompareProducts(ProductDetails product1, ProductDetails product2)
		{
			if (product1.RegularPrice != product2.RegularPrice)
			{
				Assert.Fail("The Regular prices are different for the same product");
			}
			if (product1.CampaignPrice != product2.CampaignPrice)
			{
				Assert.Fail("The Campaign prices are different for the same product");
			}
			if (product1.Name != product2.Name)
			{
				Assert.Fail("The Names are different for the same product");
			}
			if (product1.CampaignPriceColor != product2.CampaignPriceColor)
			{
				Assert.Fail("The Colors for the Campaign price are different for the same product");
			}
			if (product1.CampaignPriceColor != product2.CampaignPriceColor)
			{
				Assert.Fail("The Colors for the Campaign price are different for the same product");
			}
			if (!IsGray(product1.RegularPriceColor) || !IsGray(product2.RegularPriceColor))
			{
				Assert.Fail("The Color for the Regular price is not gray");
			}
			if (!IsFontNormal(product1.RegularPriceFontWeight) || !IsFontNormal(product2.RegularPriceFontWeight))
			{
				Assert.Fail("The font-weight for the Regular price not normal");
			}
			if (!IsFontBold(product1.CampaignPriceFontDecoration) || !IsFontBold(product2.CampaignPriceFontDecoration))
			{
				Assert.Fail("The font for the Campaign price is not bold");
			}
			if (product1.RegularPriceFontWeight != product2.RegularPriceFontWeight)
			{
				Assert.Fail("The FontWeight for the RegularPrice price are different for the same product");
			}
			if (product1.RegularPriceFontDecoration != product2.RegularPriceFontDecoration)
			{
				Assert.Fail("The FontWeightDecoration for the CampaignPrice price are different for the same product");
			}
			if (!IsFontLineThrough(product1.RegularPriceFontDecoration) || !IsFontLineThrough(product2.RegularPriceFontDecoration))
			{
				Assert.Fail("The text is not 'line-through' forthe Regular price");
			}
		}

		private bool IsGray(string colorRgb)
		{
			string[] colorRgbArray = ConvertColorToArray(colorRgb);
			int maxColors = 3;
			for (int i = 0; i < maxColors; i++)
			{
				if (int.Parse(colorRgbArray[i]) == 102 || int.Parse(colorRgbArray[i]) == 119)
				{
					return true;
				}
			}
			return false;
		}

		private static string[] ConvertColorToArray(string colorRgb)
		{
			//rgb(204, 0, 0) //rgba(204, 0, 0 , 1)
			int startIndex = colorRgb.IndexOf("(") + 1;
			colorRgb = colorRgb.Substring(startIndex);
			startIndex = colorRgb.IndexOf(")");
			colorRgb = colorRgb.Remove(startIndex);
			string[] rgbArray = colorRgb.Split(',');
			return rgbArray;
		}

		private bool IsFontNormal(string fontWeight)
		{
			int result;
			if (fontWeight == "normal")
			{
				return true;
			}
			if (int.TryParse(fontWeight, out result))
			{
				return result == 400; //400 is normal font
			}
			return false;
		}

		private bool IsFontBold(string fontDecoration)
		{
			return fontDecoration == "strong";
		}

		public bool IsFontLineThrough(string fontDecoration)
		{
			return fontDecoration == "s";
		}

		[TearDown]
		public void Stop()
		{
			driver.Quit();
			driver = null;
		}
	}
}
