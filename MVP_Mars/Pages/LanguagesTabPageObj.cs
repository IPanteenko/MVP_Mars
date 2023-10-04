using MVP_Mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MVP_Mars.Pages
{
    public class LanguagesTabPageObj
    {
        private readonly IWebDriver driver;


        public IWebElement PresentDeleteButton { get; set; }
        public IWebElement PresentEditButton { get; set; }
        public IWebElement PresentAddLanguageSection { get; set; }
        public const string LanguageRecordXPath = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr";
        public IWebElement AddNewButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).FirstOrDefault();
        public IWebElement AddLanguageTextBox => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]"));
        public IWebElement AddButton => driver.FindElements(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[3]/input[1]")).FirstOrDefault();
        public IWebElement NewLanguageName => driver.FindElement(By.XPath("//tbody/tr/td[1]"));
        public IWebElement NewLanguageLevel => driver.FindElement(By.XPath("//tbody/tr/td[2]"));
        public IWebElement DeleteButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]")).FirstOrDefault();
        public IWebElement EditButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]")).FirstOrDefault();
        public IWebElement EditLanguageTextBox => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]"));
        public IWebElement UpdateButton => driver.FindElements(By.XPath("//tbody/tr[1]/td[1]/div[1]/span[1]/input[1]")).FirstOrDefault();
        public IWebElement CancelAdditionButton => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[3]/input[2]"));
        public IWebElement CancelEditButton => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/span[1]/input[2]"));
        public IWebElement LanguageSection => driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div")).FirstOrDefault();
        public IWebElement LanguageRecord => driver.FindElements(By.XPath(LanguageRecordXPath)).FirstOrDefault();
        public IWebElement LanguageLevelDropDown => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]"));
        public IWebElement EditLanguageDropDown => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[2]/select[1]"));

        public LanguagesTabPageObj(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void RemoveExistingLanguages()
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 7);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            while (DeleteButton != null)
            {
                var rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody")).Count;
                DeleteButton.Click();
                wait.Until((driver) =>
                {
                    var updatedRowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody")).Count;
                    return updatedRowCount == rowCount - 1;
                });
            }
        }

        public void CreateNewLanguage(string languageName, string languageLevel)
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 7);
            AddNewButton.Click();

            if (languageName != null)
            {
                AddLanguageTextBox.SendKeys(languageName);
            }

            if (languageLevel != null)
            {
                SelectElement languageLevelDropdown = new SelectElement(LanguageLevelDropDown);
                languageLevelDropdown.SelectByValue(languageLevel);
            }

            AddButton.Click();
        }


        public void DeleteLanguage()
        {
            Wait.WaitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]", 10);
            DeleteButton.Click();
        }

        public void EditLanguage(string editedLanguageName, string editedLanguageLevel)
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr", 7);

            EditButton.Click();

            if (editedLanguageName != null)
            {
                EditLanguageTextBox.Clear();
                EditLanguageTextBox.SendKeys(editedLanguageName);
            }

            if (editedLanguageLevel != null)
            {
                SelectElement languageLevelDropdown = new SelectElement(EditLanguageDropDown);
                languageLevelDropdown.SelectByValue(editedLanguageLevel);
            }
            UpdateButton.Click();
        }

        public void ClickAddNewLanguageButton()
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 7);
            AddNewButton.Click();
        }

        public void ClickCancelAdditionButton()
        {
            CancelAdditionButton.Click();
        }

        public void ClickEditLanguageButton()
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 7);
            EditButton.Click();
        }

        public void ClickCancelEditButton()
        {
            CancelEditButton.Click();
        }


        public void FindVisibleDeleteButton()
        {
            PresentDeleteButton = DeleteButton;
        }

        public void FindVisibleEditButton()
        {
            PresentEditButton = EditButton;
        }

        public void WaitForRecordToBeVisible()
        {
            Wait.WaitIsVisible(driver, "XPath", LanguageRecordXPath, 10);
        }

        public void WaitForAddButtonIsStale()
        {
            Wait.WaitElementIsStail(driver, AddButton);
        }
    
    }
}
