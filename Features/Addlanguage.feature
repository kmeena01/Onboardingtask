Feature: Addlanguage

A short summary of the feature

Scenario:1. Verify User able to Add New Language
	Given User logs into Mars Portal 
	When User creates a new Language record 'English' 
	Then new Language 'English' should be successfully created 

	Scenario:2. Verify User Gets Duplicate Error message 
Given User logs into Mars Portal 
When User enters new Language 'English' 
Then User gets Error message as Duplicate Data

	Scenario:3. Verify User able to Update New Language
	Given User logs into Mars Portal 
	When clean the existing data and add new language 'Malay' 
	Then new Language 'Malay' Updated successfully

	Scenario:4. Verify User gets error message
	Given User logs into Mars Portal
	When User creates a new Language with empty language '' record 
	Then User should gets an error message 
		
	Scenario:5. Verify User enter language, level and cancel
Given User logs into Mars Portal
When User enters a new Language 'Tamil' record and click cancel
Then Entered'Tamil' language canceled and not display in below list

Scenario:6. Verify User able to delete existing languages 
	Given User logs into Mars Portal
	When User clears all languages data in the list 
	Then All language in the list deleted successfully 

Scenario:7. Verify User able to add multiple language 
Given User logs into Mars Portal
When User try to create multiple language records
| Language |
| French   |
| Tamil    |
| Hindi    |
| Malay    |

Then User created multiple records successfully 
| Language |
| French   |
| Tamil    |
| Hindi    |
| Malay    |






	
	