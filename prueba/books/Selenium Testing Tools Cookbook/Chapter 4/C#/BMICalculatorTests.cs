using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Data;

namespace BMICalculator
{
    [TestClass]
    public class BMICalculatorTests
    {
        IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {

            // Create a instance of the Firefox driver using IWebDriver Interface
            driver = new FirefoxDriver();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        [DeploymentItem("Data.xls")]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.xls;Persist Security Info=False;Extended Properties='Excel 12.0;HDR=Yes'", "Data$", DataAccessMethod.Sequential)]
        public void TestBMICalculator()
        {
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/bmicalculator.html");
            
            IWebElement height = driver.FindElement(By.Name("heightCMS"));
            height.SendKeys(TestContext.DataRow["Height"].ToString());

            IWebElement weight = driver.FindElement(By.Name("weightKg"));
            weight.SendKeys(TestContext.DataRow["Weight"].ToString());

            IWebElement calculateButton = driver.FindElement(By.Id("Calculate"));
            calculateButton.Click();

            IWebElement bmi = driver.FindElement(By.Name("bmi"));
            Assert.AreEqual(TestContext.DataRow["Bmi"].ToString(), bmi.GetAttribute("value"));

            IWebElement bmi_category = driver.FindElement(By.Name("bmi_category"));
            Assert.AreEqual(TestContext.DataRow["Category"].ToString(), bmi_category.GetAttribute("value"));
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            // Close the browser   
            driver.Quit();
        }

    }
}