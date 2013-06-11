from selenium import webdriver
from array import *
import time, unittest

class ExecuteJavaScriptTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		
	def test_execute_java_script(self):
		driver = self.driver
		driver.get("http://www.google.com")
		
		title = driver.execute_script("return document.title")
		self.assertEquals("Google",title)
		
		links = driver.execute_script("var links = document.getElementsByTagName('A'); return links.length")
		self.assertEquals(42, links)
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()