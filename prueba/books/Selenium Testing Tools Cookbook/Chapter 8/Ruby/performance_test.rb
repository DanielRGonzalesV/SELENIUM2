require 'rubygems'
require 'watir-webdriver'
require 'watir-webdriver-performance'
require "test/unit"

class BmiCalcTest < Test::Unit::TestCase
	def setup
		@browser = Watir::Browser.new :firefox
		@verification_errors = []
	end
	
	def test_responseTime
		@browser.goto 'unmesh.me'
		@load_secs  = @browser.performance.summary[:response_time]/1000
		puts "Response Time: " + @load_secs.to_s()
		assert_equal true, @load_secs < 15
	end
	
	def teardown
		@browser.close
		assert_equal [], @verification_errors
	end
end