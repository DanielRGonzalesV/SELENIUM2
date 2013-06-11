using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace ControllingTestFlowExamples
{
    [TestFixture]
    class AlertTests
    {
        static IWebDriver driver;
	
	    [TestFixtureSetUp]
	    public static void SetUp()
	    {
		    driver = new ChromeDriver(@"C:\ChromeDriver");
		    driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/Alerts.html");
	    }
	
	    [TestCase]
	    public void TestSimpleAlert()
	    {
		    //Clicking button will show a simple Alert with OK Button
		    IWebElement button = driver.FindElement(By.Id("simple"));
		    button.Click();
		
		    try 
            {
			    //Get the Alert
			    IAlert alert = driver.SwitchTo().Alert();
			
			    //Get the Text displayed on Alert using getText() method of Alert class
			    String textOnAlert = alert.Text;
			
			    //Click OK button, by calling accept() method of Alert Class
			    alert.Accept();
			
			    //Verify Alert displayed correct message to user
			    Assert.AreEqual("Hello! I am an alert box!",textOnAlert);
		    } 
            catch (NoAlertPresentException e) 
            {
			    Assert.Fail("Alert not found!!");
		    }
	    }
	
	    [TestCase]
	    public void TestConfirmAccept()
	    {
		    //Clicking button will show a Confirmation Alert with OK and Cancel Button
		    IWebElement button = driver.FindElement(By.Id("confirm"));
		    button.Click();
		
		    try {
		
			    //Get the Alert
			    IAlert alert = driver.SwitchTo().Alert();
			
			    //Click OK button, by calling accept() method of Alert Class
			    alert.Accept();
			
			    //Verify Page displays correct message on Accept
			    IWebElement message = driver.FindElement(By.Id("demo"));
			    Assert.AreEqual("You Accepted Alert!", message.Text);
			
		    } catch (NoAlertPresentException e) {
			     Assert.Fail("Alert not found!!");
		    }
	    }
	
	    [TestCase]
	    public void TestConfirmDismiss()
	    {
		    //Clicking button will show a Confirmation Alert with OK and Cancel Button
		    IWebElement button = driver.FindElement(By.Id("confirm"));
		    button.Click();
		
		    try {
		
			    //Get the Alert
			    IAlert alert = driver.SwitchTo().Alert();
			
			    //Click OK button, by calling accept() method of Alert Class
			    alert.Dismiss();
			
			    //Verify Page displays correct message on Accept
			    IWebElement message = driver.FindElement(By.Id("demo"));
			    Assert.AreEqual("You Dismissed Alert!", message.Text);
			
		    } catch (NoAlertPresentException e) {
			     Assert.Fail("Alert not found!!");
		    }
	    }
	
	    [TestCase]
	    public void TestPrompt()
	    {
		    //Clicking button will show a Prompt Alert asking user to enter
		    //value/text with OK and Cancel Button
		    IWebElement button = driver.FindElement(By.Id("prompt"));
		    button.Click();
		
		    try {
			
			    //Get the Alert
			    IAlert alert = driver.SwitchTo().Alert();

			    //Enter some value on Prompt by calling sendKeys() method of Alert Class
			    alert.SendKeys("Foo");
			
			    //Click OK button, by calling accept() method of Alert Class
			    alert.Accept();
			
			    //Verify Page displays message with value entered in Prompt
			    IWebElement message = driver.FindElement(By.Id("prompt_demo"));
			    Assert.AreEqual("Hello Foo! How are you today?", message.Text);
			
		    } catch (NoAlertPresentException e) {
			    Assert.Fail("Alert not found!!");
		    }
	    }
	
	    [TestFixtureTearDown]
	    public static void TearDown()
	    {
		    driver.Close();
	    }
    }
}
