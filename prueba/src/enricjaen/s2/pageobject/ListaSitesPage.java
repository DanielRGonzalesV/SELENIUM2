package enricjaen.s2.pageobject;

import org.openqa.selenium.support.ui.LoadableComponent;

public class ListaSitesPage extends LoadableComponent<ListaSitesPage> {
	
	private Browser browser;
	
	
	public Browser getBrowser() {
		return browser;
	}


	public ListaSitesPage(Browser browser) {
		this.browser = browser;
	}

	@Override
	protected void isLoaded() throws Error {
		browser.isTextPresent("Llistat de microsites");
		
	}
	
	@Override
	protected void load() {
	
		
	}
	
    protected boolean isTextPresent(String text) {
		return browser.driver().getPageSource().contains(text);
	}

	

}
