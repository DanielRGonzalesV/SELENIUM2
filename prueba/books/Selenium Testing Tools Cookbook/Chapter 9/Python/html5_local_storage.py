from selenium import webdriver
import time, unittest

class Html5LocalStorage (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get('http://dl.dropbox.com/u/55228056/html5storage.html')
		
	def test_html5_session_storage(self):
		driver = self.driver
		
		#Get the current value of localStorage.lastname, this should be Smith
		last_name = driver.execute_script("return localStorage.lastname;")
		self.assertEqual('Smith',last_name)

	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()