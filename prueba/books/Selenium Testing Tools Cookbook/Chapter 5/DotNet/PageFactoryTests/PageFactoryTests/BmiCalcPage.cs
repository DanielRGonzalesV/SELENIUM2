using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace PageFactoryTests
{
    public class BmiCalcPage
    {
        static string Url = "http://dl.dropbox.com/u/55228056/bmicalculator.html";
        private static string Title = "BMI Calculator";

        [FindsBy(How = How.Id, Using = "heightCMS")]
	    [CacheLookup]
	    private IWebElement HeightField;
	  
	    [FindsBy(How = How.Id, Using = "weightKg")]
	    private IWebElement WeightField;
	
	    [FindsBy(How = How.Id, Using = "Calculate")]
	    private IWebElement CalculateButton;
	  
	    [FindsBy(How = How.Name, Using = "bmi")]
	    private IWebElement BmiField;
	  
	    [FindsBy(How = How.Name, Using = "bmi_category")]
	    private IWebElement BmiCategoryField;

        private IWebDriver driver;

        public BmiCalcPage() {
            driver = new ChromeDriver(@"C:\ChromeDriver");
            PageFactory.InitElements(driver, this);
        }

        public void Load()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void Close()
        {
            driver.Close();
        }

        public bool IsLoaded
        {
            get { return driver.Title.Equals(Title); }
        }

        public void CalculateBmi(String height, String weight)
        {
            HeightField.SendKeys(height);
            WeightField.SendKeys(weight);
            CalculateButton.Click();
        }

        public String Bmi
        {
            get { return BmiField.GetAttribute("value"); }
        }

        public String BmiCategory
        {
            get { return BmiCategoryField.GetAttribute("value"); }
        }
    }
}
