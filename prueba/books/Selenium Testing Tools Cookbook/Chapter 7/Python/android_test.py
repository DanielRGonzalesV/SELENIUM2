from selenium import webdriver
import time, unittest

class OnAndroid (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Remote(command_executor='http://localhost:8080/wd/hub', desired_capabilities = webdriver.DesiredCapabilities.ANDROID)
		
	def test_bmi_calc_mobile_version(self):
		driver = self.driver
		driver.get("http://dl.dropbox.com/u/55228056/mobilebmicalculator.html")
		
		heightField = driver.find_element_by_name("heightCMS")	
		heightField.send_keys("181")
		
		weightField = driver.find_element_by_name("weightKg")	
		weightField.send_keys("80")
		
		calculateButton = driver.find_element_by_id("Calculate")	
		calculateButton.click()
		
		bmiLabel = driver.find_element_by_name("bmi")
		bmiCategoryLabel = driver.find_element_by_name("bmi_category")
		
		self.assertEqual("24.4",bmiLabel.get_attribute("value"))
		self.assertEqual("Normal",bmiCategoryLabel.get_attribute("value"))

	def tearDown(self):
		self.driver.quit()
		
if __name__ == "__main__":
	unittest.main()