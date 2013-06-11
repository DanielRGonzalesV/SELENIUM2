require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class FrameTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/Frames.html'
		@verification_errors = []
	end
	
	def test_select_frame_with_id_or_name
		#Activate the frame on left side using it's id attribute
		@driver.switch_to.frame "left"
		
		#Get an element from the frame on left side and verify it's contents
		leftmsg = @driver.find_element(:tag_name => "p")
		assert_equal "This is Left Frame", leftmsg.text
		
		#Activate the Page, this will move context from frame back to the Page
		@driver.switch_to.default_content
		
		#Activate the frame on right side using it's name attribute
		@driver.switch_to.frame "right"
		
		#Get an element from the frame on right side and verify it's contents
		rightmsg = @driver.find_element(:tag_name => "p")
		assert_equal "This is Right Frame", rightmsg.text
		
		#Activate the Page, this will move context from frame back to the Page	
		@driver.switch_to.default_content
	end
	
	def test_select_frame_by_index
		#Activate the frame in middle using it's index. Index starts at 0
		@driver.switch_to.frame 1
		
		#Get an element from the frame in the middle and verify it's contents
		leftmsg = @driver.find_element(:tag_name => "p")
		assert_equal "This Frame doesn't have id or name", leftmsg.text
		
		#Activate the Page, this will move context from frame back to the Page
		@driver.switch_to.default_content
	end
	
	def test_select_frame_by_contents
		#Get all frames on the Page, created with <frame> tag
		frames = @driver.find_elements(:tag_name => "frame")

		#In this example frame in the middle is activated by checking the contents
		#Activate frame and check if it has the desired content. If found perform the operations
		#if not, then switch back to the Page and continue checking next frame
		for frame in frames 
			#switch_to().frame also accepts frame elements apart from id, name or index 
			@driver.switch_to.frame frame
			if @driver.page_source.include?("This Frame doesn't have id or name") then
				break
			else
				@driver.switch_to.default_content
			end
		end

		#perform action on the frame
		@driver.switch_to.default_content	
	end

	def test_select_iframe
		#The frame on the right side has a nested iframe containing 'Twitter Follow' Button
		#Activate the frame on right side using it's name attribute
		@driver.switch_to.frame "right"
		
		#Get the iframe element
		twitterframe = @driver.find_element(:tag_name => "iframe")
		#Activate the iframe 
		@driver.switch_to.frame twitterframe
		
		#Get and Click the follow button from iframe
		#Popup Window will appear after click
		button = @driver.find_element(:id => "follow-button")
		button.click
		
		#Store the handle of current driver window
		current_window = @driver.window_handle 
		
		#The Twitter Popup does not have name or title. 
		#Script will get handles of all open windows and 
		#desired window will be activated by checking it's Title
		all_windows = @driver.window_handles
		if all_windows != nil then
			for window_id in all_windows
				@driver.switch_to.window window_id
				if @driver.title == "Unmesh Gundecha (@upgundecha) on Twitter" then
					@driver.close
					break
				end
			end
		end			
		
		#Switch back to original driver window
		@driver.switch_to.window current_window
		#switch back to Page from the frame
		@driver.switch_to.default_content
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end