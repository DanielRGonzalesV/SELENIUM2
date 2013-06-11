require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class CheckBoxTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/Config.html'
		@verification_errors = []
	end
	
	def test_checkbox
		#Get the Checkbox as WebElement using it's value attribute
		airbags = @driver.find_element :xpath => "//input[@value='Airbags']"
				
		#Check if its already selected? otherwise select the Checkbox
 		#by calling click() method
 		if airbags.selected? == false
 			airbags.click
		end
		
		#Verify Checkbox is Selected	
		assert_equal true, airbags.selected?
 		
 		#Check Checkbox if selected? If yes, deselect it
 		#by calling click() method
 		if  airbags.selected?
 			airbags.click
		end
 		
 		#Verify Checkbox is Deselected
 		assert_equal false, airbags.selected?
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end