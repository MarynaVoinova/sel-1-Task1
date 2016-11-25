using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Task1Setup
{
	class GeoZonesEditPage
	{
		private IWebElement geoZonesTable;
		private const int ZoneIdColumn = 3;

		public GeoZonesEditPage(IWebDriver driver)
		{
			geoZonesTable = driver.FindElement(By.Id("table-zones"));
		}

		public List<IWebElement> GetGeoZonesElements()
		{
			return geoZonesTable.FindElements(By.CssSelector($"tr td:nth-child({ZoneIdColumn})")).ToList();
		}

		public string GetGeoZoneText(IWebElement geoZonesElement)
		{
			var elements = geoZonesElement.FindElements(By.CssSelector("option[selected = selected]"));
			if (!elements.Any())
				return null;

			return elements.First().Text;
		}

		public List<string> GetAllSelectedGeoZonesNames()
		{
			return GetGeoZonesElements().Select(GetGeoZoneText).Where(name => name != null).ToList();
		}
	}
}
