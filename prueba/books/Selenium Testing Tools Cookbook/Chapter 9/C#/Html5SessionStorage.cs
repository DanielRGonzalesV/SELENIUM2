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
    public class Html5SessionStorage
    {
        IWebDriver driver;

        [SetUp]
        public void TestSetup()
        {
            // Create a instance of the Chrome driver using IWebDriver Interface
            driver = new ChromeDriver();
        }

        [TestCase]
        public void TestHtml5SessionStorage()
        {
            try
            {
                driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/html5storage.html");

                string clickcount;
                IWebElement clickButton = driver.FindElement(By.Id("click"));
                IWebElement clicksField = driver.FindElement(By.Id("clicks"));
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;

                //Get current value of sessionStorage.clickcount, should be null
                clickcount = (String)js.ExecuteScript("return sessionStorage.clickcount;");
                Assert.AreEqual(null, clickcount);
                Assert.AreEqual("0", clicksField.GetAttribute("value"));

                //Click the Button, this will increase the sessionStorage.clickcount value by 1
                clickButton.Click();

                //Get current value of sessionStorage.clickcount, should be 1
                clickcount = (String)js.ExecuteScript("return sessionStorage.clickcount;");
                Assert.AreEqual("1", clickcount);
                Assert.AreEqual("1", clicksField.GetAttribute("value"));
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
