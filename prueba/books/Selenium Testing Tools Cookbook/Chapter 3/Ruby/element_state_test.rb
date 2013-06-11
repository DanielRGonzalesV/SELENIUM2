require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class ElementStateTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'https://dl.dropbox.com/u/55228056/Config.html'
		@verification_errors = []
	end
	
	def test_element_is_enabled
		#Get the Checkbox as WebElement using it's name attribute
 		ledheadlamp = @driver.find_element(:xpath => "//input[@name='ledheadlamp']")
 		
 		#Check if its enabled before selecting it
 		if ledheadlamp.enabled?
 			#Check if its already selected? otherwise select the Checkbox
 			if ledheadlamp.selected? == false
 				ledheadlamp.click
		end
		else
 			flunk "LED Lamp Checkbox is disabled!!"
 		end
	end
	
	def test_is_element_present
		#//Check if element with locator criteria exists on Page
 		if element_present?(:name,"airbags")
			#Get the checkbox and select it
 			airbag = @driver.find_element(:name => "airbags");
 			if airbag.selected? == false
 				airbag.click();
 		end
 		else
 			flunk "Airbag Checkbox doesn't exists!!"
 		end
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
	
	def element_present?(how, what)
		@driver.find_element(how, what)
		true
		rescue Selenium::WebDriver::Error::NoSuchElementError
			false
	end
  
end