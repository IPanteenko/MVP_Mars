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
        public void CreateNewSkill(IWebDriver driver, string skillName, string skillLevel)
        {
            IWebElement addNewSkillButton = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[3]/div[1]"));
            addNewSkillButton.Click();

            if (skillLevel != null)
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
            addNewSkillButton.Click();
        }
       
        public void DeleteSkill(IWebDriver driver) 
        { 
        IWebElement deleteSkillButton = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[2]/i[1]"));
        deleteSkillButton.Click();
        }

        public void EditSkill(IWebDriver driver, string editedSkillName, string editedSkillLevel) 
        {
            IWebElement editSkillButton = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[1]/i[1]"));
            editSkillButton.Click();

            if (editedSkillLevel != null) 
            {
                IWebElement editSkillTextBox = driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]"));
                editSkillTextBox.Clear();
                editSkillTextBox.SendKeys(editedSkillName); 

            }

            if (editedSkillLevel == null)
            {
                SelectElement skillLevelDropdown = new SelectElement(driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[2]/select[1]")));
                skillLevelDropdown.SelectByValue(editedSkillLevel);
            }
            
        }
    }
}
