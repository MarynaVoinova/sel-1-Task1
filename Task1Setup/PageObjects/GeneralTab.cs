using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task1Setup.ElementAdapters;

namespace Task1Setup.PageObjects
{
	public class GeneralTab

	{
		private readonly IWebElement generalTab;

		public InputBox Name { get; }
		public InputBox Code { get; }
		public RadioButtonGroup Status { get; }
		public CheckBox RootCategoty { get; }
		public CheckBox RubberDucksCategory { get; }
		public CheckBox SubCategory { get; }
		public SelectElement DefaultCategory { get; }
		public CheckBox FemaleProductGroup { get; }
		public CheckBox MaleProductGroup { get; }
		public CheckBox UniSexProductGroup { get; }
		public List<InputBox> UploadImage { get; }
		public InputBox DateValidFrom { get; }
		public InputBox DateValidTo { get; }

		public GeneralTab(IWebElement generalTab)
		{
			this.generalTab = generalTab;
			Status = new RadioButtonGroup(generalTab.FindElements(By.CssSelector("[type=radio][name=status")).ToList());
			Name = new InputBox(generalTab.FindElement(By.Name("name[en]")));
			Code = new InputBox(generalTab.FindElement(By.Name("code")));
			//RootCategoty=new CheckBox(driver.FindElement(By.CssSelector("[data-name='Root']")));
			//RubberDucksCategory = new CheckBox(driver.FindElement(By.CssSelector("['data-name'='Rubber Ducks']")));
			//SubCategory = new CheckBox(driver.FindElement(By.CssSelector("['data-name'='Subcategory']")));
			RootCategoty = new CheckBox(generalTab.FindElement(By.CssSelector("[name='categories[]'][value='0']")));
			RubberDucksCategory = new CheckBox(generalTab.FindElement(By.CssSelector("[name='categories[]'][value='1']")));
			SubCategory = new CheckBox(generalTab.FindElement(By.CssSelector("[name='categories[]'][value='2']")));
			DefaultCategory = new SelectElement(generalTab.FindElement(By.CssSelector("[name='default_category_id']")));
			FemaleProductGroup = new CheckBox(generalTab.FindElement(By.CssSelector("[value='1-2'")));
			MaleProductGroup = new CheckBox(generalTab.FindElement(By.CssSelector("[value='1-1'")));
			UniSexProductGroup = new CheckBox(generalTab.FindElement(By.CssSelector("[value='1-3'")));
			UploadImage = UploadImages();
			DateValidFrom = new InputBox(generalTab.FindElement(By.CssSelector("[name='date_valid_from']")));
			DateValidTo = new InputBox(generalTab.FindElement(By.CssSelector("[name='date_valid_to']")));
		}
		private List<InputBox> UploadImages()
		{
			var images = new List<InputBox>();
			var uploadImages = generalTab.FindElements(By.CssSelector("[name='new_images[]']")).ToList();//.Select(el=>new InputBox(el));
			foreach (var imagePath in uploadImages)
			{
				images.Add(new InputBox(imagePath));
			}
			return images;
		}
	}
}