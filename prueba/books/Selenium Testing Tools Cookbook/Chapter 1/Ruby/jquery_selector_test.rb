require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class JQuerySelectorTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/Locators.html'
		@verification_errors = []
	end
	
	def test_jquery_selector
	
		#Expected list of selected Checkbox
		checked = Array["user128_admin", "user220_browser"]
		
		elements = @driver.execute_script("return jQuery.find(':checked')")

		#Verify two Checkbox are selected 
		assert_equal 2, elements.length

		#Verify correct Checkbox are selected
		for element in elements
			assert_equal true, checked.include?(element.attribute("id"))
		end
	end

	def teardown
		@driver.close
		assert_equal [], @verification_errors
	end
end