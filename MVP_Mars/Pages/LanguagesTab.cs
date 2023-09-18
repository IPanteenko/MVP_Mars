using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Mars.Pages
{
    public class LanguagesTab
    {
        public void CreateNewLanguage(IWebDriver driver, string languageName, string languageLevel)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[3]/div[1]"));
            addNewButton.Click();

            if (languageName != null)
            {
                IWebElement addLanguageTextBox = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]"));
                addLanguageTextBox.SendKeys(languageName);
            }

            if (languageLevel != null)
            {
                SelectElement languageLevelDropdown = new SelectElement(driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]")));
                languageLevelDropdown.SelectByValue(languageLevel);
            }

            IWebElement addButton = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[3]/input[1]"));
            addButton.Click();

        }
        public void DeleteLanguage(IWebDriver driver)
        {
            IWebElement deleteButton = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[2]/i[1]"));
            deleteButton.Click();
        }

        public void EditLanguage(IWebDriver driver, string editedLanguageName, string editedLanguageLevel)
        {
            IWebElement editButton = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[1]/i[1]"));
            editButton.Click();

            if (editedLanguageName != null)
            {
                IWebElement languageTextBox = driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]"));
                languageTextBox.Clear();
                languageTextBox.SendKeys(editedLanguageName);
            }

            if (editedLanguageLevel != null)
            {
                SelectElement languageLevelDropdown = new SelectElement(driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[2]/select[1]")));
                languageLevelDropdown.SelectByValue(editedLanguageLevel);
            }
            IWebElement updateButton = driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/span[1]/input[1]"));
            updateButton.Click();
        }

        public void CancelAddition (IWebDriver driver)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[3]/div[1]"));
            addNewButton.Click();

            IWebElement cancelAdditionButton = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[3]/input[2]"));
            cancelAdditionButton.Click();
        }

        public void CancelEdit (IWebDriver driver)
        {
            IWebElement editButton = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[1]/i[1]"));
            editButton.Click();

            IWebElement cancelEditButton = driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/span[1]/input[2]"));
            cancelEditButton.Click();
        }
    }
}
