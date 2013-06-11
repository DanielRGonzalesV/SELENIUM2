require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class ImplicitWaitTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/AjaxDemo.html'
		@verification_errors = []
	end
	
	def test_implicit_wait
	
	#Set the Implicit Wait time Out to 10 Seconds
 	@driver.manage.timeouts.implicit_wait = 10
	
	#Get link for Page 4 and click on it
 	page4button = @driver.find_element(:link_text => "Page 4")
 	page4button.click
 		
 	#Get an element with id page4 and verify it's text
 	message = @driver.find_element(:id => "page4");
 	assert_equal true,message.text.include?("Nunc nibh tortor")
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end