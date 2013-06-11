package enricjaen.s2.recordingvideo;

import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.By;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.monte.media.math.Rational;
import org.monte.media.Format;
import org.monte.screenrecorder.ScreenRecorder;
import static org.monte.media.AudioFormatKeys.*;
import static org.monte.media.VideoFormatKeys.*;
import org.junit.*;
import static org.junit.Assert.*;
import java.awt.*;

public class GoogleSearchTest {

	private WebDriver driver;
	private StringBuffer verificationErrors = new StringBuffer();
	private ScreenRecorder screenRecorder;

	@Before
	public void setUp() throws Exception {
		GraphicsConfiguration gc =
				GraphicsEnvironment.
				getLocalGraphicsEnvironment().
				getDefaultScreenDevice().
				getDefaultConfiguration();


		screenRecorder = new ScreenRecorder(gc,
				new Format(MediaTypeKey, MediaType.FILE, 
						   MimeTypeKey, MIME_AVI),
				
				new Format(MediaTypeKey, MediaType.VIDEO, 
						   EncodingKey, ENCODING_AVI_TECHSMITH_SCREEN_CAPTURE,
						   CompressorNameKey,ENCODING_AVI_TECHSMITH_SCREEN_CAPTURE, 
						   DepthKey,(int)24, 
						   FrameRateKey, Rational.valueOf(15),
						   QualityKey, 1.0f, 
						   KeyFrameIntervalKey, (int)(15*60)),
						   
				new Format(MediaTypeKey, MediaType.VIDEO, 
						   EncodingKey,"black",
						   FrameRateKey, Rational.valueOf(30)),
						   
				null);



		driver = new FirefoxDriver();
		//screenRecorder.start();

  }
	
	@Test
	public void googleSearch() throws Exception {
		driver.get("http://www.google.com");
		WebElement elem = driver.findElement(By.name("q"));
		elem.sendKeys("cheese!");
		elem.submit();
		
		try {
			(new WebDriverWait(driver, 10)).until(new ExpectedCondition<Boolean>() {
				public Boolean apply(WebDriver d) {
					return d.getTitle().toLowerCase().startsWith("cheese!");
				}
			});
			
			assertEquals("cheese! - Google Search", driver.getTitle());
		} catch (Exception e) {
			verificationErrors.append(e.toString());
		}
	}
	
	@After 
	public void tearDown() throws Exception {
		driver.quit();
		//screenRecorder.stop();
		String verifStr = verificationErrors.toString();
		if(!"".equals(verifStr)) {
			fail(verifStr);
		}
	}
}



