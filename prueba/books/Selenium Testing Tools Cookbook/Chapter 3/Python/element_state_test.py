from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.common.exceptions import NoSuchElementException
from array import *
import time, unittest

class ElementStateTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get("https://dl.dropbox.com/u/55228056/Config.html")
		
	def test_element_is_enabled(self):
		driver = self.driver
		
		#Get the Checkbox as WebElement using it's name attribute
 		ledheadlamp = driver.find_element_by_xpath("//input[@name='ledheadlamp']")
 		
 		#Check if its enabled before selecting it
 		if ledheadlamp.is_enabled():
 			#Check if its already selected? otherwise select the Checkbox
 			if ledheadlamp.is_selected() == false:
 				ledheadlamp.click()
		else:
 			self.fail("LED Lamp Checkbox is disabled!!")
 		
	def test_is_element_present(self):
		driver = self.driver
		
		#//Check if element with locator criteria exists on Page
 		if is_element_present(By.Name,"airbags"):
			#Get the checkbox and select it
 			airbag = driver.find_element_by_name("airbags");
 			if airbag.is_selected() == false:
 				airbag.click();
 		else:
 			self.fail("Airbag Checkbox doesn't exists!!")
	
	def is_element_present(self, how, what):
		try: self.driver.find_element(by=how, value=what)
		except NoSuchElementException, e: return False
		return True

	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()