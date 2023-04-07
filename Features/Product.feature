Feature: Order Product


Scenario: Order a Product
	Given navigate to main page 'https://localhost:44315/'
	When Enter Login details 'demouser@microsoft.com' and 'Pass@word1'
	Then Filter the Products 'Other' and 'All' 
	Then select the product and add it to cart
	Then Go to checkout page and select the quantity and checkout
	And make a payment
	Then check for order confirmation message
	And ordering multiple products
