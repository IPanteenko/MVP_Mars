using MVP_Mars.Pages;
using MVP_Mars.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MVP_Mars.StepDefinitions
{
    [Binding]
    [Scope(Feature="SkillsTabFeatures")]
    public class SkillsTabFeaturesStepDefinitions: Driver
    {
        readonly SignInPageObj signInObj;
        readonly SkillsTabPageObj skillsTabObj;
        readonly MessagePopUpPageObj messagePopUpObj;

        public SkillsTabFeaturesStepDefinitions(): base() 
        { 
            this.signInObj = new SignInPageObj(driver);
            this.skillsTabObj = new SkillsTabPageObj(driver);
            this.messagePopUpObj = new MessagePopUpPageObj(driver);
        }

        [BeforeScenario(Order =10)]
        public void GivenISignedInToThePortalSuccessfully()
        {
            skillsTabObj.NavigateToSkillTab();
            skillsTabObj.RemoveExistingSkills();
        }


        [Given(@"I have a skill record created")]
        public void GivenIHaveASkillRecordCreated()
        {
            skillsTabObj.CreateNewSkill("Cross Stitch", "Beginner");
        }


        [When(@"I add a new skill record with '([^']*)', '([^']*)'")]
        public void WhenIAddANewSkillRecordWith(string name, string level)
        {
            skillsTabObj.CreateNewSkill(name, level);
        }

        [Then(@"the new skill record with '([^']*)', '([^']*)' should be created")]
        public void ThenTheNewSkillRecordWithShouldBeCreated(string name, string level)
        {
            skillsTabObj.WaitForSkillNameToBeVisible();
            Assert.That(skillsTabObj.NewSkillName.Text == name, "Actual name and created name don't match");
            Assert.That(skillsTabObj.NewSkillLevel.Text == level, "Actual level and created level don't match");
        }


        [Given(@"I have a skill record created with '([^']*)', '([^']*)'")]
        public void GivenIHaveASkillRecordCreatedWith(string name, string level)
        {
            skillsTabObj.CreateNewSkill(name, level);
        }

        [When(@"I add a second skill record with the same name '([^']*)', '([^']*)'")]
        public void WhenIAddASecondSkillRecordWithTheSameName(string name, string level)
        {
            skillsTabObj.CreateNewSkill(name, level);
        }

        [Then(@"Error message should pop up")]
        public void ThenErrorMessageShouldPopUp()
        {
            messagePopUpObj.WaitForSkillErrorMessage();
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp("Duplicated data");
            Assert.True(errorMessage.Displayed, "Error Message doesn't pop up");
        }

        [When(@"I add a new skill ""([^""]*)"" without choosing experience level")]
        public void WhenIAddANewSkillWithoutChoosingExperienceLevel(string skill)
        {
            skillsTabObj.CreateNewSkill(skill, null);
        }

        [Then(@"Enter skill level message should display")]
        public void ThenEnterSkillLevelMessageShouldDisplay()
        {
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp("Please enter skill and experience level");
            Assert.That(errorMessage.Displayed, "Error Message doesn't pop up");
        }

        [When(@"I add a new skill with ""([^""]*)"" level and without entering name")]
        public void WhenIAddANewSkillWithLevelAndWithoutEnteringName(string level)
        {
            skillsTabObj.CreateNewSkill(null, level);
        }

        [Then(@"Enter skill name message should display")]
        public void ThenEnterSkillNameMessageShouldDisplay()
        {
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp("Please enter skill and experience level");
            Assert.That(errorMessage.Displayed, "Error Message doesn't pop up");
        }

        [When(@"I delete the skill record")]
        public void WhenIDeleteTheSkillRecord()
        {
            skillsTabObj.DeleteSkill();
        }

        [Then(@"the skill record should be deleted successfully")]
        public void ThenTheSkillRecordShouldBeDeletedSuccessfully()
        {
            skillsTabObj.WaitSkillRecordIsStale();
            Assert.That(skillsTabObj.SkillRecord==null, "The record is present");
        }

        [When(@"I try to delete non-existent skill record")]
        public void WhenITryToDeleteNon_ExistentSkillRecord()
        {
            skillsTabObj.FindDeleteButton();
        }

        [Then(@"no delete button is present")]
        public void ThenNoDeleteButtonIsPresent()
        {
            Assert.That(skillsTabObj.PresentDeleteButton == null, "Delete Button is present");
        }

        [Given(@"I have a '([^']*)' created with '([^']*)'")]
        public void GivenIHaveACreatedWith(string skill, string level)
        {
            skillsTabObj.CreateNewSkill(skill, level);
        }

        [When(@"I edit name of the skill record with '([^']*)'")]
        public void WhenIEditNameOfTheSkillRecordWith(string skill)
        {
            skillsTabObj.EditSkill(skill, null);
        }

        [Then(@"the skill name should be updated to '([^']*)'")]
        public void ThenTheSkillNameShouldBeUpdatedTo(string skill)
        {
            skillsTabObj.WaitUpdateButtonStale();
            Assert.That(skillsTabObj.NewSkillName.Text == skill , "Actual name and edited name don't match");
        }

        [Given(@"I have a skill record created with '([^']*)' and '([^']*)'")]
        public void GivenIHaveASkillRecordCreatedWithAnd(string skill, string level)
        {
            skillsTabObj.CreateNewSkill(skill, level);
        }

        [When(@"I change skill level to '([^']*)'")]
        public void WhenIChangeSkillLevelTo(string level)
        {
            skillsTabObj.EditSkill(null, level);
        }

        [Then(@"the skill level should change to '([^']*)'")]
        public void ThenTheSkillLevelShouldChangeTo(string level)
        {
            skillsTabObj.WaitForSkillLevelToBeVisible();
            Assert.That(skillsTabObj.NewSkillLevel.Text == level , "Actual level and edited level don't match");
        }

        [When(@"I try to edit non-existent skill record")]
        public void WhenITryToEditNon_ExistentSkillRecord()
        {
            skillsTabObj.FindEditButton();
        }

        [Then(@"no edit button is present")]
        public void ThenNoEditButtonIsPresent()
        {
            Assert.That(skillsTabObj.PresentEditButton == null, "Edit Button is present");
        }

        [Given(@"clicked on Add New button in Skills Tab")]
        public void GivenClickedOnAddNewButtonInSkillsTab()
        {
            skillsTabObj.ClickAddNewButton();
        }

        [When(@"I click on Cancel Addition button")]
        public void WhenIClickOnCancelAdditionButton()
        {
            skillsTabObj.ClickCancelAdditionButton();
        }

        [Then(@"the addition of the skill record should be cancelled")]
        public void ThenTheAdditionOfTheSkillRecordShouldBeCancelled()
        {
            Assert.That(skillsTabObj.AddNewSkillSection ==null, "The addition of the skill record wasn't canceled");
        }

        [Given(@"clicked on Edit button in Skills Tab")]
        public void GivenClickedOnEditButtonInSkillsTab()
        {
            skillsTabObj.ClickEditSkillButton();
        }

        [When(@"I click on Cancel Edit button")]
        public void WhenIClickOnCancelEditButton()
        {
            skillsTabObj.ClickCancelEditButton();
        }

            [Then(@"the edit of the skill record should be cancelled")]
        public void ThenTheEditOfTheSkillRecordShouldBeCancelled()
        {
            Assert.That(skillsTabObj.UpdateSkillButton==null, "Update button is present");
        }
    }
}
