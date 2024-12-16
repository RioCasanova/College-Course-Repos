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
	/*
			
1. Select all the information from the club table
	Clubs.Dump("All Clubs");
	
2. Select the FirstNames and LastNames of all the students
		Students
		.Select(x => new {
		FirstName = x.FirstName,
		LastName = x.LastName
		}).Dump("Student Names");
			Students
			
			or
			
		.Select(x => new
		{
			Student = $"{x.FirstName} {x.LastName}"
			}).Dump("Student Names");
			
3. Select all the CourseId and CourseName of all the coureses. Use the column
aliases of Course ID and Course Name
			Courses
			.Select(x => new {
				CourseID = x.CourseId,
				CourseName = x.CourseName,
			}).Dump();
			
4. Select all the course information for courseID 'DMIT101'
Courses.Where(x => x.CourseId == "DMIT101").Dump();

5. Select the Staff names who have positionID of 3
		Staff 
		.Where(x => x.Position.PositionID == 3).Dump();
		
6. select the CourseNames whos CourseHours are less than 96
		Courses.Where(x => x.CourseHours < 96)
		.Select(x => x.CourseName).Dump();
		
7. Select the studentID's, OfferingCode and mark where the Mark is between 70
and 80
		Registrations.Where(x => x.Mark >= 70 && x.Mark <= 80)
		.Select(s => new {
			OfferingCode = 
			StudentID = s.StudentID,
			Mark = s.Mark 
		
		}).Dump();
		
8. Select the studentID's, Offering Code and mark where the Mark is between
70 and 80 and the OfferingCode is 1001 or 1009
Registrations
	.Where(x => x.Mark > 70 && x.Mark < 80 && x.OfferingCode == 1001 || x.OfferingCode == 1009)
	.Select(x => new {
		StudentID = x.StudentID
	}).Dump();
	
9. Select the students first and last names who have last names starting with
S
Students 
	.Where(x => x.LastName.StartsWith("s"))
	.Select(x => new {
		FirstName = x.FirstName,
		LastName = x.LastName
	}).Dump();

10. Select Coursenames whose CourseID have a 1 as the fifth character
		Courses.Where(x => x.CourseId.IndexOf('1') == 4)
			.Select(x => new {CourseID = x.CourseId, CourseName = x.CourseName})
			.Dump();
			
11. Select the CourseID's and Coursenames where the CourseName contains the
word 'programming'
		Courses.Where(x => x.CourseName.Contains("programming"))
			.Select(x => new { CourseID = x.CourseId, CourseName = x.CourseName })
			.Dump();
			
12. Select all the ClubNames who start with N or C.
		Clubs 
			.Where(x => x.ClubName.StartsWith("N") || x.ClubName.StartsWith("C"))
			.Select(x => new {
				ClubName = x.ClubName
			}).Dump();
			
13. Select Student Names, Street Address and City where the lastName has only
3 letters long.
		Students
			.Where(x => x.LastName.Length == 3)
			.Select(x => new {
				StudentName = $"{x.FirstName} {x.LastName}",
				Address = x.StreetAddress,
				City = x.City
			}).Dump();	
			
14. Select all the StudentID's where the PaymentAmount < 500 OR the
	PaymentTypeID is 5
				Payments
			.Where(s => s.Amount < 500)
			.Select(x => new {
			StudentID = x.Student.StudentID
			}).Dump();
	*/

}


// You can define other methods, fields, classes and namespaces here