using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace LocatorExamples
{
    [TestFixture]
    public class TableTests
    {
        private IWebDriver driver;
	
	    [TestFixtureSetUp]
	    public void SetUp()
        {
		    driver = new ChromeDriver(@"C:\ChromeDriver\");
		    driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/Locators.html");
	    }
	
	    [TestCase]
	    public void TestWebTable() 
        { 
        
		    IWebElement simpleTable = driver.FindElement(By.Id("items"));
		
		    //Get all rows
		    var rows = simpleTable.FindElements(By.TagName("tr"));
		    Assert.AreEqual(3, rows.Count);
		
		    //Print data from each row
		    foreach (IWebElement row in rows) {
			    var cols = row.FindElements(By.TagName("td"));
                Assert.AreEqual(2, cols.Count);
			    foreach (IWebElement col in cols) 
                    System.Console.Write(col.Text + "\t");
			    System.Console.WriteLine();
		    }
        }
	
	    [TestFixtureTearDown]
	    public void TearDown()
        {
		    driver.Close();
	    }
    }
}
