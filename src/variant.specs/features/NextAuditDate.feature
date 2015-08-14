Feature: NextAuditDate
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@next_audit_date
Scenario: Set the next audit date
	Given I have asked to run the application
	And I ask to set the next audit date
    When I run the application
	Then the next audit date should be set
