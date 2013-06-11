using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace SeleniumApiExamples
{
    [TestFixture]
    class ScreenShotTest
    {
        [TestCase]
	    public void TestJavaScript()
	    {
            IWebDriver driver = new ChromeDriver(@"C:\ChromeDriver\");
            driver.Navigate().GoToUrl("http://www.google.com");

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(@"c:\temp\main_page.png", System.Drawing.Imaging.ImageFormat.Png);
            
		    driver.Close();
	    }
    }
}
