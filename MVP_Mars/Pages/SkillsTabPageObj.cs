using MVP_Mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MVP_Mars.Pages
{
    internal class SkillsTabPageObj
    {
        public IWebElement PresentDeleteButton { get; set; }
        public IWebElement PresentEditButton { get; set; }
        private readonly IWebDriver driver;


        private const string NewSkillNameXPath = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[1]";
        private const string NewSkillLevelXPath = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]";

        public IWebElement SKillTabButton => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        public IWebElement AddNewSkillButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).FirstOrDefault();
        public IWebElement AddSkillTextBox => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]"));
        public IWebElement AddSkillButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/span[1]/input[1]"));
        public IWebElement DeleteSkillButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]")).FirstOrDefault();
        public IWebElement EditSkillTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        public IWebElement EditSkillButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]")).FirstOrDefault();
        public IWebElement UpdateSkillButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")).FirstOrDefault();
        public IWebElement CancelAdditionButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]"));
        public IWebElement CancelEditButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
        public IWebElement NewSkillName => driver.FindElement(By.XPath(NewSkillNameXPath));
        public IWebElement NewSkillLevel => driver.FindElement(By.XPath(NewSkillLevelXPath));
        public IWebElement AddNewSkillSection => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div")).FirstOrDefault();
        public IWebElement SkillRecord => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody")).FirstOrDefault();
        public IWebElement SkillLevelDropDown => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]"));
        public IWebElement EditSkillLevelDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));

        public SkillsTabPageObj(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToSkillTab()
        {
            Wait.WaitIsVisible(driver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]", 10);
            SKillTabButton.Click();
        }

        public void RemoveExistingSkills()
        {
            Wait.WaitIsVisible(driver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table", 7);

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            while (DeleteSkillButton != null)
            {
                var rowCount = driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody")).Count;
                DeleteSkillButton.Click();
                wait.Until((driver) =>
                {
                    var updatedRowCount = driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody")).Count;
                    return updatedRowCount == rowCount - 1;
                });
            }
        }

        public void CreateNewSkill(string skillName, string skillLevel)
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 5);

            AddNewSkillButton.Click();

            if (skillName != null)
            {
                AddSkillTextBox.SendKeys(skillName);
            }
            if (skillLevel != null)
            {
                SelectElement skillLevelDropdown = new SelectElement(SkillLevelDropDown);
                skillLevelDropdown.SelectByValue(skillLevel);
            }

            AddSkillButton.Click();
        }

        public void DeleteSkill()
        {
            Wait.WaitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]", 5);
            DeleteSkillButton.Click();
        }


        public void EditSkill( string editedSkillName, string editedSkillLevel)
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 10);
            EditSkillButton.Click();

            if (editedSkillName != null)
            {
                EditSkillTextBox.Clear();
                EditSkillTextBox.SendKeys(editedSkillName);
            }

            if (editedSkillLevel != null)
            {
                SelectElement skillLevelDropdown = new SelectElement(EditSkillLevelDropDown);
                skillLevelDropdown.SelectByValue(editedSkillLevel);
            }
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span", 10);
            UpdateSkillButton.Click();
        }
       
        public void ClickAddNewButton()
        {
            AddNewSkillButton.Click();
        }

        public void ClickCancelAdditionButton()
        {
            CancelAdditionButton.Click();
        }

        public void ClickEditSkillButton()
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span", 10);
            EditSkillButton.Click();
        }

        public void ClickCancelEditButton()
        {
            CancelEditButton.Click();
        }

        public void FindDeleteButton()
        {
            PresentDeleteButton = DeleteSkillButton;
        }

        public void FindEditButton()
        { 
            PresentEditButton = EditSkillButton;
        }

        public void WaitForSkillNameToBeVisible()
        {
            Wait.WaitIsVisible(driver, "XPath", NewSkillNameXPath, 10);
        }

        public void WaitForSkillLevelToBeVisible()
        {
            Wait.WaitIsVisible(driver,"XPath", NewSkillLevelXPath, 10);
        }

        public void WaitSkillRecordIsStale()
        {
            Wait.WaitElementIsStail(driver, SkillRecord);
        }

        public void WaitUpdateButtonStale()
        {
            Wait.WaitElementIsStail(driver, UpdateSkillButton);
        }
    }
}
