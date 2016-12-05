using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Task1Setup.ElementAdapters
{
	public class RadioButtonGroup
	{
		private readonly List<RadioButton> radioButtons;

		public RadioButtonGroup(List<IWebElement> radioButtonElements)
		{
			radioButtons = radioButtonElements.Select(el => new RadioButton(el)).ToList();
		}

		public RadioButton GetOption(string optionName)
		{
			var result = radioButtons.FirstOrDefault(b => b.OptionName == optionName);
			if (result != null)
			{
				return result;
			}
			throw new Exception($"There is no radiobutton with{optionName}");
		}

		public RadioButton GetCheckedOption()
		{
			return radioButtons.FirstOrDefault(b => b.IsChecked);
		}
	}
}
