using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Collections;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace BMICalculator
{
    [TestFixture]
    public class BmiCalcTest
    {
        IWebDriver driver;
        ObjectMap map;

        [SetUp]
        public void TestSetup()
        {
            // Create a instance of the Firefox driver using IWebDriver Interface
            driver = new FirefoxDriver();
            map = new ObjectMap("c:\\BmiCalcMap.xml");
           
        }

        [TestCase]
   	    public void TestBmiCalc()
	    {
            try
            {
                driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/bmicalculator.html");

                IWebElement heightElement = driver.FindElement(map.GetLocator("HeightField"));
                heightElement.SendKeys("181");

                IWebElement weightElement = driver.FindElement(map.GetLocator("WeightField"));
                weightElement.SendKeys("80");

                IWebElement calculateButton = driver.FindElement(map.GetLocator("CalculateButton"));
                calculateButton.Click();

                IWebElement bmiElement = driver.FindElement(map.GetLocator("BmiLabel"));
                Assert.AreEqual("24.0", bmiElement.GetAttribute("value"));

                IWebElement bmiCatElement = driver.FindElement(map.GetLocator("BmiCategoryLabel"));
                Assert.AreEqual("Normal", bmiCatElement.GetAttribute("value"));
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
