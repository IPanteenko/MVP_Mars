Feature: LanguagesTabFeatures

As a user I would be able to show what languages I know
So that the people seeking for languages can look at what details I hold.


Scenario: add new language using valid data
	Given I signed in to the portal successfully
	When I add a new language record
	Then the new record should be created successfully 

Scenario: add new language using the name of already existing record
	Given I signed in to the portal successfully
	And created a new language record
	When I add a second record with the same name
	Then Error message should display

Scenario: add new language without choosing language level
	Given I signed in to the portal successfully
	When I add a new language without choosing experience level
	Then Error message should display

Scenario: add new language without entering language name
    Given I signed in to the portal successfully
	When I add a new language without entering name
	Then Error message should display

Scenario: add four languages
	Given I signed in to the portal successfully
    And I created three language records with valid data
	When I add fourth language with valid data
	Then Add New button should disappear 

Scenario: delete an existing language record
    Given I signed in to the portal successfully
    And I created new language record
    When I delete the record 
    Then the record should be deleted successfully 

Scenario: edit name of an existing language 
    Given I signed in to the portal successfully
    When I edit name of the record 
    Then the record's name should be updated successfully

Scenario: edit language level of an existing language record
    Given I signed in to the portal successfully
    When  I change language level of existing record 
    Then the record's level should be updated successfully
