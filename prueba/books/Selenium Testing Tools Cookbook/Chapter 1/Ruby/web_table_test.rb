require 'rubygems'
require 'selenium-webdriver'
require 'test/unit'

class WebTableTest < Test::Unit::TestCase
	def setup
		@driver = Selenium::WebDriver.for :chrome
		@driver.get 'http://dl.dropbox.com/u/55228056/Locators.html'
		@verification_errors = []
	end
	
	def test_web_table
		simpleTable = @driver.find_element(:id => "items" )
		
		#Get all rows
		rows = simpleTable.find_elements(:tag_name => "tr")
		assert_equal 3, rows.length
		
		#Print data from each row
		for row in rows
			cols = row.find_elements(:tag_name => "td")
			assert_equal 2, cols.length
			line = []
			for col in cols
				line << col.text + "\t"
			end
			puts line.join
		end
	end
	
	def teardown
		@driver.close
		assert_equal [], @verification_errors
	end
end