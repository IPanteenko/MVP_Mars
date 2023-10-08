Feature: SkillsTabFeatures

As a user I would be able to show what skills I have
So that the people seeking for skills can look at what details I hold.


Scenario Outline: add new skill using valid data
	When I add a new skill record with '<SkillName>', '<Experience>'
	Then the new skill record with '<SkillName>', '<Experience>' should be created

Examples:
	| SkillName       | Experience   |
	| Public Speaking | Intermediate |
	| Typing          | Expert       |


Scenario Outline: add new skill using the name of already existing record
	Given I have a skill record created with '<SkillName>', '<Experience>'
	When I add a second skill record with the same name '<SameName>', '<OtherExperience>'
	Then Error message should pop up

Examples:
	| SkillName       | Experience | SameName        | OtherExperience |
	| Meal Prep       | Beginner   | Meal Prep       | Expert          |
	| Time management | Expert     | Time management | Intermediate    |

Scenario: add new skill without choosing skill level
	When I add a new skill "Programming" without choosing experience level
	Then Enter skill level message should display


Scenario: add new skill without entering skill name
	When I add a new skill with "Beginner" level and without entering name
	Then Enter skill name message should display

Scenario: delete an existing skill record
	Given I have a skill record created
	When I delete the skill record
	Then the skill record should be deleted successfully

Scenario: delete non-existant skill record
	When I try to delete non-existent skill record
	Then no delete button is present

Scenario Outline: edit name of an existing skill
	Given I have a '<SkillName>' created with '<Experience>'
	When I edit name of the skill record with '<NewName>'
	Then the skill name should be updated to '<NewName>'

Examples:
	| SkillName       | Experience   | NewName           |
	| Meal Prep       | Intermediate | Cross stitch      |
	| Time management | Beginner     | Critical thinking |

Scenario Outline: edit skill level of an existing skill record
	Given I have a skill record created with '<SkillName>' and '<Experience>'
	When I change skill level to '<NewLevel>'
	Then the skill level should change to '<NewLevel>'

Examples:
	| SkillName       | Experience | NewLevel     |
	| Meal Prep       | Beginner   | Expert       |
	| Time management | Expert     | Intermediate |

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

