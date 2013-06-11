from selenium import webdriver
import time, unittest

class ImplicitWaitTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get("http://dl.dropbox.com/u/55228056/AjaxDemo.html")
		
	def test_implicit_wait(self):
		driver = self.driver
		
		#Set the Implicit Wait time Out to 10 Seconds
		driver.implicitly_wait(10)
		
		#Get link for Page 4 and click on it
		page4button = driver.find_element_by_link_text("Page 4")
		page4button.click()
			
		#Get an element with id page4 and verify it's text
		message = driver.find_element_by_id("page4")
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()