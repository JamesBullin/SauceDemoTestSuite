Feature: SignIn
	As a user,
	I'd like to be able to securely sign in to my account
	In order to make purchases

@SignIn
Scenario: CorrectUsernameCorrectPassword
	Given I am on the Sign In page
	And I have entered the username <username>
	And I have entered the password <password>
	When I click the Log In button
	Then I will be taken to the Inventory page

	Examples:
	| username                | password     |
	| standard_user           | secret_sauce |
	| problem_user            | secret_sauce |
	| performance_glitch_user | secret_sauce |

@SignIn
Scenario: BlockedAccountCorrectPassword
	Given I am on the Sign In page
	And I have entered the username <username>
	And I have entered the password <password>
	When I click the Log In button
	Then I will see an error message containing "Sorry, this user has been locked out."

	Examples:
	| username                | password     |
	| locked_out_user         | secret_sauce |

@SignIn
Scenario: CorrectEmailIncorrectPassword
	Given I am on the Sign In page
	And I have entered the username <username>
	And I have entered the password <password>
	When I click the Log In button
	Then I will see an error message containing "Username and password do not match any user in this service"

	Examples:
	| username                | password      |
	| standard_user           | wrongpassword |
	| locked_out_user         | wrongpassword |
	| problem_user            | wrongpassword |
	| performance_glitch_user | wrongpassword |

@SignIn
Scenario: NoUsername
	Given I am on the Sign In page
	And I have entered the password <password>
	When I click the Log In button
	Then I will see an error message containing "Username is required"

	Examples:
	| username              | password    |
	|                       | anypassword |

@SignIn
Scenario: IncorrectUsername
	Given I am on the Sign In page
	And I have entered the username <username>
	And I have entered the password <password>
	When I click the Log In button
	Then I will see an error message containing "Username and password do not match any user in this service"

	Examples:
	| username              | password    |
	| unrecognised_username | anypassword |
	| unknown_username      | anypassword |