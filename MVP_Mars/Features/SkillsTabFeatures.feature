Feature: SkillsTabFeatures

As a user I would be able to show what skills I have
So that the people seeking for skills can look at what details I hold.


Scenario: add new skill using valid data
	Given I signed in to the portal successfully
    And navigated to skills tab
	When I add a new skill record
	Then the new skill record should be created successfully 

Scenario: add new skill using the name of already existing record
	Given I signed in to the portal successfully
    And navigated to skills tab
	And created a new skill record
	When I add a second skill record with the same name
	Then Error message should display

Scenario: add new skill without choosing skill level
	Given I signed in to the portal successfully
    And navigated to skills tab
	When I add a new skill without choosing experience level
	Then Error message should display

Scenario: add new skill without entering skill name
    Given I signed in to the portal successfully
	When I add a new skill without entering name
	Then Error message should display

Scenario: delete an existing skill record
    Given I signed in to the portal successfully
    And navigated to skills tab
    And I created new skill record
    When I delete the skill record 
    Then the record should be deleted successfully 

Scenario: edit name of an existing skill
    Given I signed in to the portal successfully
    And navigated to skills tab
    When I edit name of the skill record 
    Then the record's name should be updated successfully

Scenario: edit skill level of an existing skill record
    Given I signed in to the portal successfully
    And navigated to skills tab
    When  I change skill level of existing record
    Then the record's level should be updated successfully

Scenario: cancel the addition of skill new record
    Given I signed in to the portal successfully
    And navigated to skills tab
    And clicked on Add New button
    When I click on Cancel button
    Then the addition of the skill record should be cancelled

Scenario: cancel the edit of existing skill record
    Given I signed in to the portal successfully
    And navigated to skills tab
    And clicked on Edit button
    When I click on Cancel button
    Then the edit of the skill record should be cancelled

