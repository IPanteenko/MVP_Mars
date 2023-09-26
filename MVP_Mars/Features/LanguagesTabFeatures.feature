Feature: LanguagesTabFeatures

As a user I would be able to show what languages I know
So that the people seeking for languages can look at what details I hold.



Scenario: add new language using valid data
	When I add a new language record
	Then the new record should be created successfully 

Scenario: add new language using the name of already existing record
    Given I have a language record created
	When I add a second record with the same name
	Then Duplicated data error message should display

Scenario: add new language without choosing language level
	When I add a new language without choosing experience level
	Then Enter language level message should display

Scenario: add new language without entering language name
	When I add a new language without entering name
	Then Enter Language message should display

Scenario: add four languages
    And I created three language records with valid data
	When I add fourth language with valid data
	Then Add New button should disappear 

Scenario: delete an existing language record
    Given I have a language record created
    When I delete the record 
    Then the record should be deleted successfully 

Scenario: edit name of an existing language 
   Given I have a language record created
    When I edit name of the record 
    Then the record's name should be updated successfully

Scenario: edit language level of an existing language record
    Given I have a language record created
    When  I change language level of existing record 
    Then the record's level should be updated successfully

Scenario: cancel the addition of new language record
    And clicked on Add New button
    When I click on Cancel addition button
    Then the addition of the language record should be cancelled


Scenario: cancel the edit of existing language record
    Given I have a language record created
    And clicked on Edit language button
    When I click on Cancel edit button
    Then the edit of the language record should be cancelled

Scenario: try to delete non-existent record
    When I try to delete non-existent record
    Then  no delete button is presented

Scenario: try to edit non-existent record
    When I try to edit non-existent record
    Then  no edit button is presented




