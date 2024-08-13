Feature: Addlanguage

A short summary of the feature

Scenario:1. Verify User able to Add New Language
	Given User logs into Mars Portal 
	When User creates a new Language record 'English' 'Fluent'
	Then new Language 'English' and 'Fluent' should be successfully created 

	Scenario:2. Verify User able to add small case same language 
Given User logs into Mars Portal 
When User enters new Language 'english' 'Fluent' 
Then Language 'english' and 'Fluent' should be successfully created 

	Scenario:3. Verify User Gets Duplicate Error message 
Given User logs into Mars Portal 
When User enters new Language 'English' and 'Native/Bilingual' 
Then User gets Error message as Duplicate Data

	Scenario:4. Verify User able to Update New Language
	Given User logs into Mars Portal 
	When clean the existing data and add new language 'Malay' 
	Then new Language 'Malay' Updated successfully

	Scenario:5. Verify User gets error message
	Given User logs into Mars Portal
	When User creates a new Language with empty language '' and 'Basic' record 
	Then User should gets an error message 
		
	Scenario:6. Verify User enter language, level and cancel
Given User logs into Mars Portal
When User enters a new Language 'Tamil' record and click cancel
Then Entered'Tamil' language canceled and not display in below list

Scenario:7. Verify User able to delete existing languages 
	Given User logs into Mars Portal
	When User clears all languages data in the list 
	Then All language in the list deleted successfully 

	Scenario:8. Verify User able to add Mixed characters 
Given User logs into Mars Portal 
When User enter new Language 's6_d4' 'Fluent' 
Then Language 's6_d4' and 'Fluent' should successfully created 

Scenario:9. Verify User able to add multiple language 
Given User logs into Mars Portal
When User try to create multiple languages records
| Language || Level |
| French   || Basic |
| Tamil    || Native/Bilingual  |
| Hindi    || Conversational    |
| Malay    || Conversational    |

Then User created multiple records successfully 
| Language || Level |
| French   || Basic |
| Tamil    || Native/Bilingual  |
| Hindi    || Conversational    |
| Malay    || Conversational    |






	
	