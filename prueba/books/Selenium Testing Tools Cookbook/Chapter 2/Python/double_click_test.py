from selenium import webdriver
from selenium.webdriver.common.action_chains import ActionChains
from array import *
import time, unittest

class DoubleClickTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		
	def test_double_click(self):
		driver = self.driver
		driver.get("http://dl.dropbox.com/u/55228056/DoubleClickDemo.html")
		
		message = driver.find_element_by_id("message")
		
		#Verify color is Blue
		self.assertEqual("rgba(0, 0, 255, 1)", message.value_of_css_property("background-color"))
		
		ActionChains(self.driver).double_click(message).perform()
		
		#Verify Color is Yellow
		self.assertEqual("rgba(255, 255, 0, 1)", message.value_of_css_property("background-color"))
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()