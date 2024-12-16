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

void Main()
{
	EmployeeSkills
		.Where(x => x.Skill.RequiresTicket == true)
		.GroupBy(x => x.Skill.Description)
		.Select(group => new
		{
			Description = group.Key,
			Employees = group
				.Select(e => new {
					Name = e.Employee.FirstName + " " + e.Employee.LastName,
					Level = e.Level == 1 ? "Novice" : e.Level == 2 ? "Proficient" : "Expert",
					YearExperience = e.YearsOfExperience ?? 0
				}).OrderByDescending(x => x.YearExperience)
			}).Dump("Question 1");
			
			
			/// This is question 2
	EmployeeSkills 
		.GroupBy(es => es.Employee)
		.Where(group => group.Key.EmployeeSkills.Count() > 1)
		.Select(group => new {
			Name = group.Key.FirstName + " " + group.Key.LastName,
			SkillSet = group 
				.Select(g => new {
					Description = g.Skill.Description,
					Level = g.Level == 1 ? "Novice" : g.Level == 2 ? "Proficient" : "Expert",
					YearExperience = g.YearsOfExperience ?? 0
				})
		}).Dump("Question 2");
		
		/// This is question 3
		
		
}

