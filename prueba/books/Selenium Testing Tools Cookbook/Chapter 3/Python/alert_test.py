from selenium import webdriver
import time, unittest

class AlertTest (unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get("http://dl.dropbox.com/u/55228056/Alerts.html")
		
	def test_simple_alert(self):
		driver = self.driver
		
		#Clicking button will show a simple Alert with OK Button
		button = driver.find_element_by_id("simple")
		button.click()
		
		#Get the Alert
		alert = driver.switch_to_alert()
			
		#Get the Text displayed on Alert using getText() method of Alert class
		textOnAlert = alert.text
			
		#Click OK button, by calling accept() method of Alert Class
		alert.accept()
			
		#Verify Alert displayed correct message to user
		self.assertEquals("Hello! I am an alert box!", textOnAlert)

	def  test_confirm_alert(self):
		driver = self.driver
		
		#Clicking button will show a Confirmation Alert with OK and Cancel Button
		button = driver.find_element_by_id("confirm")
		button.click()
		
		#Get the Alert
		alert = driver.switch_to_alert()
			
		#Click OK button, by calling accept() method of Alert Class
		alert.accept()
		
		#Verify Page displays correct message on Accept
		message = driver.find_element_by_id("demo");
		self.assertEquals("You Accepted Alert!", message.text)
		
		button.click()
		
		#Get the Alert
		alert = driver.switch_to_alert()
		
		#Click Cancel button, by calling dismiss() method of Alert Class
		alert.dismiss()
		
		#Verify Page displays correct message on Dismiss
		self.assertEquals("You Dismissed Alert!", message.text)

	def  test_prompt(self):
		driver = self.driver
		
		#Clicking button will show a Prompt Alert asking user to enter
		#value/text with OK and Cancel Button
		button = driver.find_element_by_id("prompt")
		button.click()
		
		#Get the Alert
		alert = driver.switch_to_alert()
		
		#Enter some value on Prompt by calling sendKeys() method of Alert Class
		alert.send_keys("Foo")
		
		#Click OK button, by calling accept() method of Alert Class
		alert.accept()
	
		#Verify Page displays message with value entered in Prompt
		message = driver.find_element_by_id("prompt_demo");
		self.assertEquals("Hello Foo! How are you today?", message.text)
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()