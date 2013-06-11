import junit.framework.Assert;

import org.jbehave.core.annotations.Then;
import org.jbehave.core.annotations.When;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

public class Bmi extends StoryBase {
	
	@When("I open BMI Calculator Home Page")
	public void IOpen()
	{    
		driver.get("http://dl.dropbox.com/u/55228056/bmicalculator.html");
	}
	
	@When("I enter height as '$height'")
	public void IEnterHeight(String height) 
	{         
		WebElement heightCMS = driver.findElement(By.id("heightCMS"));
		heightCMS.sendKeys(height);
	}
	
	@When("I enter weight as '$weight'")
	public void IEnterWeight(String weight) 
	{         
		WebElement weightKg = driver.findElement(By.id("weightKg"));
		weightKg.sendKeys(weight);
	}
	
	@When("I click on the Calculate button")
	public void IClickOnTheButton() 
	{         
		WebElement button = driver.findElement(By.id("Calculate"));
		button.click();
	}
	
	@Then("I should see bmi as '$bmi_exp' and category as '$bmi_category_exp'") 
	public void IShouldBmiAndCategory(String bmi_exp, String bmi_category_exp)
	{
		WebElement bmi = driver.findElement(By.id("bmi"));
		Assert.assertEquals(bmi_exp, bmi.getAttribute("value"));
		
		WebElement bmi_category = driver.findElement(By.id("bmi_category"));
		Assert.assertEquals(bmi_category_exp, bmi_category.getAttribute("value"));
		driver.quit();
 
	}
} 
