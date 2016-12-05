using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Task1Setup.PageObjects
{
	class GeoZonesPage
	{
		private IWebElement geoZonesTable;
		private const int CountryColumnId =3;
		//private readonly int geoZonesRowsCount;

		public GeoZonesPage(IWebDriver driver)
		{
			geoZonesTable = driver.FindElement(By.CssSelector("[name=geo_zones_form] .dataTable"));
			//geoZonesRowsCount = GetGeoZonesRows().Count;
		}

		public List<IWebElement> GetGeoZonesRows()
		{
			return geoZonesTable.FindElements(By.ClassName("row")).ToList();
		}

		public IWebElement  GetGeoZoneCountryLink(IWebElement geoZonesRow)
		{
			return geoZonesRow.FindElement(By.CssSelector($"td:nth-child({CountryColumnId}) a"));
		}
	}
}
