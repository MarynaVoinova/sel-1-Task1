using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Task1Setup.ElementAdapters;

namespace Task1Setup.PageObjects
{
	public class EditCountryPage
	{
		private IWebElement zoneTable;
		private int zoneColumn =3;
		private IWebDriver driver;

		public EditCountryPage(IWebDriver driver)
		{
			this.driver = driver;
			zoneTable = driver.FindElement(By.CssSelector("#table-zones"));
		}

		public List<IWebElement> GetZonesColumn()
		{
			return zoneTable.FindElements(By.CssSelector($"td:nth-child({zoneColumn}")).ToList();
		}

		public List<string> GetZonesNames()
		{
			var zones = GetZonesColumn();
			var zonesNames=new List<string>();
			for (int i = 0; i <= zones.Count; i++)
			{
				List<IWebElement> zone = zoneTable.FindElements(By.CssSelector($"[name='zones[{i+1}][name]']")).ToList();
				if (zone.Count ==1)
				{
					zonesNames.Add(zone[0].GetAttribute("value"));
				}
			}
			return zonesNames;
		}

		public List<Button> GetExternalLinks()
		{
			return driver.FindElements(By.CssSelector("[class='fa fa-external-link']")).Select(link=>new Button(link)).ToList();
		}
	}
}
