Feature: Inventory
	As a customer
	I would like to see details of the items for sale
	In order to make an informed purchase

@Inventory
Scenario: Click on an item link
	Given I am on the inventory page
	When When I click the link for item <n>
	Then I am taken to to the page for item <n>

	Examples:
	| n |
	| 1 |
	| 2 |
	| 3 |
	| 4 |
	| 5 |
	| 6 |