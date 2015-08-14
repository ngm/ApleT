@welcome_B
Feature: Welcome Message

Scenario: see welcome message
	Given Joe has logged in
	And Joe navigates to the welcome page
	Then Joe should see the welcome message "Welcome To Customer B's Store!"
