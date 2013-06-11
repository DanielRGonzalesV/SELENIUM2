from selenium import webdriver
from selenium.webdriver.common.action_chains import ActionChains
from array import *
import time, unittest

class DragAndDropTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		
	def test_drag_and_drop(self):
		driver = self.driver
		driver.get("http://dl.dropbox.com/u/55228056/DragDropDemo.html")
		
		source = driver.find_element_by_id("draggable")
		target = driver.find_element_by_id("droppable")
				
		ActionChains(self.driver).drag_and_drop(source, target).perform()
		self.assertEqual("Dropped!", target.text)
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()