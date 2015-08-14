Feature: ChangeRequest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@change_request
Scenario: Send a change request email to placements team
	Given I have asked to run the application
	And I have asked to send a change request email
	When I run the application
	Then a change request email should be sent
