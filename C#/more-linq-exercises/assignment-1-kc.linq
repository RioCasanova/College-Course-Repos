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

// Query 1

OrderLists
	.Select(x => new
	{
		Product = x.Product.Description,
		TimesPurchased = OrderLists.Where(p => p.Product.ProductID == x.ProductID).Count()
	})
	.Distinct()
	.OrderByDescending(x => x.TimesPurchased)
	.ThenBy(x => x.Product)
	.Dump();
	
// Teachers way of doing #1 (cleaner/easier)

Products
	.Select(x => new
	{
		Product = x.Description,
		TimesPurchased = x.OrderLists.Count()
	})
	.OrderByDescending(x => x.TimesPurchased)
	.ThenBy(x => x.Product)
	.Dump();

// Query 2

Stores
	.OrderBy(x => x.Location)
	.Select(x => new
	{
		Location = x.Location,
		Clients = Orders
		.Where(c => x.StoreID == c.StoreID)
		.Select(c => new
		{
			Address = c.Customer.Address,
			City = c.Customer.City,
			Province = c.Customer.Province
		})
		.Distinct()
	}).Dump();

// Teachers way of doing #2

//Stores
//	.OrderBy(x => x.Location)
//	.Select(x => new
//	{
//		Location = x.Location,
//		Clients = Orders
//		.Where(c => x.StoreID == c.StoreID)
//		.Select(c => new
//		{
//			Address = c.Customer.Address,
//			City = c.Customer.City,
//			Province = c.Customer.Province
//		})
//		.Distinct()
//		.OrderBy (e => e.Address)        // he added order by address here
//	}).Dump();


// Query 3

Stores
	.OrderBy(x => x.City)
	.ThenBy(x => x.Location)
	.Select(x => new
	{
		City = x.City,
		Location = x.Location,
		Sales = Orders
		.Where(s => s.OrderDate.Month == 12 && x.StoreID == s.Store.StoreID)
		.GroupBy(s => s.OrderDate)
		.Select(r => new
		{
			Date = r.Key,
			NumberOfOrders = r.Count(),
			ProductSales = r.Sum(e => e.SubTotal),
			GST = r.Sum(r => r.GST)
		})
		.Distinct()
	}).Dump();

// Query 4

Categories
	.OrderBy(x => x.Description)
	.Select(x => new
	{
		Category = x.Description,
		OrderProducts = OrderLists
		.Where(ol => ol.OrderID == 33 && x.CategoryID == ol.Product.CategoryID)
		.Select(ol => new
		{
			Product = ol.Product.Description,
			Price = ol.Product.Price,
			PickedQTY = ol.QtyPicked,
			Discount = ol.Discount,
			Subtotal = (ol.Price - ol.Discount) * Convert.ToDecimal(ol.QtyPicked),
			Tax = ol.Product.Taxable == true ? (ol.Price - ol.Discount) * Convert.ToDecimal(0.05) : 0,
			ExtendedPrice = ol.Product.Taxable == true ? (ol.Price - ol.Discount) * Convert.ToDecimal(ol.QtyPicked) + (ol.Price - ol.Discount) * Convert.ToDecimal(0.05) : (ol.Price - ol.Discount) * Convert.ToDecimal(ol.QtyPicked)
		})
	}).Dump();

// Query 5

Orders
	.OrderBy(x => x.Store.Location)
	.Select(x => new
	{
		Location = x.Store.Location,
		Orders = x.Store.Orders.Count(),
		AvgSize = OrderLists.Where(s => x.StoreID == s.Order.StoreID).Select(s => s.ProductID).Count() / x.Store.Orders.Count(),
		AvgRevenue = Orders.Where(s => x.StoreID == s.StoreID).Select(s => s.SubTotal).Sum() / x.Store.Orders.Count()
	})
	.Distinct()
	.Dump();
	
// Teachers way of doing #5 (cleaner/easier)

//Orders
//	.GroupBy(x => x.Store.Location)
//	.OrderBy(x => x.Key)
//	.Select(results => new
//	{
//		Location = results.Key,
//		Orders = results.Count(),
//		AvgSize = results.Average(x => x.OrderLists.Count()),
//		AvgRevenue = results.Average(x => x.SubTotal)
//	})
//	.Dump();

// Query 6

Orders
	.Where(x => x.CustomerID == 1)
	.Select(x => new
	{
		Customers = x.Customer.LastName + ", " + x.Customer.FirstName,
		OrdersCount = Orders.Where(s => s.CustomerID == x.CustomerID).Count(),
		Items = OrderLists
		.Where(e => e.Order.CustomerID == x.CustomerID)
		.GroupBy(e => e.ProductID)
		.Select(e => e.FirstOrDefault())
		.Select(ol => new
		{
			Description = ol.Product.Description,
			TimesBought = OrderLists.Where(s => s.Order.CustomerID == x.CustomerID && s.ProductID == ol.ProductID).Count()
		})
		.OrderByDescending(q => q.TimesBought)
		.ThenBy(q => q.Description)
		}).GroupBy(x => x.Customers)
		.Select(x => x.FirstOrDefault())
		.Dump();
		
// Teachers way of doing #6 (easier/cleaner)

Customers
	.Where(c => c.CustomerID == 1)
	.Select(c => new
	{
		Customer = c.LastName + ", " + c.FirstName,
		OrderCount = Orders.Count(x => x.CustomerID == c.CustomerID),
		Items = OrderLists
			.Where(x => x.Order.CustomerID == c.CustomerID)
			.GroupBy(x => x.Product)
			.Select( i => new
			{
				Description = i.Key.Description,
				ProductID = i.Key.ProductID,
				UnitSize = i.Key.UnitSize,
				TimesBought = i.Count()
			})
			.OrderByDescending(x => x.TimesBought)
			.ThenBy(x => x.Description)
	}).Dump();