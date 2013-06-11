import java.util.List;

import org.jbehave.core.configuration.Configuration;
import org.jbehave.core.configuration.MostUsefulConfiguration;
import org.jbehave.core.io.LoadFromClasspath;
import org.jbehave.core.junit.JUnitStory;
import org.jbehave.core.reporters.Format;
import org.jbehave.core.reporters.StoryReporterBuilder;
import org.jbehave.core.steps.InstanceStepsFactory;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

public abstract class StoryBase extends JUnitStory { 
	
	protected final static WebDriver driver = new FirefoxDriver();
	
	@Override    
	public Configuration configuration() {
		return new MostUsefulConfiguration()
		.useStoryLoader(new LoadFromClasspath(this.getClass().getClassLoader()))
		.useStoryReporterBuilder(
					new StoryReporterBuilder()
					.withDefaultFormats()
					.withFormats(Format.HTML, Format.CONSOLE)
					.withRelativeDirectory("jbehave-report")
					);
		}
	
	@Override    
	public List candidateSteps() {
		return new InstanceStepsFactory(configuration(), this).createCandidateSteps(); 
		
	} 
} 
