package demo.magentocommerce.test;

import org.junit.Test;
import static org.junit.Assert.*;

import demo.magentocommerce.pages.*;

public class SearchTest {

	@Test
	public void testProductSearch()
	{
		//Create an instance of Home page 
		HomePage homePage = new HomePage();
		
		//Navigate to the Home page
		homePage.get();
		
		//Search for 'sony', the searchInStore method will return
		//SearchResults class
		SearchResults searchResult = homePage.Search().searchInStore("sony");
		
		//Verify there are 2 products available with this search
		assertEquals(2, searchResult.getProducts().size());
		assertTrue(searchResult.getProducts().contains("Sony Ericsson W810i"));
		
		//Close the Search result page
		searchResult.close();
	}
}
