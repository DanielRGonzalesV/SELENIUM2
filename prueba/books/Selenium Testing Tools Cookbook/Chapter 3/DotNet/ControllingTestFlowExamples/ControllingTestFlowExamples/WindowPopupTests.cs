using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace ControllingTestFlowExamples
{
    [TestFixture]
    class WindowPopupTests
    {
        static IWebDriver driver;
	
        [TestFixtureSetUp]
        public static void SetUp() {
            driver = new ChromeDriver(@"C:\ChromeDriver");
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/Config.html");
        }
	
	    [TestCase]
	    public void TestWindowPopup() {
		    //Save the WindowHandle of Parent Browser Window
		    var parentWindowId = driver.CurrentWindowHandle;
		
		    //Clicking Help Button will open Help Page in a new Popup Browser Window
		    IWebElement helpButton = driver.FindElement(By.Id("helpbutton"));
		    helpButton.Click();
		
		    try {
			    //Switch to the Help Popup Browser Window
			    driver.SwitchTo().Window("HelpWindow");
		    } catch (NoSuchWindowException e) {
			   Assert.Fail("Help Window not found!!");
		    }
		
		    //Verify the driver context is in Help Popup Browser Window
		    Assert.IsTrue(driver.Title.Equals("Help"));
		
		    //Close the Help Popup Window
		    driver.Close();
		
		    //Move back to the Parent Browser Window
		    driver.SwitchTo().Window(parentWindowId);
		    //Verify the driver context is in Parent Browser Window
		    Assert.IsTrue(driver.Title.Equals("Build my Car - Configuration"));
	    }
	
	    [TestCase]
	    public void TestWindowPopupUsingTitle() {
		    //Save the WindowHandle of Parent Browser Window
		    String parentWindowId = driver.CurrentWindowHandle;
		
		    //Clicking Visit Us Button will open Visit Us Page in a new Popup Browser Window
		    IWebElement visitButton = driver.FindElement(By.Id("visitbutton"));
		    visitButton.Click();
		
		    //Get Handles of all the open Popup Windows
		    //Iterate through the set and check if tile of each window matches with expected Window Title
		    var allWindows = driver.WindowHandles;
		    if(allWindows != null ) {
			    foreach (String windowId in allWindows)
                {
				    try
                    {
					    if(driver.SwitchTo().Window(windowId).Title.Equals("Visit Us")) 
                        {
						    //Close the Visit Us Popup Window
						    driver.Close();
						    break;
					    }
				    }
				    catch(NoSuchWindowException e) {
					    Assert.Fail("Expected Window not found!!");
				    }
			    }
		    }
		
		    //Move back to the Parent Browser Window
		    driver.SwitchTo().Window(parentWindowId);
		    //Verify the driver context is in Parent Browser Window
		    Assert.IsTrue(driver.Title.Equals("Build my Car - Configuration"));
	    }
	
	    [TestCase]
	    public void TestWindowPopupUsingContents()
	    {
		    //Save the WindowHandle of Parent Browser Window
		    String currentWindowId = driver.CurrentWindowHandle;
		
		    //Clicking Chat Button will open Chat Page in a new Popup Browser Window
		    IWebElement chatButton = driver.FindElement(By.Id("chatbutton"));
		    chatButton.Click();
		
		    //There is no name or title provided for Chat Page Popup
		    //We will iterate through all the open Windows and check the contents to find
		    //out if it's Chat Window
		    var allWindows = driver.WindowHandles;
		    if(allWindows != null)
            {
			    foreach (String windowId in allWindows)
                {
				    driver.SwitchTo().Window(windowId);
				    if(driver.PageSource.Contains("Build my Car - Configuration - Online Chat")) 
                    {
					    try {
						        //Find the Close Button on Chat Popup Window and close the Popup
						        //by clicking Close Button instead of closing it directly
						        IWebElement closeButton = driver.FindElement(By.Id("closebutton"));
						        closeButton.Click();
						        break;
					        } 
                            catch(NoSuchWindowException e) 
                            {
						        Assert.Fail("Expected Window not found!!");
					        }
				    }
			    }
		    }
		    //Move back to the Parent Browser Window
		    driver.SwitchTo().Window(currentWindowId);
		    //Verify the driver context is in Parent Browser Window
		    Assert.IsTrue(driver.Title.Equals("Build my Car - Configuration"));
	    }
	
	    [TestFixtureTearDown]
	    public static void TearDown()
	    {
		    //Close the Parent Popup Window
		    driver.Close();
	    }
    }
}
