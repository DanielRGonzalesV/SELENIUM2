from selenium import webdriver
import csv, sys

#Variables for Printing Test Summary
test_executed = 0
test_passed = 0
test_failed = 0
test_status = True

try:
	#Create an instance of WebDriver for Firefox
	driver = webdriver.Firefox()
	driver.get("http://dl.dropbox.com/u/55228056/bmicalculator.html")
	
	#Open the CSV file 
	datafile  = open('c:\data.csv', "rb")
	#Create a CSV Reader from CSV file
	reader = csv.reader(datafile)

	test_executed = 0
	#Iterate through the CSV Rows line by line
	for row in reader:
		test_executed += 1
		print "Test " + str(test_executed)
		
		heightField = driver.find_element_by_name("heightCMS")	
		heightField.clear()
		heightField.send_keys(row[0])
		
		weightField = driver.find_element_by_name("weightKg")	
		weightField.clear()
		weightField.send_keys(row[1])
		
		calculateButton = driver.find_element_by_id("Calculate")	
		calculateButton.click()
		
		bmiLabel = driver.find_element_by_name("bmi")
		bmiCategoryLabel = driver.find_element_by_name("bmi_category")
		
		if bmiLabel.get_attribute("value") == row[2]:
			print "Pass, expected value for BMI <" + row[2] + ">, actual <" + bmiLabel.get_attribute("value") + ">"
		else:
			print "Fail, expected value for BMI <" + row[2] + ">, actual <" + bmiLabel.get_attribute("value") + ">"
			test_status = False
		
		if bmiCategoryLabel.get_attribute("value") == row[3]:
			print "Pass, expected value for BMI Category <" + row[3] + ">, actual <" + bmiCategoryLabel.get_attribute("value") + ">"
		else:
			print "Fail, expected value for BMI Category <" + row[3] + ">, actual <" + bmiCategoryLabel.get_attribute("value") + ">"
			test_status = False
			
		if test_status == True: 
			test_passed = test_passed + 1
		else:
			test_failed = test_failed + 1
		
except:
    print "Unexpected error:", sys.exc_info()[0]
    raise
finally:
	print "--------------------------------------------"
	print "Total (" + str(test_executed)+ ") Tests Executed"
	print "Total (" + str(test_passed)+ ") Tests Passed"
	print "Total (" + str(test_failed) + ") Tests Failed"
	driver.close()
	datafile.close()