using MVP_Mars.Utilities;
using OpenQA.Selenium;

namespace MVP_Mars.Pages
{
    public class MessagePopUpPageObj
    {
        private IWebDriver driver { get; set; }

        public MessagePopUpPageObj(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindErrorMessagePopUp(string messageText)
        {
            IWebElement errorPopUp = driver.FindElement(By.XPath("/html/body/div[contains(@class,\"ns-type-error\")]/div[text()=\"" + messageText + "\"]"));
            return errorPopUp;
        }
        public IWebElement FindSuccessMassagePopUP(string messageText)
        {
            IWebElement successPopUp = driver.FindElement(By.XPath("/html/body/div[contains(@class,\"ns-type-success\")]/div[text()=\"" + messageText + "\"]"));
            return successPopUp;
        }

        public void WaitForSkillErrorMessage()
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[contains(@class,\"ns-type-error\")]/div[text()=\"Duplicated data\"]", 5);
        }
    }
}