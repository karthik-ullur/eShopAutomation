Feature: Order Product

@product
Scenario: Order a Product
	Given navigate to main page and Login 'demouser@microsoft.com' and 'Pass@word1'
	When Filter the Products 'Other' and 'All' , select the product and add it to cart
	Then Go to checkout page and select the quantity and checkout
	And make a payment
	Then check for order confirmation message
	And ordering multiple products
