# ArgusMedia.Rstaurant
Rstaurant service
Run service before run tests.

Available Endpoints:
1. Get: GetAllProductsAsync 
- Returns a list of all existing products.
Response format:
[
  { "id": "...", "name": "...", "price": ... }
]

2. Post: MakeOrderAsync 
- Creates one or more new orders based on the provided list of OrderCreateDto
Input:
[
  { "productId": "...", "clientId": "...", "createdDate": "..." }
]
Returns:
[
  { "id": "...", "clientId": "...", "productId": "..." }
]

3. Delete: DeleteOrderAsync 
- Deletes an order by orderId.

4. Post: BillAsync 
- Calculates the total bill based on current orders.
Parameters:
Have parameter isSplitBill:
- isSplitBill = true: Returns individual bills for each client.
- isSplitBill = false and clientId = null: Returns a general bill for all clients.

Required:
ClientId  is the key identifier in the system and all orders are linked to it.

How to set up Service:
1. Build the solution using Visual Studio or dotnet build.
2. Ensure the application port is free (e.g., check for port conflicts).
3. Initialize the database:
3.1 Open Package Manager Console in Visual Studio.
3.2 Run the following commands:
dotnet ef migrations add InitialCreate --project {set path}
dotnet ef database update --project {set path}
Path into ArgusMedia.Restaurant.csproj file for example:
 C:\Users\semen\source\repos\ArgusMedia.Restaurant\ArgusMedia.Restaurant\ArgusMedia.Restaurant