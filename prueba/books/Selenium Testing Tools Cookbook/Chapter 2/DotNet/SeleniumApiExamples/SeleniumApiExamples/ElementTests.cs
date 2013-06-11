using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using NUnit.Framework;

namespace SeleniumApiExamples
{
    [TestFixture]
    public class ElementTests
    {
        private IWebDriver driver;

        [TestFixtureSetUp]
        public void Setup() 
        {
            driver = new ChromeDriver(@"C:\ChromeDriver\");
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/DoubleClickDemo.html");
        }

        [TestCase]
        public void TestElementText()
        {
            //Get the message Element
            IWebElement message = driver.FindElement(By.Id("message"));

           //Verify message element's text displays "Click on me and my color will change"
            Assert.AreEqual("Click on me and my color will change", message.Text);

            //Get the area Element
            IWebElement area = driver.FindElement(By.Id("area"));

            //Verify area element's text displays "Div's Text\nSpan's Text"
            Assert.AreEqual("Div's Text\r\nSpan's Text", area.Text);
        }

        [TestCase]
        public void TestElementAttribute()
        {
            IWebElement message = driver.FindElement(By.Id("message"));
            Assert.AreEqual("justify", message.GetAttribute("align"));
        }

        [TestCase]
	    public void TestElementStyle()
	    {
		    IWebElement message = driver.FindElement(By.Id("message"));
		    String width = message.GetCssValue("width");
		    Assert.AreEqual("150px",width);
	    }

        [TestFixtureTearDown]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
