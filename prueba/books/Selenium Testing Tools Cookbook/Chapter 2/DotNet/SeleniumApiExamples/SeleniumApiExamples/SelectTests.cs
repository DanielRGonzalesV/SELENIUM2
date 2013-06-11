using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SeleniumApiExamples
{
    [TestFixture]
    public class SelectTests
    {
        private IWebDriver driver;

        [TestFixtureSetUp]
        public void Setup() 
        {
            driver = new ChromeDriver(@"C:\ChromeDriver\");
            driver.Navigate().GoToUrl("https://dl.dropbox.com/u/55228056/Config.html");
        }

        [TestCase]
        public void TestDropdown()
        {
 		    //Get the Dropdown as a Select using it's name attribute
 		    SelectElement make = new SelectElement(driver.FindElement(By.Name("make")));
 		
 		    //Verify Dropdown does not support multiple selection
 		    Assert.IsFalse(make.IsMultiple);
 		    //Verify Dropdown has four options for selection
    	    Assert.AreEqual(4, make.Options.Count);
    	
    	    //We will verify Dropdown has expected values as listed in a array
    	    ArrayList exp_options = new ArrayList(new String [] {"BMW", "Mercedes", "Audi","Honda"});
    	    var act_options = new ArrayList();
    	
    	    //Retrieve the option values from Dropdown using getOptions() method
    	    foreach(IWebElement option in make.Options)
    		     act_options.Add(option.Text);
    	
    	    //Verify expected options array and actual options array match
    	    Assert.AreEqual(exp_options.ToArray(),act_options.ToArray());
    	    	
    	    //With Select class we can select an option in Dropdown using Visible Text
    	    make.SelectByText("Honda");
            Assert.AreEqual("Honda", make.SelectedOption.Text);
    	
    	    //or we can select an option in Dropdown using value attribute
    	    make.SelectByValue("audi");
            Assert.AreEqual("Audi", make.SelectedOption.Text);
    	
    	    //or we can select an option in Dropdown using index
    	    make.SelectByIndex(0);
            Assert.AreEqual("BMW", make.SelectedOption.Text);
        }
    
 	   [TestCase]
       public void TestMultipleSelectList()
       {
 		    //Get the List as a Select using it's name attribute
 		    SelectElement color = new SelectElement(driver.FindElement(By.Name("color")));
 		
 		    //Verify List support multiple selection
    	    Assert.IsTrue(color.IsMultiple);
    	
    	    //Verify List has five options for selection
    	    Assert.AreEqual(5, color.Options.Count);
    	
    	    //Select multiple options in the list using visible text
    	    color.SelectByText("Black");
    	    color.SelectByText("Red");
    	    color.SelectByText("Silver");
    	
    	    //Verify there 3 options selected in the list
    	    Assert.AreEqual(3,color.AllSelectedOptions.Count);
    	
    	    //We will verify list has multiple options selected as listed in a array
    	    var exp_sel_options = new ArrayList(new String[]{"Black", "Red", "Silver"});
    	    var act_sel_options = new ArrayList();
    	    	
    	    foreach(IWebElement option in color.AllSelectedOptions)
    		    act_sel_options.Add(option.Text);
   	    	
    	    //Verify expected array for selected options match with actual options selected
            Assert.AreEqual(exp_sel_options.ToArray(), act_sel_options.ToArray());
   		
    	    //Deselect an option using visible text
    	    color.DeselectByText("Silver");
    	    //Verify selected options count
            Assert.AreEqual(2, color.AllSelectedOptions.Count);
    	
    	    //Deselect an option using value attribute of the option
    	    color.DeselectByValue("rd");
    	    //Verify selected options count
            Assert.AreEqual(1, color.AllSelectedOptions.Count);
    	
    	    //Deselect an option using index of the option
    	    color.DeselectByIndex(0);
    	    //Verify selected options count
            Assert.AreEqual(0, color.AllSelectedOptions.Count);
        }

        [TestFixtureTearDown]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
