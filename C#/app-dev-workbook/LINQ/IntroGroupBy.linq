<Query Kind="Program">
  <Connection>
    <ID>5a535651-fcaa-4f27-91a2-f616deceea0d</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>WestWind</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

/*
	This is an introduction to GroupBy
	USE WESTWIND DATABASE
	

*/




void Main()
{

	// 	Get the number of customers by region If key is null, set to unknown, Display order count
	Customers
		.GroupBy(c => c.Address.Region)
		.Select(group => new {
			Region = group.Key == null ? "Unknown" : group.Key,
			OrderCount = group.Sum(o => o.Orders.Count)
		}).Dump("Demo");
		

		
		// Show the orderID and customer company name for each year in each country
		
		Orders
			.GroupBy(o => new {o.Customer.Address.Country, o.OrderDate.Value.Year})
			.Select(group => new {
				Country = group.Key.Country,
				Year = group.Key.Year,
				Orders = group.Select(g => new {OrderId = g.OrderID, Customer = g.Customer.CompanyName})
			}).Dump("key with two values");
			
		
		// for each city we want to know the orders by category 
		// for each city we want to know the number of orders per category
		
		OrderDetails
			.GroupBy(od => new {od.Order.Customer.Address.City, od.Product.Category.CategoryName})
			.Select(group => new {
				City = group.Key.City,
				Category = group.Key.CategoryName,
				OrderCount = group.Select(g => g.Order.OrderID).Count()
			}).OrderBy(group => group.City).ThenBy(group => group.Category).Dump("Double Key demo two");

}

