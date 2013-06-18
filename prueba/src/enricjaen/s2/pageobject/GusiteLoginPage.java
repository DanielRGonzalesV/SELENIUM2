package enricjaen.s2.pageobject;

import static org.junit.Assert.assertTrue;


import org.openqa.selenium.By;

import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.LoadableComponent;

public class GusiteLoginPage extends LoadableComponent<GusiteLoginPage> {

	
	String texte = "Módulo de Autenticación";
	
	private Browser browser;
	
	private String url = "https://proves.caib.es/sacmicroback/index.do";

	
	public GusiteLoginPage(Browser browser) {
		this.browser = browser;
		init();
	}
	
	
	private void init() {
		PageFactory.initElements(browser.driver(), this);
	}
	
	@Override
	protected void load() {
		browser.open(url);
	}
	
	@Override
	protected void isLoaded()  {
		assertTrue(browser.isTextPresent(texte));
	}
	



	public ListaSitesPage login(String user, String pwd) {
		browser.driver().findElement(By.cssSelector("form[name=formUC] > input#j_username")).sendKeys(user);
		browser.driver().findElement(By.cssSelector("form[name=formUC] > input#j_password")).sendKeys(pwd);

		return new ListaSitesPage(browser);
	}
	
	
	// TODO metodos candidatos a generalizarse
	
	

	public void close() {
		browser.close();
	}
}
