require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'
require 'win32ole'

class HttpAuthTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://www.httpwatch.com/httpgallery/authentication'
		@verification_errors = []
	end
	
	def test_http_auth_window
		#Create instance of AutoItX3 control. 
		#This will provide access to AutoItX COM API
		au3 = WIN32OLE.new("AutoItX3.Control")
		
		#Get the Display Image button and 
		#click on it to invoke the Http Authentication dialog
		display_image_button = @driver.find_element :id => "displayImage"
		display_image_button.click
		
		#Wait for couple of seconds for Http Authentication
		#dialog to appear
		sleep(2)
		
		#Check if Http Authentication dialog exists and 
		#enter login details using send method
		result = au3.WinExists("HTTP Authentication - Google Chrome")  
		if result then
			au3.WinActivate("HTTP Authentication - Google Chrome","")
			au3.Send("httpwatch{TAB}")
			au3.Send("jsdhfkhkhfd{Enter}")
		end
		assert_equal 1, result
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end