# ProductAPI - Techdome

## Assignment: ProductAPI with Tests

### Prerequisites:

* Need run Migrations for the 3 Database Contexts

```powershell
Add-Migration InitialCreate -Context ProductContext
Add-Migration InitialCreate -Context ProductTypeContext
Add-Migration InitialCreate -Context ProblemDetailsContext
Update-Database -Context ProductContext
Update-Database -Context ProductTypeContext
Update-Database -Context ProblemDetailsContext
```

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
