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

	//	1.Select the average mark for each offeringCode. Display the OfferingCode and the average mark.
	Offerings
		.Select(x => new
		{
			OfferingCode = x.OfferingCode,
			AvgMark = x.Registrations.Average(r => r.Mark)
		})
		.Dump("Average Mark per Offering Code");

	//2.How many payments where made for each payment type.Display the Payment typeID and
	//the count
	PaymentTypes
		.Select(x => new
		{
			PaymentTypes = x.PaymentTypeDescription,
			NumPayments = x.Payments.Count()

		}).Dump("Number of Payments per payment type");

	//3.Select the average Mark for each studentID. Display the StudentId and their average mark
	Students
		.Select(x => new
		{
			StudentID = x.StudentID,
			AvgMark = x.Registrations.Average(m => m.Mark)
		}).Dump("Average mark per student ID");

//4.Select the same data as question 3 but only show the studentID's and averages that are > 80
	Students
		.Select(x => new
		{
			StudentID = x.StudentID,
			AvgMark = x.Registrations.Average(m => m.Mark)
		}).Where(x => x.AvgMark > 80)
		.Dump("Average mark per student ID above 80");		
		
//5.How many students are from each city? Display the City and the count.
Students
	
	.GroupBy(x => x.City)
	.Select(group => new {
		City = group.Key,
		StudentCount = group.Count()
	})
	.Dump("Where students are from");

	//6.Which cities have 2 or more students from them? (HINT, remember that fields that we use in the where or having do not need to be selected.....)
	Students
		
		.GroupBy(x => x.City)
		.Select(group => new
		{
			City = group.Key,
			StudentCount = group.Count()
		}).Where(group => group.StudentCount >= 2)
		.Dump("Cities with 2 or more students from them");

	//7.what is the highest, lowest and average payment amount for each payment type ?
	//Payments
	//	
	//	.GroupBy(p =>p.PaymentType)
	//	.Select(group => new {
	//		PaymentID = group.Key.PaymentTypeID,
	//		PaymentDescription = group.Key,
	//		AvgPaymentAmount = group.Key.Payments.Average(p => p.Amount),
	//		MaxPaymentAmount = group.Key.Payments.Max(p => p.Amount),
	//		MinPaymentAmount = group.Key.Payments.Min(p => p.Amount)	
	//	}).Dump("Payment Information");

	Payments
		
		.GroupBy(p =>p.PaymentType.PaymentTypeDescription)
		.Select(group => new {
			PaymentTypeDescription = group.Key,
			MaxAmount = group.Max(max => max.Amount),
			MinAmount = group.Min(min => min.Amount),
			AvgAmount = group.Average(avg => avg.Amount)
		}).Dump("Payment Information");

//8.How many students are there in each club ? Show the clubID and the count
// Group is a collection of objects or rows
	Activities 
		.GroupBy(x => x.Club.ClubName)
		.Select(group => new {
			ClubName = group.Key,
			NumStudents = group.Count()
		}).Dump();

//9.Which clubs have 3 or more students in them ?
	Clubs
		.Where(x => x.Activities.Select(s => s.StudentID).Count() > 3)
		.Select(x => new {
			Club = x.ClubName,
			Students = Activities 
				.Select(a => a.StudentID).Distinct()
		})
		.Dump("Clubs with 3 or more students in them");
}

// You can define other methods, fields, classes and namespaces here