require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class AlertTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/Config.html'
		@verification_errors = []
	end
	
	def  test_window_popup
		
		#Save the WindowHandle of Parent Browser Window
		parent_window_id = @driver.window_handle
		
		#Clicking Help Button will open Help Page in a new Popup Browser Window
		help_button = @driver.find_element(:id => "helpbutton")
		help_button.click
		@driver.switch_to.window "HelpWindow"
		@driver.close
		@driver.switch_to.window parent_window_id
	end
		
	def  test_window_popup_using_title
		#Save the WindowHandle of Parent Browser Window
		parent_window_id = @driver.window_handle
		
		#Clicking Visit Us Button will open Visit Us Page in a new Popup Browser Window
		visitButton = @driver.find_element(:id => "visitbutton")
		visitButton.click
		
		#Get Handles of all the open Popup Windows
		#Iterate through the set and check if tile of each window matches with expected Window Title
		all_windows = @driver.window_handles
		if all_windows != nil then
			for window_id in all_windows
				@driver.switch_to.window window_id
				if @driver.title == "Visit Us"
						#Close the Visit Us Popup Window
						@driver.close()
						break
				end
			end
		end
		
		#Move back to the Parent Browser Window
		@driver.switch_to.window parent_window_id
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end