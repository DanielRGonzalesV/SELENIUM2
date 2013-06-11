require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class AlertTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/Alerts.html'
		@verification_errors = []
	end
	
	def test_simple_alert
		#Clicking button will show a simple Alert with OK Button
		button = @driver.find_element(:id => "simple")
		button.click
		
		#Get the Alert
		alert = @driver.switch_to.alert
			
		#Get the Text displayed on Alert using getText() method of Alert class
		textOnAlert = alert.text
			
		#Click OK button, by calling accept() method of Alert Class
		alert.accept
			
		#Verify Alert displayed correct message to user
		assert_equal "Hello! I am an alert box!", textOnAlert
	end
	
	def test_confirm_alert
		#Clicking button will show a Confirmation Alert with OK and Cancel Button
		button = @driver.find_element(:id => "confirm")
		button.click
		
		#Get the Alert
		alert = @driver.switch_to.alert
			
		#Click OK button, by calling accept() method of Alert Class
		alert.accept
		
		#Verify Page displays correct message on Accept
		message = @driver.find_element(:id => "demo");
		assert_equal "You Accepted Alert!", message.text
		
		button.click
		
		#Get the Alert
		alert = @driver.switch_to.alert
		
		#Click Cancel button, by calling dismiss() method of Alert Class
		alert.dismiss
		
		#Verify Page displays correct message on Dismiss
		assert_equal "You Dismissed Alert!", message.text
	end
	
	def test_prompt
		#Clicking button will show a Prompt Alert asking user to enter
		#value/text with OK and Cancel Button
		button = @driver.find_element(:id => "prompt")
		button.click
		
		#Get the Alert
		alert = @driver.switch_to.alert
		
		#Enter some value on Prompt by calling sendKeys() method of Alert Class
		alert.send_keys "Foo"
		
		#Click OK button, by calling accept() method of Alert Class
		alert.accept
	
		#Verify Page displays message with value entered in Prompt
		message = @driver.find_element(:id => "prompt_demo");
		assert_equal "Hello Foo! How are you today?", message.text
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end