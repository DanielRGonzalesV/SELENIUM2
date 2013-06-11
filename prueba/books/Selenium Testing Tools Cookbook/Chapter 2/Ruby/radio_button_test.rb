require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class RadioButtonTest < Test::Unit::TestCase
	def setup
		
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/Config.html'
		@verification_errors = []
	end
	
	def test_radio_button
		#Get the Radio Button as WebElement using it's value attribute
		petrol = @driver.find_element :xpath => "//input[@value='Petrol']"
				
 		#Check if its already selected? otherwise select the Radio Button 
 		#by calling click() method 
 		if petrol.selected? == false
 			petrol.click
		end
		
		#Verify Radio Button is selected 	
		assert_equal true, petrol.selected?
 		
		#We can also get all the Radio buttons from a Radio Group in a list
 		#using find_elements() method along with Radio Group identifier
 		fuel_type = @driver.find_elements :name => "fuel_type"
		for type in fuel_type
			if type.attribute("value") == "Diesel"
				type.click
			end
		end
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end