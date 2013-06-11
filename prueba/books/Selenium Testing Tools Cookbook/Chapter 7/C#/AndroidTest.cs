using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Collections;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Android;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace BMICalculator
{
    [TestFixture]
    public class AndroidTest
    {
        IWebDriver driver;
        
        [SetUp]
        public void TestSetup()
        {
            // Create a instance of the AndroidDriver driver using IWebDriver Interface
            driver = new AndroidDriver();
        }

        [TestCase]
        public void TestBmiCalc()
        {
            try
            {
                driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/mobilebmicalculator.html");

                IWebElement heightElement = driver.FindElement(By.Name("heightCMS"));
                heightElement.SendKeys("181");

                IWebElement weightElement = driver.FindElement(By.Name("weightKg"));
                weightElement.SendKeys("80");

                IWebElement calculateButton = driver.FindElement(By.Id("Calculate"));
                calculateButton.Click();

                IWebElement bmiElement = driver.FindElement(By.Name("bmi"));
                Assert.AreEqual("24.4", bmiElement.GetAttribute("value"));

                IWebElement bmiCatElement = driver.FindElement(By.Name("bmi_category"));
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
