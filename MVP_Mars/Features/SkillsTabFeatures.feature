Feature: SkillsTabFeatures

As a user I would be able to show what skills I have
So that the people seeking for skills can look at what details I hold.


Scenario: add new skill using valid data
	When I add a new skill record
	Then the new skill record should be created successfully 

Scenario: add new skill using the name of already existing record
    Given I have a skill record created
	When I add a second skill record with the same name
	Then Error message should pop up

Scenario: add new skill without choosing skill level
	When I add a new skill without choosing experience level
	Then Enter skill level message should display

Scenario: add new skill without entering skill name
	When I add a new skill without entering name
	Then Enter skill name message should display

Scenario: delete an existing skill record
    Given I have a skill record created
    When I delete the skill record 
    Then the skill record should be deleted successfully 

Scenario: delete non-existant skill record
    When I try to delete non-existent skill record 
    Then no delete button is present

Scenario: edit name of an existing skill
    Given I have a skill record created
    When I edit name of the skill record 
    Then the skill record's name should be updated successfully

Scenario: edit skill level of an existing skill record
    Given I have a skill record created
    When  I change skill level of an existing record
    Then the skill record's level should be updated successfully

Scenario: edite non-existant skill record
    When I try to edit non-existent skill record 
    Then no edit button is present

Scenario: cancel the addition of skill new record
    And clicked on Add New button in Skills Tab
    When I click on Cancel Addition button
    Then the addition of the skill record should be cancelled

Scenario: cancel the edit of existing skill record
    Given I have a skill record created
    And clicked on Edit button in Skills Tab
    When I click on Cancel Edit button
    Then the edit of the skill record should be cancelled

