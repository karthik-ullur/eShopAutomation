Feature: Login Details

Scenario: Valid Login Details
	Given I navigate to main page
	Then Goto Login page
	When Enter login details 'demouser@microsoft.com' and 'Pass@word1'
	Then Check for successful login



Scenario: Invalid Login Details
Given I navigate to main page
Then Goto Login page
When Enter login details 'asdf@microsoft.com' and 'Asdf@1234'
Then check Invalid error message