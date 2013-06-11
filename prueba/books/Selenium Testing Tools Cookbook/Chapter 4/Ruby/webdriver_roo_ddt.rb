require 'rubygems'
require 'selenium-webdriver'
require 'roo'

#Create an instance of WebDriver for Firefox
driver = Selenium::WebDriver.for :firefox

#Variables for Printing Test Summary
test_executed = 0
test_passed = 0
test_failed = 0

#Create an instance of a Excel Spreadsheet
data = Excel.new("C:\\Data.xls")
data.default_sheet = data.sheets.first

#Iterate through the Sheet reading Rows line by line
data.first_row.upto(data.last_row) do |line|
	if data.cell(line,1) != "Height" #Ignore the first line for Headers
		begin
			test_status = true
			test_executed = test_executed + 1
			puts "Test " + test_executed.to_s()
			
			driver.get "http://dl.dropbox.com/u/55228056/bmicalculator.html"

			height = driver.find_element :name => "heightCMS"
			height.send_keys data.cell(line,1).to_s()

			weight = driver.find_element :name => "weightKg"
			weight.send_keys  data.cell(line,2).to_s()

			calculateButton = driver.find_element :id =>"Calculate"
			calculateButton.click

			bmi = driver.find_element :name =>"bmi"
			bmi_category = driver.find_element :name =>"bmi_category"
			
			if bmi.attribute("value").to_s() == data.cell(line,3).to_s()
				puts "Pass, expected value for BMI <" + data.cell(line,3).to_s() + ">, actual <" + bmi.attribute("value").to_s() + ">"
			else
				puts "Fail, expected value for BMI <" + data.cell(line,3).to_s() + ">, actual <" + bmi.attribute("value").to_s() + ">"
				test_status=false
			end
			
			if bmi_category.attribute("value").to_s() == data.cell(line,4).to_s()
				puts "Pass, expected value for BMI Category <" + data.cell(line,4).to_s() + ">, actual <" +  bmi_category.attribute("value").to_s() + ">"
			else
				puts "Fail, expected value for BMI Category <" + data.cell(line,4).to_s() + ">, actual <" +  bmi_category.attribute("value").to_s() + ">"
				test_status=false
			end
			
			if test_status == true 
				test_passed = test_passed + 1
			else
				test_failed = test_failed + 1
			end 
		rescue
			puts "An error occurred: #{$!}"
		end
	end 
end

puts "--------------------------------------------"
puts "Total (" + test_executed.to_s() + ") Tests Executed"
puts "Total (" + test_passed.to_s() + ") Tests Passed"
puts "Total (" + test_failed.to_s() + ") Tests Failed"

driver.quit