require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class Html5SessionStorage < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/html5storage.html'
		@verification_errors = []
	end
	
	def test_html5_session_storage
		click_button = @driver.find_element :id=>'click'
		clicks_field = @driver.find_element :id=>'clicks'
		
		#Get current value of sessionStorage.clickcount, should be null
		clickcount = @driver.execute_script('return sessionStorage.clickcount;')
		assert_equal nil, clickcount
		assert_equal '0', clicks_field.attribute('value')
		
		#Click the Button, this will increase the sessionStorage.clickcount value by 1
		click_button.click()
		
		#Get current value of sessionStorage.clickcount, should be 1
		clickcount = @driver.execute_script('return sessionStorage.clickcount;')
		assert_equal '1', clickcount
		assert_equal '1', clicks_field.attribute('value')
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end