from selenium import webdriver
from selenium.webdriver.support.ui import Select
from array import *
import time, unittest

class SelectTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get("http://dl.dropbox.com/u/55228056/Config.html")
	
	def test_drop_down(self):
		driver = self.driver
		
		exp_options = [ "BMW", "Mercedes", "Audi", "Honda" ]
		act_options = []
		
	 	#Get the Dropdown as a Select using it's name attribute
 		make = Select(driver.find_element_by_name("make"))
		
		#Verify Dropdown has four options for selection
		self.assertEqual(4,len(make.options))
    	
		#Retrieve the option values from Dropdown using getOptions() method
		for option in make.options:
			act_options.append(option.text)
		
		#Verify Dropdown has four options for selection
		self.assertEqual(exp_options,act_options)
		
		#With Select class we can select an option in Dropdown using Visible Text
		make.select_by_visible_text("Honda")
		self.assertEqual("Honda",make.first_selected_option.text)
    	
		#or we can select an option in Dropdown using value attribute
		make.select_by_value("audi")
		self.assertEqual("Audi",make.first_selected_option.text)
		
		#or we can select an option in Dropdown using index
		make.select_by_index("0")
		self.assertEqual("BMW",make.first_selected_option.text)
	
	def test_multiple_selection_in_list(self):
		driver = self.driver
		
	 	#Get the Dropdown as a Select using it's name attribute
 		color = Select(driver.find_element_by_name("color"))
		
		#Verify Dropdown has four options for selection
		self.assertEqual(5,len(color.options))
		
		#Select multiple options in the list using visible text
		color.select_by_visible_text("Black")
		color.select_by_visible_text("Red")
		color.select_by_visible_text("Silver")
		
		#Deselect an option using visible text
		color.deselect_by_visible_text("Silver")
    	
		#Deselect an option using value attribute of the option
		color.deselect_by_value("rd")
		
		#Deselect an option using index of the option
		color.deselect_by_index(0)
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()