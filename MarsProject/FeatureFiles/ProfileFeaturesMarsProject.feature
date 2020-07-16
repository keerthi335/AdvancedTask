Feature: ProfileFeaturesMarsProject
	As a SkillSwap member
	I want to change the password of profile if needed

@ProfileFeatures
Scenario Outline: ChangePassword
	Given I logged in the system and click on Profile DropDown box
	And Click on ChangePassword Button
	When I provide the value for fields '<OldPassword>', '<NewPassword>' and '<ConfirmPassword>' 
	Then the password should change successfully by returning to home page
	Examples: 
	| OldPassword | NewPassword | ConfirmPassword |
	| pass123     | test123     | test123         |

