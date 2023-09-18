using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Mars.Pages
{
    public class SignIn
    {
        public void SignInActions(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:5000/");
            IWebElement signInButton = driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));
            signInButton.Click();
            IWebElement emailTextBox = driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]"));
            emailTextBox.SendKeys("panteenko@gmail.com");
            IWebElement passwordTextBox = driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/input[1]"));
            passwordTextBox.SendKeys("Z5t3RKM\"4K2yj~c");
            IWebElement loginButton = driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
            loginButton.Click();
        }
    }
}
