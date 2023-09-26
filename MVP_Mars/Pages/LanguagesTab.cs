using MVP_Mars.Utilities;
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
        public IWebElement AddLanguageSection { get; set; }
        public IWebElement UpdateButton { get; set; }
        public IWebElement AddNewButton { get; set; }
        public IWebElement LanguageRecord { get; set; }

        public void RemoveExistingLanguages(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 7);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            string deleteButtonPath = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]";
            IReadOnlyCollection<IWebElement> deleteButton = driver.FindElements(By.XPath(deleteButtonPath));

            while (deleteButton.Count != 0)
            {
                var rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody")).Count;
                var deleteButn = deleteButton.First();
                deleteButn.Click();
                wait.Until((driver) =>
                {
                    var updatedRowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody")).Count;
                    return updatedRowCount == rowCount - 1;
                });

                deleteButton = driver.FindElements(By.XPath(deleteButtonPath));
            }
        }

        public void CreateNewLanguage(IWebDriver driver, string languageName, string languageLevel)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 7);

            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            if (languageName != null)
            {
                //Wait.waitIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]", 10);
                IWebElement addLanguageTextBox = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]"));
                addLanguageTextBox.SendKeys(languageName);
            }

            if (languageLevel != null)
            {
                //Wait.waitIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]", 10);
                SelectElement languageLevelDropdown = new SelectElement(driver.FindElement(By.XPath("//*[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]")));
                languageLevelDropdown.SelectByValue(languageLevel);
            }

            IWebElement addButton = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[3]/input[1]"));
            addButton.Click();

        }

        public string GetNewLanguageName(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]", 5);

            IWebElement newLanguageName = driver.FindElement(By.XPath("//tbody/tr/td[1]"));
            return newLanguageName.Text;
        }

        public string GetNewLanguageLevel(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]", 5);

            IWebElement newLanguageLevel = driver.FindElement(By.XPath("//tbody/tr/td[2]"));
            return newLanguageLevel.Text;
        }

        public void DeleteLanguage(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr", 7);

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]"));
            deleteButton.Click();
        }

        public void EditLanguage(IWebDriver driver, string editedLanguageName, string editedLanguageLevel)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr", 7);

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
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

        public void ClickAddNewLanguageButton(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 7);

            IWebElement addNewButton = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[3]/div[1]"));
            addNewButton.Click();
        }


        public void ClickCancelAdditionButton(IWebDriver driver)
        {
            IWebElement cancelAdditionButton = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[3]/input[2]"));
            cancelAdditionButton.Click();
        }

        public void ClickEditLanguageButton(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 7);

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editButton.Click();
        }

        public void ClickCancelEditButton(IWebDriver driver)
        {
            IWebElement cancelEditButton = driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/span[1]/input[2]"));
            cancelEditButton.Click();
        }

        public IWebElement GetAddLanguageSection(IWebDriver driver)
        {
            AddLanguageSection = driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div"));
            return AddLanguageSection;
        }

        public IWebElement FindUpdateButton(IWebDriver driver)
        {

            UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            return UpdateButton;
        }

        public IWebElement GetAddNewButton(IWebDriver driver)
        {
            AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            return AddNewButton;
        }

        public IWebElement GetLanguageRecord(IWebDriver driver)
        {
            LanguageRecord = driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));
            return LanguageRecord;
        }

        public int FindDeleteButtonCount(IWebDriver driver)
        {
            var countDeleteButton = driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i")).Count();
            return countDeleteButton;
        }

        public int FindEditButtonCount(IWebDriver driver)
        {
            var countEditButton = driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")).Count();
            return countEditButton;
        }
    }
}
