from selenium import webdriver
import time, unittest

class Html5SessionStorage (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get('http://dl.dropbox.com/u/55228056/html5storage.html')
		
	def test_html5_session_storage(self):
		driver = self.driver
		
		click_button = driver.find_element_by_id('click')
		clicks_field = driver.find_element_by_id('clicks')
		
		#Get current value of sessionStorage.clickcount, should be null
		clickcount = driver.execute_script('return sessionStorage.clickcount;')
		self.assertEqual(None,clickcount)
		self.assertEqual('0',clicks_field.get_attribute('value'))
		
		#Click the Button, this will increase the sessionStorage.clickcount value by 1
		click_button.click()
		
		#Get current value of sessionStorage.clickcount, should be 1
		clickcount = driver.execute_script('return sessionStorage.clickcount;')
		self.assertEqual('1',clickcount)
		self.assertEqual('1',clicks_field.get_attribute('value'))

	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()