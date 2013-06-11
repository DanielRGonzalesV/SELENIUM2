from selenium import webdriver
from array import *
import time, unittest

class WebTableTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get("http://dl.dropbox.com/u/55228056/Locators.html")
		
	def test_web_table(self):
		driver = self.driver
		
		simpleTable = driver.find_element_by_id("items" )
		
		#Get all rows
		rows = simpleTable.find_elements_by_tag_name("tr")
		self.assertEquals(3, len(rows))
		
		#Print data from each row
		for row in rows:
			cols = row.find_elements_by_tag_name("td")
			self.assertEquals(2, len(cols))
			line = []
			for col in cols:
				line.append(col.text)
			print "\t".join(line)
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()