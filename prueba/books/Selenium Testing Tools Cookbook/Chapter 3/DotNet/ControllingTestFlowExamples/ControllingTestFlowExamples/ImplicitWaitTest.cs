using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace ControllingTestFlowExamples
{
    [TestFixture]
    public class ImplicitWaitTest
    {
        [TestCase]
 	    public void TestWithImplicitWait()
 	    {
 		    //Go to the Demo AjAX Application
            IWebDriver driver = new ChromeDriver(@"C:\ChromeDriver");
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/AjaxDemo.html");
        
            //Set the Implicit Wait time Out to 10 Seconds
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
 		
 		    try {

 			    //Get link for Page 4 and click on it
 			    IWebElement page4button = driver.FindElement(By.LinkText("Page 4"));
 			    page4button.Click();
 		
 			    //Get an element with id page4 and verify it's text
 			    IWebElement message = driver.FindElement(By.Id("page4"));
 			    Assert.IsTrue(message.Text.Contains("Nunc nibh tortor"));
 		    } 
            catch (NoSuchElementException e)
            {
 			    Assert.Fail("Element not found!!");
 		    } 
            finally 
            {
                driver.Close();
 		    }
 	    }
    }
}
