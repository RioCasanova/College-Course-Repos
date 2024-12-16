<Query Kind="Program">
  <Connection>
    <ID>71bd1c19-7475-4bed-8eb9-a4830a600ce4</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
    <DisplayName>WorkSchedule-Entity</DisplayName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	//  YOUR NAME HERE:

	#region Driver  //  3 Marks
	try
	{
		#region BEFORE UPDATE
		//  The driver must, at minimum perform three different task. 
		//  Task 1
		//  -   Add a new employee and register their skills (minimun of two skills). 
		EmployeeRegistrationView newEmployee = new();
		
		newEmployee.FirstName = "John";
		newEmployee.LastName = "Johnson";
		newEmployee.HomePhone = "780.123.4567";
		newEmployee.Active = true;
		
		// Creating new skills 
		EmployeeSkillView Woodworking = new();
		
		Woodworking.EmployeeID = GetEmployeeID(newEmployee.LastName, newEmployee.HomePhone);
		Woodworking.SkillID = 1;
		Woodworking.EmployeeSkillID = GetEmployeeSkillID(Woodworking.EmployeeID, Woodworking.SkillID);
		Woodworking.HourlyWage = 22;
		Woodworking.Level = 3;
		Woodworking.YearsOfExperience = 10;
		newEmployee.EmployeeSkills.Add(Woodworking);
		
		
		EmployeeSkillView Painting = new();
		
		Painting.EmployeeID = GetEmployeeID(newEmployee.LastName, newEmployee.HomePhone);
		Painting.SkillID = 2;
		Painting.EmployeeSkillID = GetEmployeeSkillID(Painting.EmployeeID, Painting.SkillID);
		Painting.HourlyWage = 25;
		Painting.Level = 2;
		Painting.YearsOfExperience = 5;
		newEmployee.EmployeeSkills.Add(Painting);
		
		
		// Calling the method
		EmployeeRegistrationView updatedEmployee = AddEditEmployeeRegistration(newEmployee);
		
		
		// showing before changes are made
		updatedEmployee.Dump("Before Update");
		#endregion
		
		
		#region AFTER UPDATE
		//  Task 2 update an employee and their skill list. 
		//  -   Updating their first or last name
			newEmployee.FirstName = "Tom";
			newEmployee.LastName = "Tomminson";
			
		//  -   Updating one existing skill	
		
			Painting.HourlyWage = 15;
			Painting.Level = 1;
			Painting.YearsOfExperience = 3;
			updatedEmployee.EmployeeSkills.Add(Painting);
		//  -   adding a minimum of one new skill
		EmployeeSkillView newSkill = new();
		
		newSkill.EmployeeID = GetEmployeeID(newEmployee.LastName, newEmployee.HomePhone);
		newSkill.SkillID = 3;
		newSkill.EmployeeSkillID = GetEmployeeSkillID(newSkill.EmployeeID, newSkill.SkillID);
		newSkill.HourlyWage = 22;
		newSkill.Level = 3;
		newSkill.YearsOfExperience = 20;
		newEmployee.EmployeeSkills.Add(newSkill);
		// creating the updated employee and visualizing the results
		EmployeeRegistrationView result = AddEditEmployeeRegistration(newEmployee);
		result.Dump("After Update");
		#endregion
		
		
		
		//  Task 3 attempts to register new skills with invalid data that will trigger all the business in this exercise
		//  Refer to business rules for all test cases

	}
	#endregion

	#region catch all exceptions 
	catch (AggregateException ex)
	{
		foreach (var error in ex.InnerExceptions)
		{
			error.Message.Dump();
		}
	}
	catch (ArgumentNullException ex)
	{
		GetInnerException(ex).Message.Dump();
	}
	catch (Exception ex)
	{
		GetInnerException(ex).Message.Dump();
	}
	#endregion
}
private Exception GetInnerException(Exception ex)
{
	while (ex.InnerException != null)
		ex = ex.InnerException;
	return ex;
}



#region Methods

