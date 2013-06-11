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
using System.Threading;
using System.Drawing.Imaging;

namespace HTML5Tests
{
    [TestFixture]
    public class Html5VideoPlayer
    {
        IWebDriver driver;

        [SetUp]
        public void TestSetup()
        {
            // Create a instance of the Chrome driver using IWebDriver Interface
            driver = new ChromeDriver();
            
        }

        [TestCase]
        public void TestHtml5VideoPlayer()
        {
            try
            {
                driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/html5video.html");

                //Get the HTML5 Video Element
                IWebElement videoPlayer = driver.FindElement(By.Id("vplayer"));

                //We will need a JavaScript Executor for interacting with Video Element's 
                //methods and properties for automation
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;

                //Get the Source of Video that will be played in Video Player
                string source = (string)js.ExecuteScript("return arguments[0].currentSrc;", videoPlayer);
                //Get the Duration of Video
                long duration = (long)js.ExecuteScript("return arguments[0].duration", videoPlayer);

                //Verify Correct Video is loaded and duration
                Assert.AreEqual("http://html5demos.com/assets/dizzy.mp4", source);
                Assert.AreEqual(25, duration);

                //Play the Video
                js.ExecuteScript("return arguments[0].play()", videoPlayer);

                Thread.Sleep(5000);

                //Pause the video
                js.ExecuteScript("arguments[0].pause()", videoPlayer);
                
                //Take a screen-shot for later verification
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshot = ss.AsBase64EncodedString;
                byte[] screenshotAsByteArray = ss.AsByteArray;
                ss.SaveAsFile(@"c:\tmp\pause_play.png", ImageFormat.Png);
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
