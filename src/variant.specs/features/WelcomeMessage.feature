Feature: Welcome Message
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@welcome_bournemouth
Scenario: see welcome message
	Given I have asked to run the application
    When I run the application
	Then I should see the welcome message "Hello BOURNEMOUTH!"

@welcome_plymouth
Scenario: see welcome message plymouth
	Given I have asked to run the application
    When I run the application
	Then I should see the welcome message "Hello PLYMOUTH!"

@welcome_uwe
Scenario: see welcome message uwe
	Given I have asked to run the application
    When I run the application
	Then I should see the welcome message "Hello UWE!"
