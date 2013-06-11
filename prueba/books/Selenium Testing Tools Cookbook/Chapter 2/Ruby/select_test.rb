require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class SelectTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/Config.html'
		@verification_errors = []
	end
	
	def test_drop_down
	 	#Get the Dropdown as a Select using it's name attribute
 		make = Selenium::WebDriver::Support::Select.new(@driver.find_element(:name => "make"))
		
 		#Verify Dropdown does not support multiple selection
 		assert_equal false, make.multiple?
		
 		#Verify Dropdown has four options for selection
    	assert_equal 4, make.options.length
		
		#We will verify Dropdown has expected values as listed in a array
    	exp_options = Array["BMW", "Mercedes", "Audi","Honda"]
    	act_options = Array.new
		
		#Retrieve the option values from Dropdown using getOptions() method
    	for option in make.options
    		 act_options << option.text
		end
		
		#Verify expected options array and actual options array match
		assert_equal exp_options, act_options
		
		#With Select class we can select an option in Dropdown using Visible Text
    	make.select_by(:text,"Honda")
    	assert_equal "Honda", make.first_selected_option.text
    	
    	#or we can select an option in Dropdown using value attribute
		make.select_by(:value,"audi")
    	assert_equal "Audi", make.first_selected_option.text
    	
    	#or we can select an option in Dropdown using index
		make.select_by(:index,"0")
    	assert_equal "BMW", make.first_selected_option.text
	end
	
	def test_multiple_selection_in_list
	 	#Get the Dropdown as a Select using it's name attribute
 		color = Selenium::WebDriver::Support::Select.new(@driver.find_element(:name => "color"))
		
 		#Verify Dropdown does not support multiple selection
 		assert_equal true, color.multiple?
		
 		#Verify Dropdown has four options for selection
    	assert_equal 5, color.options.length
		
		#Select multiple options in the list using visible text
    	color.select_by(:text,"Black")
    	color.select_by(:text,"Red")
    	color.select_by(:text,"Silver")
	
		#Verify there 3 options selected in the list
    	assert_equal 3,color.selected_options.length
		
		#Deselect an option using visible text
    	color.deselect_by(:text,"Silver")
    	
    	#Deselect an option using value attribute of the option
    	color.deselect_by(:value,"rd")
    	
    	#Deselect an option using index of the option
    	color.deselect_by(:index,"0")
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end