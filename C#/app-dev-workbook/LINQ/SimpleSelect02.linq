<Query Kind="Program">
  <Connection>
    <ID>919025ec-0868-4811-95df-2fc40857b2b2</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>IQSchool</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

void Main()
{
//	1.Select the average Mark from all the Marks in the
//registration table
Registrations 
	.Average(x => x.Mark)
	.Dump("Students Average Mark");
	
//2.Select how many students are there in the Student Table
Students
	.Count()
	.Dump("Number of students in the Student table");
	
//3.Select the average payment amount for payment type 5
Payments
	.Where(p => p.PaymentTypeID == 5)
	.Average(p => p.Amount)
	.Dump("Average Payment Amount for payment type 5");
	
//4.Select the highest payment amount
Payments
	.Max(p => p.Amount)
	.Dump("The highest payment amount");
	
//5.Select the lowest payment amount
Payments
	.Min(p => p.Amount)
	.Dump("The lowest payment amount");

//6.Select the total of all the payments that have been made
Payments
	.Sum(p => p.Amount)
	.Dump("The sum payment amount");
//7.How many different payment types does the school accept ?
Payments 
	.Select(p => p.PaymentType.PaymentTypeDescription).Distinct().Count()
	.Dump("Number of Payment Types");
//8.How many students are in club 'CSS' ?
Activities
	.Where(s => s.ClubId == "CSS")
	.Select(s => s.StudentID).Count()
	.Dump("Students in CSS club");






}

// You can define other methods, fields, classes and namespaces here