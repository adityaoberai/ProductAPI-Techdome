# ProductAPI - Techdome

## [Assignment: ProductAPI with Tests](Description.pdf)

### Prerequisites:

* Need run Migrations for the 3 Database Contexts

### Insurance API

POST `/insurance`

* Request Body Example:

	```json
	{
		"ids": [1,1,2,3]
	}
	```
	
	*Note: The list represents Product IDs from a Shopping Cart*
	
* Response Example

	```json
	{
		"insurance": 2500
	}
	```