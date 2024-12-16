using PracticeConsole.Data;  //  Give reference to the location of classes
                             //   within the specified namespace
                             //  This allows the developer to avoid having to use a 
                             //   fully qualified name everytime a reference
                             //   is made to a class in the namespace

static void DisplayString(string text)
{
    Console.WriteLine(text);
}

static void DisplayPerson(Person person)
{
    DisplayString($"{person.FirstName} {person.LastName}");
    DisplayString(person.Address.ToString());
    foreach (var emp in person.EmploymentPositions)
        DisplayString(emp.ToString());
}

Employment Job = CreateJob();
ResidentAddress Address = CreateAddress();
// Create a person
Person me = CreatePerson(Job, Address);
if (me != null)
    DisplayPerson(me);

Employment CreateJob()
{
    Employment job = null;
    try
    {
        job = new Employment();
        // DisplayString($"Good Job {job.ToString()}");
        //  checking exceptions
        job = new Employment("Boss", SupervisoryLevel.Supervisor, 5.5);
        // DisplayString($"Greed good Job {job.ToString()}");

        //  Checking exceptions
        //  Bad Data
        // job = new Employment("", SupervisoryLevel.Supervisor, 5.5);  //  empty title
        // job = new Employment("Boss", 10, 5.5);  Invalid supervisor level
        // job = new Employment("Boss", SupervisoryLevel.Supervisor, -5.5);  //  Negative Year
    }
    catch (ArgumentException ex)  // specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex)  // Genral catch all
    {
        DisplayString("Runtime error: " + ex.Message);
    }
    return job;
}

ResidentAddress CreateAddress()
{
    ResidentAddress address = new ResidentAddress();
    // DisplayString($"Default Address {address.ToString()}");
    address = new ResidentAddress(10767, "106 St NW", null, null,
                                    "Edmonton", "AB");
    // DisplayString($"Greedy Address {address.ToString()}");
    return address;
}

Person CreatePerson(Employment job, ResidentAddress address)
{
    Person thePerson = null;
    List<Employment> jobs = new List<Employment>();
    try
    {
        //  Good Test
        //  Create a good person using the greedy constructor no job list
        // thePerson = new Person("JamesNoJob", "Thompson", null, address);

        //  Create a good person using the greedy constructor empty job list
        //  thePerson = new Person("JamesEmptyList", "Thompson", jobs, address);

        //  Create a good person using the greedy constructor single job list
        // jobs.Add(job);
        // thePerson = new Person("JamesSingleJob", "Thompson", jobs, address);

        //  Create a good person using the greedy constructor multipe job list
        jobs.Add(new Employment("Worker", SupervisoryLevel.TeamMember, 2.1));
        jobs.Add(new Employment("Leader", SupervisoryLevel.TeamLeader, 7.8));
        jobs.Add(job);
        thePerson = new Person("JamesMultipeJob", "Thompson", jobs, address);
        //  Can I change the first name using the assignemnt statement
        //  The FirstName is a private set.
        //  You are NOT allowed to use a private set on the receivinb side
        //   of an assignment statment.
        //  THIS WILL NOT COMPILE.
        //thePerson.FirstName = "Jack";

        //  Can I use a behavior (method) to change the contents of a private
        //   set property
        thePerson.ChangeName("Jimmy", "DeckofCards");

        //  Can I add another job after the person instance was created.
        thePerson.AddEmployment(new Employment("Head IT", SupervisoryLevel.DepartmentHead, 0.8));

        //  Exception Testing
        //  No first name
        //thePerson = new Person(null, "Thompson", jobs, address);
        //  No last name
        //thePerson = new Person("James", null, jobs, address);

        ResidentAddress oldAdress = thePerson.Address;
        oldAdress.City = "Vancouver";
        thePerson.Address = oldAdress;
    }
    catch (ArgumentException ex)  // specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex)  // Genral catch all
    {
        DisplayString("Runtime error: " + ex.Message);
    }
    return thePerson;
}

