require 'rubygems'
require 'watir-webdriver'
require 'test/unit'
require_relative 'bmicalcpage.rb'

class BmiCalcTest < Test::Unit::TestCase
	def test_bmi_calculation
		@driver = Selenium::WebDriver.for :chrome
		bmi_calc = BmiCalcPage.new(@driver)
		bmi_calc.open()
		bmi_calc.calculate_bmi('181','80')
		assert_equal '24.4', bmi_calc.bmi
		assert_equal 'Normal', bmi_calc.bmi_category
		bmi_calc.close()
	end
end