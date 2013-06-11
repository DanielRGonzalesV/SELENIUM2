require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class ExecuteJavaScriptTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://www.google.com'
		@verification_errors = []
	end
	
	def test_javascript_calls
		title = driver.execute_script("return document.title").to_s();
		assert_equal "Google", title
		
		links = @driver.execute_script("var links = document.getElementsByTagName('A'); return links.length").to_s()
		assert_equal "42", links
	end

	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end