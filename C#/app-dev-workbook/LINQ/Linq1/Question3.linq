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
	
You are tasked with creating a report of skills required for contracts,
sorted alphabetically by "Last Name", "Level (expert -> novice) and "Skill. 
Only show those employees who are active. 
Use the following text for the levels: 1 = Novice, 2 = Proficient, 3 = Expert.
	
	FirstName
	LastName
	Skill
	Level
	TicketReq
*/

void Main()
{
	EmployeeSkills
		.Where(es => es.Employee.Active == true)
		.Select(es => new {
			FirstName = es.Employee.FirstName,
			LastName = es.Employee.LastName,
			Skill = es.Skill.Description,
			Level = es.Level == 3 ? "Expert" : es.Level == 2 ? "Proficient" : "Novice",
			TicketRequired = es.Skill.RequiresTicket ? "Yes" : "No"
		}).OrderBy(es => es.LastName).ThenBy(es => es.Level).ThenBy(es => es.Skill).Dump("Question 3");
}


