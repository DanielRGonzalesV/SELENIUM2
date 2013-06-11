from selenium import webdriver
from array import *
import time, unittest

class RadioButtonTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		
	def test_radio_button(self):
		driver = self.driver
		driver.get("http://dl.dropbox.com/u/55228056/Config.html")
		
		#Get the Radio Button as WebElement using it's value attribute
		petrol = driver.find_element_by_xpath("//input[@value='Petrol']")

		#Check if its already selected? otherwise select the Radio Button 
 		#by calling click() method 
 		if petrol.is_selected() == False:
 			petrol.click()
		
		#Verify Radio Button is selected 	
		self.assertEqual(True,petrol.is_selected())
		
		#We can also get all the Radio buttons from a Radio Group in a list
 		#using find_elements() method along with Radio Group identifier
 		fuel_type = driver.find_elements_by_name("fuel_type")
		for type in fuel_type:
			if type.get_attribute("value") == "Diesel":
				type.click()
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()