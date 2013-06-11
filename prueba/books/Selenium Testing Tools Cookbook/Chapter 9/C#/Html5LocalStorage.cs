using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Collections;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace HTML5Tests
{
    [TestFixture]
    public class Html5LocalStorage
    {
        IWebDriver driver;

        [SetUp]
        public void TestSetup()
        {
            // Create a instance of the Chrome driver using IWebDriver Interface
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/html5storage.html");
        }

        [TestCase]
        public void TestHtml5LocalStorage()
        {
            try
            {
                string lastName;
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                
                //Get the current value of localStorage.lastname, this should be Smith
		        lastName = (String) js.ExecuteScript("return localStorage.lastname;");
                Assert.AreEqual("Smith", lastName);
            }
            catch (Exception e)
            {
                Assert.Fail("Test Failed due to exception '" + e.Message + "'");
            }
        }

        [TearDown]
        public void TestCleanUp()
        {
            // Close the browser   
            driver.Quit();
        }
    }
}
