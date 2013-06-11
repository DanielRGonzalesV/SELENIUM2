using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using Microsoft.Expression.Encoder.ScreenCapture;

namespace SeVideoRecording
{
    [TestFixture]
    public class GoogleSearch
    {
        IWebDriver driver;
        ScreenCaptureJob scj;

        [SetUp]
        public void TestSetup()
        {
            // Create a instance of ScreenCaptureJob from Expression Encoder
            scj = new ScreenCaptureJob();

            // Specify the path & name of the file to which Encoder will store the recording. 
            // Name of Test is passed to create individual recordings of each test
            scj.OutputScreenCaptureFileName = @"C:\Results\TestGooleSearch.wmv";

            // Start the Screen Capture Job
            scj.Start();

            driver = new FirefoxDriver();
        }

        [TestCase]
        public void TestGoogleSearch()
        {
            driver.Navigate().GoToUrl("http://www.google.com/");

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Cheese");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Boolean titleMatched = wait.Until<Boolean>((d) =>
            {
                return d.Title.ToLower().StartsWith("cheese");
            });

            Assert.AreEqual("cheese - Google Search", driver.Title);
        }

        [TearDown]
        public void TestCleanUp()
        {
            //Close the Browser
            driver.Close();

            //Stop the Screen Capture Job
            scj.Stop();
        }
    }
}
