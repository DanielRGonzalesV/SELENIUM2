from selenium import webdriver
from selenium.webdriver.support.ui import WebDriverWait 
from castro import Castro
import time, unittest

class VideoRecordingTests (unittest.TestCase) :
	def setUp(self)	:
		# Create an instance of Castro and provide name for the output file
		self.screenCapture = Castro(filename="testGoogleSearch.swf")
		# Start the recording of movie
		self.screenCapture.start()
		self.driver = webdriver.Firefox()

	def testGoogleSearch(self) :
		driver = self.driver
		driver.get("http://www.google.com")
		inputElement = driver.find_element_by_name("q")	
		inputElement.send_keys("Cheese!")
		inputElement.submit()
		WebDriverWait(driver, 20).until(lambda driver : driver.title.lower().startswith("cheese!"))
		self.assertEqual("cheese! - Google Search",driver.title)

	def tearDown(self) :
		self.driver.quit()
		# Stop the recording
		self.screenCapture.stop();
		
if __name__ == "__main__":
	unittest.main()