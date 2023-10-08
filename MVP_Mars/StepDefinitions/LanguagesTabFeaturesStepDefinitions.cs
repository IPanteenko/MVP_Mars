using MVP_Mars.Pages;
using MVP_Mars.Utilities;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace MVP_Mars.StepDefinitions
{
    [Binding]
    [Scope(Feature="LanguagesTabFeatures")]
    public class LanguagesTabFeaturesStepDefinitions : Driver
    {
        readonly SignInPageObj signInObj;
        readonly LanguagesTabPageObj languagesTabObj;
        readonly MessagePopUpPageObj messagePopUpObj;

        public LanguagesTabFeaturesStepDefinitions (): base()
        {
            this.signInObj = new SignInPageObj(driver);
            this.languagesTabObj = new LanguagesTabPageObj(driver);
            this.messagePopUpObj = new MessagePopUpPageObj(driver);
        }

        [BeforeScenario(Order = 10)]
        public void GivenISignedInToThePortalSuccessfully()
        {
            languagesTabObj.RemoveExistingLanguages();
        }


        [When(@"I add a new language record including '([^']*)', '([^']*)'")]
        public void WhenIAddANewLanguageRecordIncluding(string languageName, string languageLevel)
        {
            languagesTabObj.CreateNewLanguage(languageName, languageLevel);
        }

        [Then(@"the new record should be created successfully with '([^']*)', '([^']*)' data")]
        public void ThenTheNewRecordShouldBeCreatedSuccessfullyWithData(string languageName, string LanguageLevel)
        {
            languagesTabObj.WaitForRecordToBeVisible();
            Assert.That(languagesTabObj.NewLanguageName.Text == languageName, "Actual name and new name don't match");
            Assert.That(languagesTabObj.NewLanguageLevel.Text == LanguageLevel, "Actual level and new level don't match");
        }

        [Given(@"I have a language record created '([^']*)', '([^']*)'")]
        public void GivenIHaveALanguageRecordCreated(string language, string level)
        {
            languagesTabObj.CreateNewLanguage(language, level);
        }

        [When(@"I add a second record with the same name '([^']*)', '([^']*)'")]
        public void WhenIAddASecondRecordWithTheSameName(string language, string level)
        {
            languagesTabObj.CreateNewLanguage(language, level);
        }


        [Then(@"Duplicated data error message should display")]
        public void ThenDuplicatedDataErrorMessageShouldDisplay()
        {
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp("Duplicated data");
            Assert.True(errorMessage.Displayed, "Error Message doesn't pop up");
        }

        [When(@"I add ""([^""]*)"" language without choosing experience level")]
        public void WhenIAddLanguageWithoutChoosingExperienceLevel(string language)
        {
            languagesTabObj.CreateNewLanguage(language, null);
        }

        [Then(@"Enter language level message should display")]
        public void ThenEnterLanguageLevelMessageShouldDisplay()
        {
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp("Please enter language and level");
            Assert.That(errorMessage.Displayed, "Error Message doesn't pop up");
        }

        [When(@"I add a new language with ""([^""]*)"" level and without name")]
        public void WhenIAddANewLanguageWithLevelAndWithoutName(string level)
        {
            languagesTabObj.CreateNewLanguage(null, level);
        }

        [Then(@"Enter Language message should display")]
        public void ThenEnterLanguageMessageShouldDisplay()
        {
            var errorMessage = messagePopUpObj.FindErrorMessagePopUp("Please enter language and level");
            Assert.That(errorMessage.Displayed, "Error Message doesn't pop up");
        }


        [Given(@"I created ""([^""]*)"" language with ""([^""]*)"" level")]
        public void GivenICreatedLanguageWithLevel(string language, string level)
        {
            languagesTabObj.CreateNewLanguage(language, level);
        }

        [Given(@"I created second ""([^""]*)"" language with ""([^""]*)"" level")]
        public void GivenICreatedSecondLanguageWithLevel(string language, string level)
        {
            languagesTabObj.CreateNewLanguage(language, level);
        }

        [Given(@"I created third ""([^""]*)"" language with ""([^""]*)"" level")]
        public void GivenICreatedThirdLanguageWithLevel(string language, string level)
        {
            languagesTabObj.CreateNewLanguage(language, level);
        }

        [When(@"I add ""([^""]*)"" language with ""([^""]*)"" level")]
        public void WhenIAddLanguageWithLevel(string language, string level)
        {
            languagesTabObj.CreateNewLanguage(language, level);
        }

        [Then(@"Add New button should disappear")]
        public void ThenAddNewButtonShouldDisappear()
        {
            languagesTabObj.WaitForAddButtonIsStale();
            Assert.That(ExpectedConditions.StalenessOf(languagesTabObj.AddNewButton)(driver), "Add new button is present");
        }

        [Given(@"I have a language record created")]
        public void GivenIHaveALanguageRecordCreated()
        {
            languagesTabObj.CreateNewLanguage("Russian", "Conversational");
        }

        [When(@"I delete the record")]
        public void WhenIDeleteTheRecord()
        {
            languagesTabObj.DeleteLanguage();
        }

        [Then(@"the record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            Assert.That(languagesTabObj.LanguageRecord==null, "Record is present");
        }

        [Given(@"I have a language record created using '([^']*)', '([^']*)'")]
        public void GivenIHaveALanguageRecordCreatedUsing(string language, string level)
        {
            languagesTabObj.CreateNewLanguage(language, level);
        }

        [When(@"I edit name of the record with '([^']*)'")]
        public void WhenIEditNameOfTheRecordWith(string newName)
        {
            languagesTabObj.EditLanguage(newName, null);
        }

        [Then(@"the record's name should change to '([^']*)'")]
        public void ThenTheRecordRussian(string newName)
        {
            languagesTabObj.WaitForRecordToBeVisible();
            Assert.That(languagesTabObj.NewLanguageName.Text == newName, "Actual name and edited name don't match");
        }

        [Given(@"I have a language record created with '([^']*)', '([^']*)'")]
        public void GivenIHaveALanguageRecordCreatedWith(string language, string level)
        {
            languagesTabObj.CreateNewLanguage(language, level);
        }

        [When(@"I change language level of existing record  with '([^']*)'")]
        public void WhenIChangeLanguageLevelOfExistingRecordWith(string newLevel)
        {
            languagesTabObj.EditLanguage(null, newLevel);
        }

        [Then(@"the record's level should change to '([^']*)'")]
        public void ThenTheRecordConversational(string newLevel)
        {
            languagesTabObj.WaitForRecordToBeVisible();
            Assert.That(languagesTabObj.NewLanguageLevel.Text== newLevel, "Actual level and new level don't match");
        }

        [Given(@"clicked on Add New button")]
        public void GivenClickedOnAddNewButton()
        {
            languagesTabObj.ClickAddNewLanguageButton();
        }

        [When(@"I click on Cancel addition button")]
        public void WhenIClickOnCancelAdditionButton()
        {
            languagesTabObj.ClickCancelAdditionButton();
        }

        [Then(@"the addition of the language record should be cancelled")]
        public void ThenTheAdditionOfTheLanguageRecordShouldBeCancelled()
        {
            Assert.That(languagesTabObj.LanguageSection==null, "Addition wasn't cancelled");
        }

        [Given(@"clicked on Edit language button")]
        public void GivenClickedOnEditLanguageButton()
        {
            languagesTabObj.ClickEditLanguageButton();
        }

        [When(@"I click on Cancel edit button")]
        public void WhenIClickOnCancelEditButton()
        {
            languagesTabObj.ClickCancelEditButton();
        }

        [Then(@"the edit of the language record should be cancelled")]
        public void ThenTheEditOfTheLanguageRecordShouldBeCancelled()
        {
            Assert.That(languagesTabObj.UpdateButton==null, "Add new button is present");
        }

        [When(@"I try to delete non-existent record")]
        public void WhenITryToDeleteNon_ExistentRecord()
        {
            languagesTabObj.FindVisibleDeleteButton();
        }

        [Then(@"no delete button is presented")]
        public void ThenNoDeleteButtonIsPresented()
        {
            Assert.That(languagesTabObj.PresentDeleteButton == null, "Delete Button is present");
        }

        [When(@"I try to edit non-existent record")]
        public void WhenITryToEditNon_ExistentRecord()
        {
            languagesTabObj.FindVisibleEditButton();
        }

        [Then(@"no edit button is presented")]
        public void ThenNoEditButtonIsPresented()
        {
            Assert.That(languagesTabObj.PresentEditButton == null, "Edit Button Is present");
        }
    }
}
