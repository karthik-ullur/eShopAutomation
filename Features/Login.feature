Feature: Login Details

@valid
Scenario: Valid Login Details
	Given I navigate to URL
	When Goto Login page
	Then Enter login details 'demouser@microsoft.com' and 'Pass@word1'


@Invalid
Scenario: Invalid Login Details
Given I navigate to URL
When Goto Login page
Then Enter login details 'asdf@microsoft.com' and 'Asdf@1234'