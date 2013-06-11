from selenium import webdriver
from array import *
import time, unittest

class WindowPopupTest(unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get("http://dl.dropbox.com/u/55228056/Config.html")
		
	def  test_window_popup(self):
		driver = self.driver
		
		#Save the WindowHandle of Parent Browser Window
		parent_window_id = driver.current_window_handle
		
		#Clicking Help Button will open Help Page in a new Popup Browser Window
		help_button = driver.find_element_by_id("helpbutton")
		help_button.click();
		driver.switch_to_window("HelpWindow")
		driver.close()
		driver.switch_to_window(parent_window_id)
		
	def  test_window_popup_using_title(self):
		driver = self.driver
		
		#Save the WindowHandle of Parent Browser Window
		parent_window_id = driver.current_window_handle
		
		#Clicking Visit Us Button will open Visit Us Page in a new Popup Browser Window
		visitButton = driver.find_element_by_id("visitbutton")
		visitButton.click()
		
		#Get Handles of all the open Popup Windows
		#Iterate through the set and check if tile of each window matches with expected Window Title
		all_windows = driver.window_handles
		if all_windows is not None:
			for window_id in all_windows:
				driver.switch_to_window(window_id)
				if driver.title is "Visit Us":
						#Close the Visit Us Popup Window
						driver.close()
						break
		
		#Move back to the Parent Browser Window
		driver.switch_to_window(parent_window_id)
		
		#Save the WindowHandle of Parent Browser Window
		parent_window_id = driver.current_window_handle
	
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()