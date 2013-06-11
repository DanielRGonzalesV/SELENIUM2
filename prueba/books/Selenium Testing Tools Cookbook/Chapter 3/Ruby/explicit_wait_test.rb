require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class ImplicitWaitTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@verification_errors = []
	end
	
	def test_explicit_wait
		@driver.get 'http://dl.dropbox.com/u/55228056/AjaxDemo.html'
		#Get link for Page 4 and click on it
		page4button = @driver.find_element(:link_text => "Page 4")
		page4button.click
		
		wait = Selenium::WebDriver::Wait.new(:timeout => 10)
		wait.until { @driver.find_element(:id => "page4").displayed? }
	  
		#Get an element with id page4 and verify it's text
		message = @driver.find_element(:id => "page4")
		assert_equal true,message.text.include?("Nunc nibh tortor")
	end
	
	
	def test_explicit_wait_by_title
		@driver.get("http://www.google.com")
		query = @driver.find_element(:name => "q")
		query.send_keys "selenium"
		query.submit
		 
		wait = Selenium::WebDriver::Wait.new(:timeout => 10)
		wait.until { @driver.title.start_with?("selenium") }
		 
		assert_equal true, @driver.title.start_with?("selenium")
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end