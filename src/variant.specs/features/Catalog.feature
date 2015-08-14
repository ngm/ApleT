@catalog
Feature: Catalog

Scenario: Catalog shows list of available items
	Given Joe has logged in
    When Joe navigates to the catalog page
	And foo
	Then Joe should see the list of available items
