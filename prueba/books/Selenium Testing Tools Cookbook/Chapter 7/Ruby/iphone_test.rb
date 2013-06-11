require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class IPhoneTest < Test::Unit::TestCase
	def setup
		
		driver = Selenium::WebDriver.for :iphone # or use-> Selenium::WebDriver.for :remote, :url => "http://http://192.168.1.100:3001/wd/hub", :desired_capabilities => :iphone
		@driver.get 'http://dl.dropbox.com/u/55228056/mobilebmicalculator.html'
		@verification_errors = []
	end
	
	def test_bmi_calc_mobile_version
		height = @driver.find_element :name => "heightCMS"
		height.send_keys '181'

		weight = @driver.find_element :name => "weightKg"
		weight.send_keys  '80'

		calculateButton = @driver.find_element :id =>"Calculate"
		calculateButton.click

		bmi = @driver.find_element :name =>"bmi"
		bmi_category = @driver.find_element :name =>"bmi_category"
		
		assert_equal '24.4', bmi.attribute('value')
		assert_equal 'Normal', bmi_category.attribute('value')
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end