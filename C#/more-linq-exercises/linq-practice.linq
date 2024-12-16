<Query Kind="Statements">
  <Connection>
    <ID>4ea71c88-b5d8-449e-aec8-0e2fe1ed482d</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>GroceryList</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

// Query One
//Products 
//	.Select(p => new 
//	{
//		product = p.Description,
//		TimesPurchased = p.OrderLists.Count()
//	})
//	.OrderByDescending(p => p.TimesPurchased)
//	.ThenBy(p => p.product)
//	.Dump();
	
	
// Query Two

//Stores
//	.OrderBy(x => x.Location)
//	.Select(x => new 
//	{
//		Location = x.Location,
//		Clients = Orders 
//			.Where(c => c.StoreID == x.StoreID)
//			.Select(c => new 
//			{
//				address = c.Customer.Address,
//				city = c.Customer.City,
//				province = c.Customer.Province
//			}).Distinct()
//	}).Dump();




// Query 3 




