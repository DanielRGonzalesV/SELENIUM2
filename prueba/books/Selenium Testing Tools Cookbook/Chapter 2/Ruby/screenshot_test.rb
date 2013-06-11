require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class ScreenShotTest < Test::Unit::TestCase
	def setup
		
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://www.google.com'
		@verification_errors = []
	end
	
	def test_screen_shot
		@driver.save_screenshot("c:\\tmp\\main_page.png")
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end