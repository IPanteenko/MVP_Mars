using MVP_Mars.Pages;
using MVP_Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace MVP_Mars.StepDefinitions
{
    [Binding]
    public class LanguagesTabFeaturesStepDefinitions : Driver
    {
        readonly SignIn signInObj = new();
        readonly LanguagesTab languagesTabObj = new();
        readonly MessagePopUp messagePopUpObj = new();


        [BeforeScenario]
        public void GivenISignedInToThePortalSuccessfully()
        {
            signInObj.SignInActions(driver);
            languagesTabObj.RemoveExistingLanguages(driver);
        }

        [BeforeScenario("RequiresCreatingLanguage")]
        public void CreateNewLanguageSetUp()
        {
            languagesTabObj.CreateNewLanguage(driver, "Russian", "Conversational");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

        [When(@"I add a new language record")]
        public void WhenIAddANewLanguageRecord()
        {
            languagesTabObj.CreateNewLanguage(driver, "English", "Fluent");
        }

        [Then(@"the new record should be created successfully")]
        public void ThenTheNewRecordShouldBeCreatedSuccessfully()
        {
            string newLanguageName = languagesTabObj.GetNewLanguageName(driver);
            Assert.That(newLanguageName == "English", "Actual name and new name don't match");

            string newLanguageLevel = languagesTabObj.GetNewLanguageLevel(driver);
            Assert.That(newLanguageLevel == "Fluent", "Actual level and new level don't match");
        }

        [When(@"I add a second record with the same name")]
        public void WhenIAddASecondRecordWithTheSameName()
        {
            languagesTabObj.CreateNewLanguage(driver, "Russian", "Fluent");
        }

        [Then(@"Duplicated data error message should display")]
        public void ThenDuplicatedDataErrorMessageShouldDisplay()
        {
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp(driver, "Duplicated data");
            Assert.True(errorMessage.Displayed, "Error Message doesn't pop up");
        }

        [When(@"I add a new language without choosing experience level")]
        public void WhenIAddANewLanguageWithoutChoosingExperienceLevel()
        {
            languagesTabObj.CreateNewLanguage(driver, "English", "");
        }

        [Then(@"Enter language level message should display")]
        public void ThenEnterLanguageLevelMessageShouldDisplay()
        {
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp(driver, "Please enter language and level");
            Assert.That(errorMessage.Displayed, "Error Message doesn't pop up");
        }

        [When(@"I add a new language without entering name")]
        public void WhenIAddANewLanguageWithoutEnteringName()
        {
            languagesTabObj.CreateNewLanguage(driver, "", "Fluent");
        }

        [Then(@"Enter Language message should display")]
        public void ThenEnterLanguageMessageShouldDisplay()
        {
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp(driver, "Please enter language and level");
            Assert.That(errorMessage.Displayed, "Error Message doesn't pop up");
        }

        [Given(@"I created three language records with valid data")]
        public void GivenICreatedThreeLanguageRecordsWithValidData()
        {
            languagesTabObj.CreateNewLanguage(driver, "English", "Basic");
            languagesTabObj.CreateNewLanguage(driver, "Russian", "Conversational");
            languagesTabObj.CreateNewLanguage(driver, "Chinese", "Fluent");
        }

        [When(@"I add fourth language with valid data")]
        public void WhenIAddFourthLanguageWithValidData()
        {
            languagesTabObj.GetAddNewButton(driver);
            languagesTabObj.CreateNewLanguage(driver, "Mandarin", "Native/Bilingual");
        }

        [Then(@"Add New button should disappear")]
        public void ThenAddNewButtonShouldDisappear()
        {
            Wait.waitIsVisible(driver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr", 10);
            Assert.That(ExpectedConditions.StalenessOf(languagesTabObj.AddNewButton)(driver), "Add new button is present");
        }


        [When(@"I delete the record")]
        public void WhenIDeleteTheRecord()
        {
            languagesTabObj.DeleteLanguage(driver);
        }

        [Then(@"the record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            Assert.That(ExpectedConditions.StalenessOf(languagesTabObj.LanguageRecord)(driver), "Record is present");
        }


        [When(@"I edit name of the record")]
        public void WhenIEditNameOfTheRecord()
        {
            languagesTabObj.EditLanguage(driver, "Italian", "Conversational");
        }

        [Then(@"the record's name should be updated successfully")]
        public void ThenTheRecordsNameShouldBeUpdatedSuccessfully()
        {
            string editedLanguageName = languagesTabObj.GetNewLanguageName(driver);
            Assert.That(editedLanguageName == "Italian", "Actual name and edited name don't match");
        }

        [When(@"I change language level of existing record")]
        public void WhenIChangeLanguageLevelOfExistingRecord()
        {
            languagesTabObj.EditLanguage(driver, "", "Fluent");
        }

        [Then(@"the record's level should be updated successfully")]
        public void ThenTheRecordsLevelShouldBeUpdatedSuccessfully()
        {
            string newLanguageLevel = languagesTabObj.GetNewLanguageLevel(driver);
            Assert.That(newLanguageLevel == "Fluent", "Actual level and new level don't match");
        }

        [Given(@"clicked on Add New button")]
        public void GivenClickedOnAddNewButton()
        {
            languagesTabObj.ClickAddNewLanguageButton(driver);
        }

        [When(@"I click on Cancel addition button")]
        public void WhenIClickOnCancelAdditionButton()
        {
            languagesTabObj.GetAddLanguageSection(driver);
            languagesTabObj.ClickCancelAdditionButton(driver);
        }

        [Then(@"the addition of the language record should be cancelled")]
        public void ThenTheAdditionOfTheLanguageRecordShouldBeCancelled()
        {
            Assert.That(ExpectedConditions.StalenessOf(languagesTabObj.AddLanguageSection)(driver), "Add new button is present");
        }

        [Given(@"clicked on Edit language button")]
        public void GivenClickedOnEditLanguageButton()
        {
            languagesTabObj.ClickEditLanguageButton(driver);
        }

        [When(@"I click on Cancel edit button")]
        public void WhenIClickOnCancelEditButton()
        {
            languagesTabObj.FindUpdateButton(driver);
            languagesTabObj.ClickCancelEditButton(driver);
        }

        [Then(@"the edit of the language record should be cancelled")]
        public void ThenTheEditOfTheLanguageRecordShouldBeCancelled()
        {
            Assert.That(ExpectedConditions.StalenessOf(languagesTabObj.UpdateButton)(driver), "Add new button is present");
        }

        [When(@"I try to delete non-existent record")]
        public void WhenITryToDeleteNon_ExistentRecord()
        {
            languagesTabObj.FindDeleteButtonCount(driver);
        }

        [Then(@"no delete button is presented")]
        public void ThenNoDeleteButtonIsPresented()
        {
            var deleteButtonCount = languagesTabObj.FindDeleteButtonCount(driver);
            Assert.That(deleteButtonCount == 0, "Delete Button is present");
        }

        [When(@"I try to edit non-existent record")]
        public void WhenITryToEditNon_ExistentRecord()
        {
            languagesTabObj.FindEditButtonCount(driver);
        }

        [Then(@"no edit button is presented")]
        public void ThenNoEditButtonIsPresented()
        {
            var editButtonCount = languagesTabObj.FindEditButtonCount(driver);
            Assert.That(editButtonCount == 0, "Edit Button Is present");
        }


    }
}
