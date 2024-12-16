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
	
Your company is looking to identify skills required for upcoming contracts that 
involve a large number of employees. 
You need to find skills required for contracts with more than 1 employees. Order by "Facility" then "Skills".

	Start
	Finish
	Facility
	Phone
	Skill
	Employees
	
*/

void Main()
{

ContractSkills
	.Where(x => x.NumberOfEmployees >= 2)
	.Select(x => new {
		Start = x.Contract.StartDate.ToString(),
		Finish = x.Contract.EndDate.ToString(),
		Facility = x.Contract.Location.Name,
		Phone = x.Contract.Location.Phone,
		Skill = x.Skill.Description,
		Employees = x.NumberOfEmployees
	}).OrderBy(x => x.Facility).ThenBy(x => x.Skill).Dump("Question 2");








}



