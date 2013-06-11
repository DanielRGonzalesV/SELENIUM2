using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace ControllingTestFlowExamples
{
    [TestFixture]
    class FrameTests
    {
        static IWebDriver driver;
	
	    [TestFixtureSetUp]
	    public static void SetUp()
	    {
		    driver = new ChromeDriver(@"C:\ChromeDriver");
		    driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/Frames.html");
	    }
	
	    [TestCase]
	    public void TestFrameWithIdOrName()
	    {
		    //Activate the frame on left side using it's id attribute
		    driver.SwitchTo().Frame("left");
		
		    //Get an element from the frame on left side and verify it's contents
		    IWebElement leftmsg = driver.FindElement(By.TagName("p"));
		    Assert.AreEqual("This is Left Frame", leftmsg.Text);
		
		    //Activate the Page, this will move context from frame back to the Page
		    driver.SwitchTo().DefaultContent();
		
		    //Activate the frame on right side using it's name attribute
		    driver.SwitchTo().Frame("right");
		
		    //Get an element from the frame on right side and verify it's contents
		    IWebElement rightmsg = driver.FindElement(By.TagName("p"));
		    Assert.AreEqual("This is Right Frame", rightmsg.Text);
		
		    //Activate the Page, this will move context from frame back to the Page	
		    driver.SwitchTo().DefaultContent();
		
	    }
	
	    [TestCase]
	    public void TestFrameByIndex()
	    {
		    //Activate the frame in middle using it's index. Index starts at 0
		    driver.SwitchTo().Frame(1);
		
		    //Get an element from the frame in the middle and verify it's contents
		    IWebElement leftmsg = driver.FindElement(By.TagName("p"));
		    Assert.AreEqual("This Frame doesn't have id or name", leftmsg.Text);
		
		    //Activate the Page, this will move context from frame back to the Page
		    driver.SwitchTo().DefaultContent();
	    }
	
	    [TestCase]
	    public void TestFrameByContents()
	    {
		    //Get all frames on the Page, created with <frame> tag
		    var frames = driver.FindElements(By.TagName("frame"));

		    //In this example frame in the middle is activated by checking the contents
		    //Activate frame and check if it has the desired content. If found perform the operations
		    //if not, then switch back to the Page and continue checking next frame
		    foreach(IWebElement frame in frames) {
			    //SwitchTo().frame() also accepts frame elements apart from id, name or index 
			    driver.SwitchTo().Frame(frame);
			    if(driver.PageSource.Contains("This Frame doesn't have id or name")) {
				    Assert.Pass("Middle Frame Found");
				    break;
			    }
			    else
				    driver.SwitchTo().DefaultContent();
		    }

		    //Activate the Page, this will move context from frame back to the Page
		    driver.SwitchTo().DefaultContent();
	    }
	
	    [TestCase]
	    public void TestIFrame()
	    {
		    //The frame on the right side has a nested iframe containing 'Twitter Follow' Button
		    //Activate the frame on right side using it's name attribute
		    driver.SwitchTo().Frame("right");
		
		    //Get the iframe element
		    IWebElement twitterframe = driver.FindElement(By.TagName("iframe"));
		    //Activate the iframe 
		    driver.SwitchTo().Frame(twitterframe);
		    //Get and Click the follow button from iframe
		    //a Popup Window will appear after click
		    IWebElement button = driver.FindElement(By.Id("follow-button"));
		    button.Click();
		
		    //Store the handle of current driver window
		    String currentWindow = driver.CurrentWindowHandle; 
		
		    //The Twitter Popup does not have name or title. 
		    //Script will get handles of all open windows and 
		    //desired window will be activated by checking it's Title
		    var allWindows = driver.WindowHandles;
		    if(allWindows != null) {
			    foreach (String windowId in allWindows)
			    {
				    driver.SwitchTo().Window(windowId);
				    if (driver.Title.Equals("Unmesh Gundecha (@upgundecha) on Twitter")) {
                        Assert.Pass("Twitter Login Popup Window Found");
					    driver.Close();
					    break;
				    }
					
			    }
		    }
		    //Switch back to original driver window
		    driver.SwitchTo().Window(currentWindow);
		    //switch back to Page from the frame
		    driver.SwitchTo().DefaultContent();
	    }
	
	    [TestFixtureTearDown]
	    public static void TearDown()
	    {
		    //Close the Parent Popup Window
		    driver.Close();
	    }
    }
}
