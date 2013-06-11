from selenium import webdriver
from selenium.webdriver.support.ui import Select
from selenium.webdriver.common.action_chains import ActionChains
import time, unittest

class Html5CanvasDrawing(unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get('http://dl.dropbox.com/u/55228056/html5canvasdraw.html')
		
	def test_html5_session_storage(self):
		driver = self.driver
		
		#Get the HTML5 Canvas Element
		canvas = driver.find_element_by_id('imageTemp')
		
		#Select the Pencil Tool
		drawtool = Select(driver.find_element_by_id('dtool'))
		drawtool.select_by_visible_text('Pencil')
		
		#Create a Action Chain for Draw a shape on Canvas
		ActionChains(driver).click_and_hold(canvas)\
										.move_by_offset(10, 50)\
										.move_by_offset(50,10)\
										.move_by_offset(-10,-50)\
										.move_by_offset(-50,-10)\
										.release().perform()
										
		#Get a screenshot of Canvas element after Drawing 
		driver.save_screenshot('c:\\tmp\\post.png')
	
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()