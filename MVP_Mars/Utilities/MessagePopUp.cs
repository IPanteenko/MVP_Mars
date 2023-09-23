using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Mars.Utilities
{
    public class MessagePopUp
    {
        public IWebElement FindErrorMessagePopUp(IWebDriver driver, string messageText)
        {
            IWebElement errorPopUp = driver.FindElement(By.XPath("/html/body/div[contains(@class,\"ns-type-error\")]/div[text()=\""+ messageText+"\"]"));
            return errorPopUp;  
        }
        public IWebElement FindSuccessMassagePopUP(IWebDriver driver, string messageText)
        {
            IWebElement successPopUp = driver.FindElement(By.XPath("/html/body/div[contains(@class,\"ns-type-success\")]/div[text()=\""+messageText+"\"]"));
            return successPopUp;
        }
        
    }
}