using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace ControllingTestFlowExamples
{
    [TestFixture]
    class ElementStateTests
    {
        static IWebDriver driver;
    
        [TestFixtureSetUp]
        public static void SetUp() {
            driver = new ChromeDriver(@"C:\ChromeDriver");
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/Config.html");
        }
    
 	    [TestCase]
        public void TestElementIsEnabled()
        {
 		    //Get the Checkbox as WebElement using it's name attribute
 		    IWebElement ledheadlamp = driver.FindElement(By.XPath("//input[@name='ledheadlamp']"));
 		
 		    //Check if its enabled before selecting it
 		    if (ledheadlamp.Enabled)
 		    {
 			    //Check if its already selected? otherwise select the Checkbox
 			    if (!ledheadlamp.Selected)
 				    ledheadlamp.Click();
 		    }
 		    else
 		    {
 			    Assert.Fail("LED Lamp Checkbox is disabled!!");
 		    }
        }
 	
        [TestCase]
 	    public void TestIsElementPresent()
 	    {
 		    //Check if element with locator criteria exists on Page
 		    if (isElementPresent(By.Name("airbags"))) {
 			    //Get the checkbox and select it
 			    IWebElement airbag = driver.FindElement(By.Name("airbags"));
 			    if (!airbag.Selected)
 				    airbag.Click();
 		    }
 		    else {
 			    Assert.Fail("Airbag Checkbox doesn't exists!!");
 		    }
 	    }
 	
 	    [TestFixtureTearDown]
        public static void tearDown() {
            driver.Close();
        }
 	
 	    private Boolean isElementPresent(By by) {
		    try {
			    driver.FindElement(by);
			    return true;
		    } catch (NoSuchElementException e) {
			    return false;
		    }
 	    }
    }
}
