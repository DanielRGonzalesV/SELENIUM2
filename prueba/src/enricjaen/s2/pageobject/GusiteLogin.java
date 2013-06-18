package enricjaen.s2.pageobject;

import static org.junit.Assert.*;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class GusiteLogin {

	Browser browser;
	private GusiteLoginPage loginPage;


	@Before
	public void setup() {
		browser = new Browser();
	}
	
	@Test
	public void login__u92770_se_logea_ok() {
		
		loginPage = new GusiteLoginPage(browser);
		loginPage.get();
		ListaSitesPage listado = loginPage.login("u92770","palma098");

		
		assertTrue(listado.isTextPresent("Llistat de microsites"));
	}

	
	@After 
	public void teardown() {
		loginPage.close();
	}
}
