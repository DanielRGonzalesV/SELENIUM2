require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class ElementTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/DoubleClickDemo.html'
		@verification_errors = []
	end
	
	def test_element_text
		#Get the message Element
		message = @driver.find_element :id => "message"
				
		#Verify message element's text displays "Click on me and my color will change"
		assert_equal "Click on me and my color will change", message.text
		
		#Get the area Element
		area = @driver.find_element :id => "area"
		
		#Verify area element's text displays "Div's Text\nSpan's Text"
		assert_equal "Div's Text\nSpan's Text",area.text
	end
	
	def test_element_attribute
		#Get the message Element
		message = @driver.find_element :id => "message"
		assert_equal "justify", message.attribute("align")
	end
	
	def test_element_style
		#Get the message Element
		message = @driver.find_element :id => "message"
		assert_equal "150px", message.css_value("width")
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end