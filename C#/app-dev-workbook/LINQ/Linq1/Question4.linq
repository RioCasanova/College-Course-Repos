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
	
You need to gather some information for your manager. 
Order by "Maximum Skill Years" then "Last Name"

	LastName
	FirstName
	SKillCount
	Minskillyear
	Maxskillyear
	MinSkillWAges
	Maxskillwages
	*/

void Main()
{
	Employees
		.Select(e => new {
			LastName = e.LastName,
			FirstName = e.FirstName,
			SkillCount = e.EmployeeSkills.Select(es => es.SkillID).Count(),
			MinSkillYear = e.EmployeeSkills.Min(es => es.YearsOfExperience) ?? 0,
			MaxSkillYear = e.EmployeeSkills.Max(es => es.YearsOfExperience) ?? 0,
			MinSkillWages = e.EmployeeSkills.Min(es => es.HourlyWage) ?? 0,
			MaxSkillWages = e.EmployeeSkills.Max(es => es.HourlyWage) ?? 0,
		}).OrderByDescending(e => e.MaxSkillYear).ThenBy(e => e.LastName).Dump("Question 4");
		
		
}

// You can define other methods, fields, classes and namespaces here