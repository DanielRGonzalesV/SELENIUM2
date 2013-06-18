package enricjaen.s2.pageobject;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.*;

public class Browser {
    
     private WebDriver driver;
    
     public Browser() {
    	 init();
	}
     
     private void init() {
    		System.setProperty("webdriver.chrome.driver","C:\\descargas\\chromedriver_antiguo.exe");
    		driver = new ChromeDriver();
    		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);		
	}

	public WebDriver driver() {
         return driver;
     }

     public void open(String url) {
         driver.get(url);      
     }

     public void close() {
        driver.close();
     }
     
     protected boolean isTextPresent(String text) {
 		return driver.getPageSource().contains(text);
 	}
}