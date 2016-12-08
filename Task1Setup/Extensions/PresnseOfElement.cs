using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Task1Setup.Extensions
{
	public static class PresnseOfElement
	{
		public static bool IsElementNotPresent(IWebDriver driver, By locator)
		{
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
			return driver.FindElements(locator).Count == 0;
		}
	}
}
