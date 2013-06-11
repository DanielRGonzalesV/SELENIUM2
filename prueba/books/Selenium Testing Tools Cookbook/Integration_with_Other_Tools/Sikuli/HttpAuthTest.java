import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.By;

import org.sikuli.script.FindFailed;
import org.sikuli.script.Screen;

import org.junit.*;
import static org.junit.Assert.fail;

public class HttpAuthTest {
	private WebDriver driver;
	private StringBuffer verificationErrors = new StringBuffer();
	
	@Before
	public void setUp() {
		driver = new ChromeDriver();
		driver.get("http://www.httpwatch.com/httpgallery/authentication/");
	}
	
	@Test
	public void testHttpAuth() throws InterruptedException {
		driver.findElement(By.id("displayImage")).click();
		
		//Get the system screen.
		Screen s = new Screen();
		
		try {

			//Sikuli type command will use the image file of the control
			//and text that needs to be entered in to the control
			s.type("C:\\UserName.png", "httpwatch");
			s.type("C:\\Password.png","dhjhfj");
			
			//Sikuli click command will use the image file of the control
			s.click("C:\\Login.png");
			
		} catch (FindFailed e) {
			//Sikuli raises FindFailed exception it fails
			//to locate the image on to the screen 
			e.printStackTrace();
		}
	}
	
	@After
	public void tearDown() {
		driver.close();
		String verificationErrorString = verificationErrors.toString();
		if (!"".equals(verificationErrorString)) {
			fail(verificationErrorString);
		}
	}
}
