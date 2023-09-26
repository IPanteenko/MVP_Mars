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
    internal class SkillsTab
    {
        public IWebElement SkillRecord { get; set; }
        public IWebElement AddNewSkillSection { get; set; }

        public IWebElement UpdateButton { get; set; }

        public void RemoveExistingSkills(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table", 7);

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            string deleteButtonPath = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]";

            IReadOnlyCollection<IWebElement> deleteButton = driver.FindElements(By.XPath(deleteButtonPath));

            while (deleteButton.Count != 0)
            {
                var rowCount = driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody")).Count;
                var deleteButn = deleteButton.First();
                deleteButn.Click();
                wait.Until((driver) =>
                {
                    var updatedRowCount = driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody")).Count;
                    return updatedRowCount == rowCount - 1;
                });

                deleteButton = driver.FindElements(By.XPath(deleteButtonPath));
            }
        }

        public void CreateNewSkill(IWebDriver driver, string skillName, string skillLevel)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 5);

            IWebElement addNewSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewSkillButton.Click();

            if (skillName != null)
            {
                IWebElement addSkillTextBox = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]"));
                addSkillTextBox.SendKeys(skillName);
            }
            if (skillLevel != null)
            {
                SelectElement skillLevelDropdown = new SelectElement(driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]")));
                skillLevelDropdown.SelectByValue(skillLevel);
            }

            IWebElement addSkillButton = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/span[1]/input[1]"));
            addSkillButton.Click();
        }

        public string GetNewSkillName(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr", 10);

            IWebElement newSkillName = driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            return newSkillName.Text;
        }

        public string GetNewSkillLevel(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr", 10);

            IWebElement newSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));
            return newSkillLevel.Text;
        }

        public void DeleteSkill(IWebDriver driver)
        {
            Wait.waitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]", 5);
            IWebElement deleteSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]"));
            deleteSkillButton.Click();
        }

        public IWebElement GetSkillRecord(IWebDriver driver)
        {
            SkillRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody"));
            return SkillRecord;
        }

        public void EditSkill(IWebDriver driver, string editedSkillName, string editedSkillLevel)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 10);
            IWebElement editSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editSkillButton.Click();

            if (editedSkillName != null)
            {
                IWebElement editSkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
                editSkillTextBox.Clear();
                editSkillTextBox.SendKeys(editedSkillName);
            }

            if (editedSkillLevel != null)
            {
                SelectElement skillLevelDropdown = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select")));
                skillLevelDropdown.SelectByValue(editedSkillLevel);
            }
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span", 10);
            IWebElement updateSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateSkillButton.Click();
        }

        public int FindDeleteButtonCount(IWebDriver driver)
        {
            var countDeleteButton = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]")).Count();
            return countDeleteButton;
        }

        public int FindEditButtonCount(IWebDriver driver)
        {
            var countEditButton = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]")).Count();
            return countEditButton;
        }

        public void ClickAddNewButton(IWebDriver driver)
        {
            IWebElement addNewSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewSkillButton.Click();
        }

        public void ClickCancelAdditionButton(IWebDriver driver)
        {
            IWebElement cancelAdditionButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]"));
            cancelAdditionButton.Click();
        }

        public IWebElement GetAddNewSkillSection(IWebDriver driver)
        {
            AddNewSkillSection = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div"));
            return AddNewSkillSection;
        }

        public void ClickEditSkillButton(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span", 10);
            IWebElement editSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span"));
            editSkillButton.Click();
        }

        public IWebElement GetUpdateButton(IWebDriver driver)
        {
            Wait.waitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]", 5);
            UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            return UpdateButton;
        }

        public void ClickCancelEditButton(IWebDriver driver)
        {
            IWebElement cancelEditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
            cancelEditButton.Click();
        }
    }
}
