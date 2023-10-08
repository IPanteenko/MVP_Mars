Feature: LanguagesTabFeatures

As a user I would be able to show what languages I know
So that the people seeking for languages can look at what details I hold.



Scenario Outline: add new language using valid data
	When I add a new language record including '<Language>', '<Level>'
	Then the new record should be created successfully with '<Language>', '<Level>' data
    
    Examples: 
    | Language | Level          |
    | Russian  | Conversational |
    | French   | Basic          |

Scenario Outline: add new language using the name of already existing record
    Given I have a language record created '<Language>', '<Level>'
	When I add a second record with the same name '<SameLanguage>', '<AnotherLevel>'
	Then Duplicated data error message should display

    Examples: 
    | Language | Level  | SameLanguage | AnotherLevel   |
    | Russian  | Fluent | Russian      | Basic          |
    | French   | Basic  | French       | Conversational |

Scenario: add new language without choosing language level
	When I add "Russian" language without choosing experience level
	Then Enter language level message should display

Scenario: add new language without entering language name
	When I add a new language with "Basic" level and without name
	Then Enter Language message should display

Scenario: add four languages
    Given I created "Mongol" language with "Fluent" level
    And I created second "Ukrainian" language with "Conversational" level
    And I created third "Arabic" language with "Native/Bilingual" level
	When I add "Portuguese" language with "Basic" level 
	Then Add New button should disappear 

Scenario: delete an existing language record
    Given I have a language record created
    When I delete the record 
    Then the record should be deleted successfully 

Scenario Outline: edit name of an existing language 
   Given I have a language record created using '<Language>', '<Level>'
    When I edit name of the record with '<NewName>'
    Then the record's name should change to '<NewName>'

    Examples: 
    | Language | Level  | NewName |
    | Italian  | Basic  | Russian |
    | German   | Fluent | French  |

Scenario Outline: edit language level of an existing language record
    Given I have a language record created with '<Language>', '<Level>'
    When  I change language level of existing record  with '<NewLevel>'
    Then the record's level should change to '<NewLevel>'

     Examples: 
    | Language | Level  | NewLevel         |
    | Chinese  | Basic  | Native/Bilingual |
    | German   | Fluent | Conversational   | 

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




