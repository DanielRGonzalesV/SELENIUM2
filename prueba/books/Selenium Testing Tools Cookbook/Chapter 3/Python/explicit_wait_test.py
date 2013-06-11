from selenium import webdriver
from selenium.webdriver.support.ui import WebDriverWait
import time, unittest

class ExplicitWaitTest (unittest.TestCase):
	def test_explicit_wait(self):
		driver = webdriver.Chrome()
		driver.get("http://dl.dropbox.com/u/55228056/AjaxDemo.html")
		
		#Get link for Page 4 and click on it
		page4button = driver.find_element_by_link_text("Page 4")
		page4button.click()
		
		WebDriverWait(driver, 10).until(lambda d: d.find_element_by_id("page4").is_displayed())
		#Get an element with id page4 and verify it's text
		message = driver.find_element_by_id("page4")
		self.assertEquals(True,message.text.startswith("Nunc nibh tortor"))
		driver.close()
		
	def test_explicit_wait_by_title(self):
		driver = webdriver.Chrome()
		driver.get("http://www.google.com")
		query = driver.find_element_by_name("q")
		query.send_keys("selenium")
		query.submit()
		 
		WebDriverWait(driver, 10).until(lambda d: d.title.startswith("selenium"))
		self.assertEquals(True, driver.title.startswith("selenium"))
		driver.close()

if __name__ == "__main__":
	unittest.main()