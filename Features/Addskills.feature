Feature: Addskills

A short summary of the feature

@tag1
Scenario:1. Verify User able to Add New Skill
	Given User logging in Mars portal 
	And User navigates to Skills tab
	When User creates a new Skill record 'C#' and 'Expert'
	Then new Skill 'C#' should be successfully created 

	Scenario:2. Verify User Gets Already exists error message 
	Given User logging in Mars portal 
	And User navigates to Skills tab
	When User creates a new Skill record 'Manualtesting' and 'Expert' 
	Then User should get Already exists error 

	Scenario:3. Verify User Gets Duplicate Error message 
	Given User logging in Mars portal 
	And User navigates to Skills tab
	When User creates new Skill record 'Manualtesting' and 'Intermediate'
	Then User should get Duplicated data error 

	Scenario:4. Verify numbers and special characters accepting 
	Given User logging in Mars portal 
	And User navigates to Skills tab
	When User creates new Skill record '35_qre' 'Beginner'
	Then New skill '35_qre' and level added in below list 

	Scenario:5. Verify User able to edit and update existing skill 
	Given User logging in Mars portal 
	And User navigates to Skills tab
	When User clears already skill and edits with new skill 'Mainframe' 'Intermediate'
	Then New skill 'Mainframe' Updated successfully 

	Scenario:6. Verify by giving empty skill
	Given User logging in Mars portal 
	And User navigates to Skills tab
	When User try to give '' skill and 'Beginner'
	Then Gets an error Please enter skill and experience level

	Scenario:7. Verify by giving empty level
	Given User logging in Mars portal 
	And User navigates to Skills tab
	When User tries to give 'ManualTesting' skill and ''
	Then Gets error Please enter skill and experience level

	Scenario:8. Verify whether given skills get delete
	Given User logging in Mars portal 
	And User navigates to Skills tab
	When User tries to delete the skills
	Then User successfully deletes all the skill

	Scenario:9. Verify whether given skills get cancel
	Given User logging in Mars portal 
	And User navigates to Skills tab 
	When User tries to cancel skill 'Manualtesting' and 'Expert' by not adding
	Then User successfully cancels the skill 'Manualtesting'

	Scenario:10. Verify User able to give multiple skill and experience
	Given User logging in Mars portal
	And Clears all the existing skills
	When User try to create multiple skill records
| Skill         |  | Level        |
| Communication |  | Intermediate |
| Manualtesting |  | Expert       |
| Mainframe     |  | Beginner     |
| Dance         |  | Intermediate |

	Then User created the multiple skill successfully 
| Skill         |  | Level        |
|Communication  |  | Intermediate |
| Manualtesting |  | Expert       |
| Mainframe     |  | Basic        |
| Dance         |  | Intermediate |

