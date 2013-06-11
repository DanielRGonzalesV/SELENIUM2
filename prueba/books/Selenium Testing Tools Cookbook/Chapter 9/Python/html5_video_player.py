from selenium import webdriver
from time import sleep

import time, unittest

class Html5VideoPlayer(unittest.TestCase):
	def setUp(self)	:
		self.driver = webdriver.Chrome()
		self.driver.get('http://dl.dropbox.com/u/55228056/html5video.html')
		
	def test_html5_session_storage(self):
		driver = self.driver
		
		#Get the HTML5 Video Element
		video_player = driver.find_element_by_id('vplayer')
		
		#Get the Source of Video that will be played in Video Player
		source = driver.execute_script('return arguments[0].currentSrc;', video_player)
		
		#Get the Duration of Video
		duration = driver.execute_script('return arguments[0].duration;', video_player)
					
		self.assertEqual('http://html5demos.com/assets/dizzy.mp4',source)
		self.assertEqual(25,duration)
		
		#Play the video
		driver.execute_script('return arguments[0].play();', video_player)
		
		#Wait for 5 seconds
		sleep(5)
		
		#Pause the video
		driver.execute_script('return arguments[0].pause();', video_player)
		
		#Take a screenshot of the Page with (for video controls)
		driver.save_screenshot('c:\\tmp\\pause_play.png')
		
	def tearDown(self):
		self.driver.close()
		
if __name__ == "__main__":
	unittest.main()