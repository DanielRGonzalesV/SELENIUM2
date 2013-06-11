using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace ControllingTestFlowExamples
{
   [TestFixture]   
    class ExplicitWaitTests
    {
        [TestCase]
 	    public void TestExplicitWait()
 	    {
 		    IWebDriver driver = new ChromeDriver(@"C:\ChromeDriver");
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/AjaxDemo.html");
 		
            try 
            {
 			    IWebElement page4button = driver.FindElement(By.LinkText("Page 4"));
 			    page4button.Click();
 		        
               WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
               IWebElement message = wait.Until<IWebElement>((d) =>
               {
                    return d.FindElement(By.Id("page4"));
               });

 			    Assert.IsTrue(message.Text.Contains("Nunc nibh tortor"));
 			
 		    } 
            catch (NoSuchElementException e) 
            {
 			    Assert.Fail("Element not found!!");
 		    } finally {
 			    driver.Close();
 		    }
 	    }
	
	   [TestCase]
	    public void TestExplicitWaitByTitle()
	    {
            IWebDriver driver = new ChromeDriver(@"C:\ChromeDriver");
            driver.Navigate().GoToUrl("http://www.google.com");
		    IWebElement query = driver.FindElement(By.Name("q"));
		    query.SendKeys("selenium");
		    query.Submit();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Title.ToLower().StartsWith("selenium"); });
            Assert.IsTrue(driver.Title.ToLower().StartsWith("selenium"));
            driver.Close();
	    }
    }
}
