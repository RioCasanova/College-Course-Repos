using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class Person
    {
        //  Example of a composite class
        //  A composite class uses other classes in its definition
        //  A composite class is recognized with the phrase "has a" class.
        //  This class of Person "has a " resident address.

        //  An inherited class extends another class in it difintion
        //  An inherited class is recognized with the phrase "is a" class.
        //  Assume a general class called Transportation.  We can "extend"
        //   this clas to more specific classes.
        //  public class Vehicle: Transportation
        //  public class Airplane: Transportation
        //  public class Bike: Vehicle

        //  Each instance of this class will represent an individual

        //  This class define the fillowing charactersitics of a person
        //  First Name, Last Name, Current resident address
        //   List of employment positions.

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            private set
            {
                if (Utilities.IsEmpty(value))
                {
                    throw new ArgumentNullException("First name is required");
                }
                _FirstName = value;
            }
        }

        public string LastName
        {
            get { return _LastName; }
            private set
            {
                if (Utilities.IsEmpty(value))
                {
                    throw new ArgumentNullException("Last name is required");
                }
                _LastName = value;
            }
        }

        //  Composition actually uses the other class as property/fields
        //   within the definition of the class being defined.
        //  In this example, address is a field (data member)
        public ResidentAddress Address;

        //  Composition using another class
        public List<Employment> EmploymentPositions { get; private set; }

        //public Person()
        //{
        //    //  if a instance of List<T> is not created and assigned then the property
        //    //   will have an initial value of null
        //    EmploymentPositions = new List<Employment>();

        //    //  Option 1:  Assign some default value to the strings
        //    //  Since FirstName and LastName need to have a value,
        //    //   you can assign default literals to the properties

        //    FirstName = "Unknown";
        //    LastName = "Unknown";

        //    //  Option 2:  DO NOT code a "Default" constructor
        //    //  Code ONLY the "Greedy" constructor
        //    //  If only a greedyu constructor exists for the class,
        //    //   the ONLY way to possible create an instance
        //    //   for the class within the program is to use the
        //    //   coinstructor when the class instance is created.
        //}

        public Person(string firstName, string lastName,
                        List<Employment> employmentPositions,
                        ResidentAddress address)
        {
            FirstName = firstName;
            LastName = lastName;
            if (employmentPositions != null)
            { EmploymentPositions = employmentPositions; }
            else
            { 
                //  Allows a null value and the class to have an
                //   empty List<T>
                EmploymentPositions = new List<Employment>(); }
            Address = address;

        }
        public void ChangeName(string firstName, string lastName)
        {
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }

        public void AddEmployment(Employment employment)
        {
            EmploymentPositions.Add(employment);
        }
    }
}
