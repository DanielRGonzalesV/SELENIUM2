require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class DragAndDropTest < Test::Unit::TestCase
	def setup
		
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/DragDropDemo.html'
		@verification_errors = []
	end
	
	def test_drag_and_drop
		source = @driver.find_element :id => "draggable"
		target = @driver.find_element :id => "droppable"
				
		@driver.action.drag_and_drop(source, target).perform
		assert_equal "Dropped!",target.text
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end