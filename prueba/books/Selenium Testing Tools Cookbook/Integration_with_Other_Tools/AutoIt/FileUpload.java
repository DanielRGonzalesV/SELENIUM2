import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.By;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.WebDriverWait;

import org.junit.*;
import static org.junit.Assert.*;

public class FileUpload {
	protected WebDriver driver;
	
	@Before
	public void setUp() {
		driver = new ChromeDriver();
		driver.get("http://blueimp.github.com/jQuery-File-Upload/");
	}
	
	@Test
	public void testFileUpload() throws InterruptedException {
		try {

			//Click on Add Files button
			driver.findElement(By.className("fileinput-button")).click();
			
			//Call the OpenDialogHandler, specify the path of the file to be uploaded
			Runtime.getRuntime().exec(new String[] {"C:\\Utils\\OpenDialogHandler.exe", "\"C:\\Users\\Admin\\Desktop\\Picture1.png\""});
			
			//Wait until file is uploaded
			boolean result = (new WebDriverWait(driver, 30)).until(new ExpectedCondition<Boolean>() {
 				public Boolean apply(WebDriver d) {
 					return d.findElement(By.xpath("//table[@role='presentation']")).findElements(By.tagName("tr")).size() > 0;
 			}});
			
			assertTrue(result);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	@After
	public void tearDown() {
		driver.close();
	}
}
