require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class Html5CanvasDrawing < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/html5canvasdraw.html'
		@verification_errors = []
	end
	
	def test_html5_canvas_drawing
		#Get the HTML5 Canvas Element
		canvas = @driver.find_element :id=> 'imageTemp'
		
		#Select the Pencil Tool
		drawtool = Selenium::WebDriver::Support::Select.new(@driver.find_element(:id => 'dtool'))
		drawtool.select_by :text, 'Pencil'
		
		#Create a Action Chain for Draw a shape on Canvas
		@driver.action.click_and_hold(canvas).move_by(10, 50).
									 move_by(50,10).
									 move_by(-10,-50).
									 move_by(-50,-10).release().perform()
		
		#Get a screenshot of Canvas element after Drawing 
		@driver.save_screenshot('c:\\tmp\\post.png')
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end