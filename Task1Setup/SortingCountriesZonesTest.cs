using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task1Setup.PageObjects;

namespace Task1Setup
{
	[TestFixture]
	public class SortingCountriesZonesTest
	{
		private IWebDriver driver;
		private int countryColumn = 5;
		private int zoneColumn = 6;

		[SetUp]
		public void Start()
		{
			driver = new ChromeDriver();
			driver.Url = "http://localhost:8080/litecart/admin/?app=countries&doc=countries";
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();
		}


		[Test]
		public void Countries_SortedAlphabetically()
		{
			var countriesNames = GetCountriesNames();
			ValidateAlphabetical(countriesNames);
		}

		[Test]
		public void EditCountries_ZonesSortedAlphabetically()
		{
			List<IWebElement> countriesWithZones = GetCountriesWithNotEmptyZones();
			for (int i = 0; i < countriesWithZones.Count; i++)
			{
				var currentUrl = driver.Url;
				countriesWithZones[i].FindElement(By.CssSelector("a")).Click();
				var editPage = new EditCountryPage(driver);
				List<string> zoneNames = editPage.GetZonesNames();
				ValidateAlphabetical(zoneNames);
				driver.Url = currentUrl;
				countriesWithZones = GetCountriesWithNotEmptyZones();
			}
		}
		[Test]
		public void EditGeoZones_SortedAlphabetically()
		{
			//SortingCountries();
			//SortingZones();
			driver.Url = "http://localhost:8080/litecart/admin/?app=geo_zones&doc=geo_zones";
			var geoZonePage = new GeoZonesPage(driver);
			List<IWebElement> geoZones = geoZonePage.GetGeoZonesRows();
			var currentUrl = driver.Url;
			for (int i = 0; i < geoZones.Count; i++)
			{
				geoZonePage.GetGeoZoneCountryLink(geoZones[i]).Click();
				var geoZoneEditPage = new GeoZonesEditPage(driver);
				var geoZoneNames = geoZoneEditPage.GetAllSelectedGeoZonesNames();
				ValidateAlphabetical(geoZoneNames);
				driver.Url = currentUrl;
				geoZonePage = new GeoZonesPage(driver);
				geoZones = geoZonePage.GetGeoZonesRows();
			}
		}

		private void ValidateAlphabetical(List<string> list)
		{
			if (!IsAlphabetical(list))
			{
				throw new Exception($"The list '{list}' is not sorted alphabetically ");
			}
		}

		public bool IsIdenticalList(List<string> list1, List<string> list2)
		{
			if (list1.Count != list2.Count)
			{
				return false;
			}
			for (int i = 0; i < list1.Count; i++)
			{
				if (list1[i] != list2[i])
				{
					return false;
				}
			}
			return true;
		}

		public bool IsAlphabetical(List<string> list)
		{
			var sortedList = list.ToList();
			sortedList.Sort();
			if (!IsIdenticalList(list, sortedList))
			{
				return false; //throw new Exception($"The list '{list}' is not sorted alphabetically ");
			}
			return true;
		}

		public List<IWebElement> GetCountriesWithNotEmptyZones()
		{
			List<int> zones = GetNumberZones();
			List<IWebElement> countries = GetCountriesColumn();

			var countriesWithNotEmptyZones = new List<IWebElement>();

			for (int i = 0; i < countries.Count; i++)
			{
				if (zones[i] != 0)
				{
					countriesWithNotEmptyZones.Add(countries[i]);
				}
			}
			return countriesWithNotEmptyZones;
		}
		public List<IWebElement> GetCountriesColumn()
		{
			return driver.FindElements(By.CssSelector($"[name='countries_form'] .dataTable td:nth-child({countryColumn})")).ToList();
		}

		public List<string> GetCountriesNames()
		{
			return GetCountriesColumn().Select(country => country.Text).ToList(); ;
		}

		public List<IWebElement> GetZoneColumn()
		{
			return driver.FindElements(By.CssSelector($"[name='countries_form'] .dataTable td:nth-child({zoneColumn})")).ToList();
		}

		public List<int> GetNumberZones()
		{
			return GetZoneColumn().Select(zone => int.Parse(zone.GetAttribute("outerText"))).ToList();
		}
		public IWebElement GetCountryRow(IWebElement countryColumnWebElement)
		{
			IWebElement countryRow = countryColumnWebElement.FindElement(By.XPath(".."));
			return countryRow.FindElement(By.CssSelector($"td:nth-child({countryColumn})"));
		}

		[TearDown]
		public void Stop()
		{
			driver.Quit();
			driver = null;
		}
	}
}

