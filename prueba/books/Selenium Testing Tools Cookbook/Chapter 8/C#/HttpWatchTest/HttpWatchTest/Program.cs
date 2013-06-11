using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HttpWatch;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace HttpWatchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of HTTPWatch Controller
            Controller control = new Controller();
            
            //Start IE Driver. IE Driver Server is located in C:\\    
            IWebDriver driver = new InternetExplorerDriver(@"C:\");

            // Set a unique initial page title so that HttpWatch can attach to it
            string uniqueTitle = Guid.NewGuid().ToString();
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("document.title = '" + uniqueTitle + "';");

            // Attach HttpWatch to the instance of Internet Explorer created through WebDriver
            Plugin plugin = control.AttachByTitle(uniqueTitle);
            
            //Open the HTTPWatch Window
            plugin.OpenWindow(false);
            
            //Navigate to the BMI Application Page
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/bmicalculator.html");
            
            //Perform some steps
            driver.FindElement(By.Id("heightCMS")).SendKeys("181");
            driver.FindElement(By.Id("weightKg")).SendKeys("80");
            driver.FindElement(By.Id("Calculate")).Click();
       
            //Export the HAR Log generated to a file
            plugin.Log.Save(@"C:\bmicalc.hwl");

            //Close the Internet Explorer
            driver.Close();
        }
    }
}