#region AddEditEmployeeRegistration Method   //  6 Marks
public EmployeeRegistrationView AddEditEmployeeRegistration(EmployeeRegistrationView employeeRegistration)
{
	// --- Business Logic and Parameter Exception Section --- 
	#region Business Logic and Parameter Exception  //  2 Marks
	List<Exception> errorList = new();
	
	// All the business rules go here -- what must be met and what happens if it is not met

	#endregion

	// --- Main Method Logic Section --- 
	#region Method Code //  3 Marks

	// Actual logic to add or edit data in the database goes here. 
		// This determines if the information provided matches an employee that is already in the database
		// or if it is someone that we need to create a new record for
		// Then we act accordingly updating the fields or creating new people with new fields
		
	#region EMPLOYEE
		// Here I am retrieving the id so that we dont keep making new employees
		// and we have something to update.
		employeeRegistration.EmployeeID = GetEmployeeID(employeeRegistration.LastName, employeeRegistration.HomePhone);
		
		// checking to see if the employee exists
	var employee = Employees	
				.Where(e => e.EmployeeID == employeeRegistration.EmployeeID)
				.Select(e => e).FirstOrDefault();
				
		// If it doesn't we are creating a new employee
	if (employee == null) {
		employee = new Employees();
	}

	// We are setting the employee in the database to what we have here in our model
	employee.EmployeeID = employeeRegistration.EmployeeID;
	
	
	// Whether the employee is new or not we need to fill these fields
	employee.LastName = employeeRegistration.LastName == null ? GenerateName(5) : employeeRegistration.LastName ;
	employee.FirstName = employeeRegistration.FirstName == null ? GenerateName(7) : employeeRegistration.FirstName;
	employee.HomePhone = employeeRegistration.HomePhone == null ? RandomPhoneNumber() : employeeRegistration.HomePhone;
	employee.Active = employeeRegistration.Active;
	#endregion
	
	#region EMPLOYEE SKILLS
	// This is for the skills -- we want to loop through each skill that
	// the employee has and determine if the skills exist or not
	foreach (var EmployeeSkillView in employeeRegistration.EmployeeSkills)
	{
		// Determine whether to create a new Skill or to update and existing Skill
		EmployeeSkills currentSkill = EmployeeSkills
								.Where(x => x.EmployeeID == EmployeeSkillView.EmployeeID && x.SkillID == EmployeeSkillView.SkillID && x.EmployeeSkillID == EmployeeSkillView.EmployeeSkillID)
								.Select(x => x)
								.FirstOrDefault();
		
			// if the skill doesn't exist
		if (currentSkill == null)
		{
			// Create new skill
			currentSkill = new EmployeeSkills();
		}
		// Set the SkillID of the new Skill
		currentSkill.SkillID = EmployeeSkillView.SkillID;
		
		// filling the skill fields with what we are passing in
		// If any of these fields are empty/computer generated we need to initialize them 
		// to meet the business rules.
		currentSkill.EmployeeSkillID = EmployeeSkillView.EmployeeSkillID;
		currentSkill.SkillID = EmployeeSkillView.SkillID;
		currentSkill.EmployeeID = EmployeeSkillView.EmployeeID;
		currentSkill.HourlyWage = EmployeeSkillView.HourlyWage == null ? 15 : EmployeeSkillView.HourlyWage;
		currentSkill.Level = EmployeeSkillView.Level == 0 ? 1 : EmployeeSkillView.Level;
		currentSkill.YearsOfExperience = EmployeeSkillView.YearsOfExperience == null ? 1 : EmployeeSkillView.YearsOfExperience;

		// Determine whether to add or update employee skills
		// -- It is important that we set the skillid when we create a skill
		// in our driver or it will continually just make new skills
		// and never update.
		if (currentSkill.EmployeeSkillID == 0)
		{
			// Creating a new skill
			employee.EmployeeSkills.Add(currentSkill);
			Console.WriteLine("Skill Created");
		}
		else
		{
			// Updating the EmployeeSkill
			EmployeeSkills.Update(currentSkill);
			Console.WriteLine("Skill Updated");
		}
	}
	#endregion
	

	if (employee.EmployeeID == 0)
	{
		Employees.Add(employee);
		Console.WriteLine("Employee Created");
	}
	else {
	// It is important that the employeeid is set to something other than zero if we want to update 
	// a particular employee.
		Employees.Update(employee);
		Console.WriteLine("Employee Updated");
	}
		
	#endregion

	#region Check for errors and saving of data //  1 Marks

	// --- Error handling and saving
	if (errorList.Count() > 0) {
		// if there are errors it is best to clear the changes made by the 
		// Entity framework
		ChangeTracker.Clear();
		
		// Then we need to display the errors to the user
		throw new AggregateException("Unable to proceed: Please check error list", errorList);
	}
	else {
		SaveChanges();
	}
	#endregion
	
	// this returns the new employee that was just added to the database from the database 
	return GetEmployeeRegistration(employeeRegistration.EmployeeID);
}
#endregion

