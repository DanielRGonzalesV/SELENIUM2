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
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;

namespace HTML5Tests
{
    [TestFixture]
    public class Html5CanvasDrawing
    {
        IWebDriver driver;

        [SetUp]
        public void TestSetup()
        {
            // Create a instance of the Chrome driver using IWebDriver Interface
            driver = new ChromeDriver();
        }

        [TestCase]
        public void TestHtml5CanvasDrawing()
        {
            try
            {
                driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/html5canvasdraw.html");

                //Get the HTML5 Canvas Element
                IWebElement canvas = driver.FindElement(By.Id("imageTemp"));
                //Select the Pencil Tool
                SelectElement drawtool = new SelectElement(driver.FindElement(By.Id("dtool")));
                drawtool.SelectByText("Pencil");

                //Create a Action Chain for Draw a shape on Canvas
                Actions builder = new Actions(driver);
                builder.ClickAndHold(canvas).MoveByOffset(10, 50).
                                             MoveByOffset(50, 10).
                                             MoveByOffset(-10, -50).
                                             MoveByOffset(-50, -10).Release().Perform();

                //Get a screenshot of Canvas element after Drawing and compare it to the base version
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshot = ss.AsBase64EncodedString;
                byte[] screenshotAsByteArray = ss.AsByteArray;
                ss.SaveAsFile(@"c:\tmp\post.png", ImageFormat.Png);
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
