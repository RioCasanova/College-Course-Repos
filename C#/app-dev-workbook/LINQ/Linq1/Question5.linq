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
	
List Skills and the number of novice, proficient and experts. Order by "Skills"
	
	Description
	Novice
	Proficient
	Expert
*/

void Main()
{
	Skills	
		.Select(s => new {
			Description = s.Description,
			Novice = s.EmployeeSkills.Count(es => es.Level == 1),
			Proficient = s.EmployeeSkills.Count(es => es.Level == 2),
			Expert = s.EmployeeSkills.Count(es => es.Level == 3)
		}).OrderBy(s => s.Description).Dump();

}

