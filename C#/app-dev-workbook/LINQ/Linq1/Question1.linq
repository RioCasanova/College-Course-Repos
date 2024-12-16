<Query Kind="Program">
  <Connection>
    <ID>5e0624ec-2110-4075-aa7f-655a5991a866</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>WorkSchedule</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

/*
	Use WorkSchedule Database
	Use C# Program
	
	List all employees. Order by "Last Name"
	
	firstName
	LastName
	Phone
	Available
*/


void Main()
{
	Employees 
		.OrderBy(e => e.LastName)
		.Select(e => new {
		Name = e.FirstName + " " + e.LastName,
		Phone = e.HomePhone,
		Available = e.Active ? "Yes" : "No"
		}).Dump("Question 1");
}