#region GetEmployeeRegistration Method    //  1 Marks
//  your code here

public EmployeeRegistrationView GetEmployeeRegistration(int employeeId) 
{
	// We want to collect the employee id and return the employee object filled with its data
	return Employees
			.Where(x => x.EmployeeID == employeeId)
			.Select(x => new EmployeeRegistrationView 
			{
				EmployeeID = x.EmployeeID,
				FirstName = x.FirstName,
				LastName = x.LastName,
				HomePhone = x.HomePhone,
				Active = x.Active,
				EmployeeSkills = x.EmployeeSkills
						.Select(s => new EmployeeSkillView 
						{
							EmployeeID = s.EmployeeID,
							EmployeeSkillID = s.EmployeeSkillID,
							SkillID = s.SkillID,
							HourlyWage = s.HourlyWage,
							Level = s.Level,
							YearsOfExperience = s.YearsOfExperience
						}).ToList()
			}).FirstOrDefault();
	
}

#endregion

#endregion


#region Class/View Model   
/// <summary> 
/// Contains class definitions that are referenced in the current LINQ file. 
/// </summary> 
/// <remarks> 
/// It's crucial to highlight that in standard development practices, code and class definitions  
/// should not be mixed in the same file. Proper separation of concerns dictates that classes  
/// should have their own dedicated files, promoting modularity and maintainability. 
/// </remarks> 
public class EmployeeRegistrationView
{
	public int EmployeeID { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string HomePhone { get; set; }
	public bool Active { get; set; }
	public List<EmployeeSkillView> EmployeeSkills { get; set; } = new();
}

public class EmployeeSkillView
{
	public int EmployeeSkillID { get; set; }
	public int EmployeeID { get; set; }
	public int SkillID { get; set; }
	public int Level { get; set; }
	public int? YearsOfExperience { get; set; }
	public decimal? HourlyWage { get; set; }
}

#endregion

#region Supporting Methods

public int GetEmployeeID(string lastName, string phone)
{
	int id = Employees
		.Where(e => e.LastName == lastName && e.HomePhone == phone)
		.Select(e => e.EmployeeID)
		.FirstOrDefault();
	return id;
}

public int GetEmployeeSkillID(int employeeid, int skillid)
{
	int employeeSkillID = EmployeeSkills
		.Where(e => e.EmployeeID == employeeid && e.SkillID == skillid)
		.Select(e => e.EmployeeSkillID)
		.FirstOrDefault();

	return employeeSkillID;
}
/// <summary>
/// Generates a random phone number.
/// The generated phone number ensures the first digit is not 0 or 1.
/// </summary>
/// <returns>A random phone number.</returns>
public static string RandomPhoneNumber()
{
	var random = new Random();
	string phoneNumber = string.Empty;

	// Ensure the first digit isn't 0 or 1.
	int firstDigit = random.Next(2, 10); // Generates a random digit between 2 and 9.
	phoneNumber = $"{firstDigit}";

	// Generate the rest of the digits.
	for (int i = 1; i < 10; i++)
	{
		int currentDigit = random.Next(10);
		phoneNumber = $"{phoneNumber}{currentDigit}";

		// Add periods after every third digit (except for the last period).
		if (i % 3 == 2 && i != 8)
		{
			phoneNumber = $"{phoneNumber}.";
		}
	}

	return phoneNumber;
}

/// <summary>
/// Generates a random name of a given length.
/// The generated name follows a pattern of alternating consonants and vowels.
/// </summary>
/// <param name="len">The desired length of the generated name.</param>
/// <returns>A random name of the specified length.</returns>
public static string GenerateName(int len)
{
	// Create a new Random instance.
	Random r = new Random();

	// Define consonants and vowels to use in the name generation.
	string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
	string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };

	string Name = "";

	// Start the name with an uppercase consonant and a vowel.
	Name += consonants[r.Next(consonants.Length)].ToUpper();
	Name += vowels[r.Next(vowels.Length)];

	// Counter for tracking the number of characters added.
	int b = 2;

	// Add alternating consonants and vowels until we reach the desired length.
	while (b < len)
	{
		Name += consonants[r.Next(consonants.Length)];
		b++;
		Name += vowels[r.Next(vowels.Length)];
		b++;
	}

	return Name;
}
#endregion