using MVP_Mars.Pages;
using MVP_Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace MVP_Mars.StepDefinitions
{
    [Binding]
    [Scope(Feature="SkillsTabFeatures")]
    public class SkillsTabFeaturesStepDefinitions: Driver
    {
        readonly SignIn signInObj = new();
        readonly SkillsTab skillsTabObj = new();
        readonly MessagePopUp messagePopUpObj = new();

        [BeforeScenario]
        public void GivenISignedInToThePortalSuccessfully()
        {
            signInObj.SignInActions(driver);
            signInObj.NavigateToSkillTab(driver);
            skillsTabObj.RemoveExistingSkills(driver);
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Given(@"I have a skill record created")]
        public void GivenIHaveASkillRecordCreated()
        {
            skillsTabObj.CreateNewSkill(driver, "Cross Stitch", "Beginner");
        }

        [When(@"I add a new skill record")]
        public void WhenIAddANewSkillRecord()
        {
            skillsTabObj.CreateNewSkill(driver, "Cross Stitch", "Beginner");
        }

        [Then(@"the new skill record should be created successfully")]
        public void ThenTheNewSkillRecordShouldBeCreatedSuccessfully()
        {
            string newSkillName = skillsTabObj.GetNewSkillName(driver);
            Assert.That(newSkillName == "Cross Stitch", "Actual name and created name don't match");
            
            string newSkillLevel = skillsTabObj.GetNewSkillLevel(driver);
            Assert.That(newSkillLevel == "Beginner", "Actual level and created level don't match");
        }


        [When(@"I add a second skill record with the same name")]
        public void WhenIAddASecondSkillRecordWithTheSameName()
        {
            skillsTabObj.CreateNewSkill(driver, "Cross Stitch", "Beginner");
        }

        [Then(@"Error message should pop up")]
        public void ThenErrorMessageShouldPopUp()
        {
            Wait.waitIsVisible(driver, "XPath", "/html/body/div[contains(@class,\"ns-type-error\")]/div[text()=\"This skill is already exist in your skill list.\"]", 5);
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp(driver, "This skill is already exist in your skill list.");
            Assert.True(errorMessage.Displayed, "Error Message doesn't pop up");
        }

        [When(@"I add a new skill without choosing experience level")]
        public void WhenIAddANewSkillWithoutChoosingExperienceLevel()
        {
            skillsTabObj.CreateNewSkill(driver, "Public Speaking", null);
        }

        [Then(@"Enter skill level message should display")]
        public void ThenEnterSkillLevelMessageShouldDisplay()
        {
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp(driver, "Please enter skill and experience level");
            Assert.That(errorMessage.Displayed, "Error Message doesn't pop up");
        }

        [When(@"I add a new skill without entering name")]
        public void WhenIAddANewSkillWithoutEnteringName()
        {
            skillsTabObj.CreateNewSkill(driver, null, "Intermediate");
        }

        [Then(@"Enter skill name message should display")]
        public void ThenEnterSkillNameMessageShouldDisplay()
        {
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp(driver, "Please enter skill and experience level");
            Assert.That(errorMessage.Displayed, "Error Message doesn't pop up");
        }


        [When(@"I delete the skill record")]
        public void WhenIDeleteTheSkillRecord()
        {
            skillsTabObj.DeleteSkill(driver);
        }

        [Then(@"the skill record should be deleted successfully")]
        public void ThenTheSkillRecordShouldBeDeletedSuccessfully()
        {
            Assert.That(ExpectedConditions.StalenessOf(skillsTabObj.SkillRecord)(driver), "The record is present");
        }

        [When(@"I try to delete non-existent skill record")]
        public void WhenITryToDeleteNon_ExistentSkillRecord()
        {
            skillsTabObj.FindDeleteButtonCount(driver);
        }

        [Then(@"no delete button is present")]
        public void ThenNoDeleteButtonIsPresent()
        {
            var deleteButtonCount = skillsTabObj.FindDeleteButtonCount(driver);
            Assert.That(deleteButtonCount == 0, "Delete Button is present");
        }

        [When(@"I edit name of the skill record")]
        public void WhenIEditNameOfTheSkillRecord()
        {
            skillsTabObj.EditSkill(driver, "Public Speaking", null);
        }

        [Then(@"the skill record's name should be updated successfully")]
        public void ThenTheSkillRecordsNameShouldBeUpdatedSuccessfully()
        {
            string editedSkillName = skillsTabObj.GetNewSkillName(driver);
            Assert.That(editedSkillName == "Public Speaking", "Actual name and edited name don't match");
        }

        [When(@"I change skill level of an existing record")]
        public void WhenIChangeSkillLevelOfAnExistingRecord()
        {
            skillsTabObj.EditSkill(driver, null, "Intermediate");
        }

        [Then(@"the skill record's level should be updated successfully")]
        public void ThenTheSkillRecordsLevelShouldBeUpdatedSuccessfully()
        {
            string editedSkillLevel = skillsTabObj.GetNewSkillLevel(driver);
            Assert.That(editedSkillLevel == "Intermediate", "Actual level and edited level don't match");
        }

        [When(@"I try to edit non-existent skill record")]
        public void WhenITryToEditNon_ExistentSkillRecord()
        {
           skillsTabObj.FindEditButtonCount(driver);
        }

        [Then(@"no edit button is present")]
        public void ThenNoEditButtonIsPresent()
        {
            var deleteEditCount = skillsTabObj.FindEditButtonCount(driver);
            Assert.That(deleteEditCount == 0, "Edit Button is present");
        }

        [Given(@"clicked on Add New button in Skills Tab")]
        public void GivenClickedOnAddNewButtonInSkillsTab()
        {
            skillsTabObj.ClickAddNewButton(driver);
         
        }

        [When(@"I click on Cancel Addition button")]
        public void WhenIClickOnCancelAdditionButton()
        {
            skillsTabObj.ClickCancelAdditionButton(driver);
        }

        [Then(@"the addition of the skill record should be cancelled")]
        public void ThenTheAdditionOfTheSkillRecordShouldBeCancelled()
        {
            Assert.That(ExpectedConditions.StalenessOf(skillsTabObj.AddNewSkillSection)(driver), "The addition of the skill record wasn't canceled");
        }

        [Given(@"clicked on Edit button in Skills Tab")]
        public void GivenClickedOnEditButtonInSkillsTab()
        {
            skillsTabObj.ClickEditSkillButton(driver);
        }

        [When(@"I click on Cancel Edit button")]
        public void WhenIClickOnCancelEditButton()
        {
            skillsTabObj.ClickCancelEditButton(driver);
        }

            [Then(@"the edit of the skill record should be cancelled")]
        public void ThenTheEditOfTheSkillRecordShouldBeCancelled()
        {
            Assert.That(ExpectedConditions.StalenessOf(skillsTabObj.UpdateButton)(driver), "Update button is present");
        }
    }
}
