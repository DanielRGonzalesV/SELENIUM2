require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class DoubleClickTest < Test::Unit::TestCase
	def setup
		
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/DoubleClickDemo.html'
		@verification_errors = []
	end
	
	def test_double_click
		message = @driver.find_element :id => "message"
		
		#Verify color is Blue
		assert_equal "rgba(0, 0, 255, 1)", message.css_value('background-color').to_s()
		
		@driver.action.double_click(message).perform
		
		#Verify Color is Yellow
		assert_equal "rgba(255, 255, 0, 1)",message.css_value('background-color').to_s()
		
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end