from selenium import webdriver
from selenium.webdriver.common.action_chains import ActionChains
from array import *
import time, unittest

class ElementTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get("http://dl.dropbox.com/u/55228056/DoubleClickDemo.html")
		
	def test_element_text(self):
		driver = self.driver
		
		#Get the message Element
		message = driver.find_element_by_id("message")
				
		#Verify message element's text displays "Click on me and my color will change"
		self.assertEqual("Click on me and my color will change", message.text)
		
		#Get the area Element
		area = driver.find_element_by_id("area")
		
		#Verify area element's text displays "Div's Text\nSpan's Text"
		self.assertEqual("Div's Text\nSpan's Text", area.text)
	
	def test_element_attribute(self):
		driver = self.driver
		
		#Get the message Element
		message = driver.find_element_by_id("message")
		self.assertEqual("justify", message.get_attribute("align"))
	
	def test_element_style(self):
		driver = self.driver
		
		#Get the message Element
		message = driver.find_element_by_id("message")
		self.assertEqual("150px", message.value_of_css_property("width"))
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()