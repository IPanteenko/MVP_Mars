using MVP_Mars.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MVP_Mars.Utilities
{
    public class Driver
    {
        protected readonly IWebDriver driver;
        private readonly SignInPageObj signInPageObj;


        public Driver()
        {
            driver = new ChromeDriver();
            signInPageObj = new SignInPageObj(driver);
        }

        [BeforeScenario(Order = 0)]
        public void SignInToPortal()
        {
            signInPageObj.SignTheUserIn();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

    }
}
