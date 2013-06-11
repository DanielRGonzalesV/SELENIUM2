require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class Html5VideoPlayer < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/html5video.html'
		@verification_errors = []
	end
	
	def test_html5_video_player
		#Get the HTML5 Video Element
		video_player = @driver.find_element :id=> 'vplayer'
		
		#Get the Source of Video that will be played in Video Player
		source = @driver.execute_script('return arguments[0].currentSrc;', video_player)
		
		#Get the Duration of Video
		duration = @driver.execute_script('return arguments[0].duration;', video_player)
					
		assert_equal 'http://html5demos.com/assets/dizzy.mp4',source
		assert_equal 25, duration
		
		#Play the video
		@driver.execute_script('return arguments[0].play();', video_player)
		
		#Wait for 5 seconds
		sleep(5)
		
		#Pause the video
		@driver.execute_script('return arguments[0].pause();', video_player)
		
		#Take a screenshot of the Page with (for video controls)
		@driver.save_screenshot('c:\\tmp\\pause_play.png')
	end
	
	def teardown
		@driver.quit
		assert_equal [], @verification_errors
	end
end