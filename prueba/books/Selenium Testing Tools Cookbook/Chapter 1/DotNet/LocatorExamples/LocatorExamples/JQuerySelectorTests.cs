using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace LocatorExamples
{
    [TestFixture]
    public class JQuerySelectorTests
    {
        private IWebDriver driver;
	
	    [TestFixtureSetUp]
	    public void SetUp()
        {
		    driver = new ChromeDriver(@"C:\ChromeDriver\");
		    driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/Locators.html");
	    }
	
	    [TestCase]
        public void TestDefaultSelectedCheckbox() 
        { 
		    //Expected list of selected Checkbox
            var exp_checked = new ArrayList(new String[] { "user128_admin", "user220_browser" });
            
		    //Create an instance of JavaScript Executor from driver
		    IJavaScriptExecutor js = (IJavaScriptExecutor) driver;

		    //Locate all the Checkbox which are checked by calling jQuery find() method. 
		    //find() method returns elements in array
		    var elements = (ReadOnlyCollection<IWebElement>) js.ExecuteScript("return jQuery.find(':checked')");

		    //Verify two Checkbox are selected 
		    Assert.AreEqual(2,elements.Count);

		    //Verify correct Checkbox are selected
		    foreach (IWebElement element in elements)
                Assert.IsTrue(exp_checked.Contains(element.GetAttribute("id")));
        }
	    
        [TestFixtureTearDown]
	    public void TearDown()
        {
		    driver.Close();
	    }
    }
}
