require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class Html5LocalStorage < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/html5storage.html'
		@verification_errors = []
	end
	
	def test_html5_local_storage
		#Get the current value of localStorage.lastname, this should be Smith
		lastname = @driver.execute_script('return localStorage.lastname;')
		assert_equal "Smith", lastname
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end