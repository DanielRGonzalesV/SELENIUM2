from selenium import webdriver
import time, unittest

class ScreenShotTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		
	def test_screen_shot(self):
		driver = self.driver
		driver.get("http://www.google.com")
		driver.save_screenshot("c:\\tmp\\main_page.png")
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()