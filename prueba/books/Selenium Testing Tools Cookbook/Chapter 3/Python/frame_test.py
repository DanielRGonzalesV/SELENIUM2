from selenium import webdriver
from array import *
import time, unittest

class FrameTest(unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get("http://dl.dropbox.com/u/55228056/Frames.html")
	
	def  test_select_frame_with_id_or_name(self):
		driver = self.driver
		
		#Activate the frame on left side using it's id attribute
		driver.switch_to_frame("left")
		
		#Get an element from the frame on left side and verify it's contents
		leftmsg = driver.find_element_by_tag_name("p")
		self.assertEquals("This is Left Frame", leftmsg.text)
		
		#Activate the Page, this will move context from frame back to the Page
		driver.switch_to_default_content()
		
		#Activate the frame on right side using it's name attribute
		driver.switch_to_frame("right")
		
		#Get an element from the frame on right side and verify it's contents
		rightmsg = driver.find_element_by_tag_name("p")
		self.assertEquals("This is Right Frame", rightmsg.text)
		
		#Activate the Page, this will move context from frame back to the Page	
		driver.switch_to_default_content()

	def test_select_frame_by_index(self):
		driver = self.driver
		
		#Activate the frame in middle using it's index. Index starts at 0
		driver.switch_to_frame(1)
		
		#Get an element from the frame in the middle and verify it's contents
		leftmsg = driver.find_element_by_tag_name("p")
		self.assertEquals("This Frame doesn't have id or name", leftmsg.text)
		
		#Activate the Page, this will move context from frame back to the Page
		driver.switch_to_default_content()
	
	def test_select_frame_by_contents(self):
		driver = self.driver
		
		#Get all frames on the Page, created with <frame> tag
		frames = driver.find_elements_by_tag_name("frame")

		#In this example frame in the middle is activated by checking the contents
		#Activate frame and check if it has the desired content. If found perform the operations
		#if not, then switch back to the Page and continue checking next frame
		for frame in frames: 
			#switch_to().frame also accepts frame elements apart from id, name or index 
			driver.switch_to_frame(frame)
			if driver.page_source.find("This Frame doesn't have id or name") >= 0:
				break
			else:
				driver.switch_to_default_content()
	
		#perform action on the frame
		driver.switch_to_default_content()	

	def test_select_iframe(self):
		driver = self.driver
		
		#The frame on the right side has a nested iframe containing 'Twitter Follow' Button
		#Activate the frame on right side using it's name attribute
		driver.switch_to_frame("right")
		
		#Get the iframe element
		twitterframe = driver.find_element_by_tag_name("iframe")
		#Activate the iframe 
		driver.switch_to_frame(twitterframe)
		
		#Get and Click the follow button from iframe
		#Popup Window will appear after click
		button = driver.find_element_by_id("follow-button")
		button.click()
		
		#Store the handle of current driver window
		current_window = driver.current_window_handle 
		
		#The Twitter Popup does not have name or title. 
		#Script will get handles of all open windows and 
		#desired window will be activated by checking it's Title
		all_windows = driver.window_handles
		if all_windows is not None:
			for window_id in all_windows:
				driver.switch_to_window(window_id)
				if driver.title is "Unmesh Gundecha (@upgundecha) on Twitter":
					driver.close()
					break
		
		#Switch back to original driver window
		driver.switch_to_window(current_window)
		#switch back to Page from the frame
		driver.switch_to_default_content()
	
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()