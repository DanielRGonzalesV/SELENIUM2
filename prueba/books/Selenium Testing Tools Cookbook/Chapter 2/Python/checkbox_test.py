from selenium import webdriver
import time, unittest

class CheckBoxTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		
	def test_checkbox(self):
		driver = self.driver
		driver.get("http://dl.dropbox.com/u/55228056/Config.html")
		
		#Get the Checkbox as WebElement using it's value attribute
		airbags = driver.find_element_by_xpath("//input[@value='Airbags']")
		
		#Check if its already selected? otherwise select the Checkbox
 		#by calling click() method
 		if airbags.is_selected() == False:
 			airbags.click()
		
		#Verify Checkbox is Selected	
		self.assertEqual(True,airbags.is_selected())
		
 		#Check Checkbox if selected? If yes, deselect it
 		#by calling click() method
 		if airbags.is_selected():
 			airbags.click()
 		
 		#Verify Checkbox is Deselected
		self.assertEqual(False,airbags.is_selected())
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()