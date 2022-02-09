Feature: ProductsController
Validating that the Controller
processes correctly

Scenario: List products
	When we get the list of products
	Then the result should be 5

Scenario: Get Product By Id
	Given that I get the product with Id 02540696-8994-42c7-b703-e630223883ab
	Then the product description must be Teclado