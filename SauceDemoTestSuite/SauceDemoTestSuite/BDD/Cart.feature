Feature: Cart
	As a customer
	I would save items I'd like to buy
	In order to purchase multiple items at a time.

@Cart
Scenario: Add multiple items to cart
	Given I am on the inventory page
	When I click Add To Cart for <numItemsAdded> items
	Then The icon shows <numItemsAdded> items have been added to the cart

	Examples:
	| numItemsAdded |
	| 1             |
	| 2             |
	| 3             |
	| 4             |
	| 5             |
	| 6             |

@Cart
Scenario: Remove items from cart
	Given I am on the inventory page
	And I click Add To Cart for <numItemsAdded> items
	When I click Remove for <numItemsRemoved> items
	Then The icon shows <numRemainingItems> items have been added to the cart

	Examples:
	| numItemsAdded | numItemsRemoved | numRemainingItems |
	| 1             | 0               | 1                 |
	| 2             | 1               | 1                 |
	| 3             | 0               | 3                 |
	| 4             | 2               | 2                 |
	| 5             | 1               | 4                 |
	| 6             | 3               | 3                 |