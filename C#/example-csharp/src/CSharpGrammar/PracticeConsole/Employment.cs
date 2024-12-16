using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class Employment
    {
        //  An instance of this class will hold data 
        //  about a person's employment
        //  The code of this class is definition of 
        //  that data.
        //  The characteristics (data) of the class will contain
        //  Title, SUpervisory Level, Years of Employment within
        //  the company

        //  The 4 components of a class definition are:

        //  Data Fields
        //  are storage area in your class.
        //  These are treated as variables.
        //  These maybe public, private, public readonly (access it but not set it), etc.
        private string? _Title;
        private double _Years;


        //  Properties
        //  These are access techiniques to retrive or set data in
        //  your class without directly touching the storage data fields.

        //  Fully implemented property
        //    a) a declared storage area (data field)
        //    b) a declared property signature
        //    c) a coded get "Method"
        //    d) an optional coded set "Method".

        //  When:
        //    a)  If you are storing the associated data in
        //        an explicitly data field.
        //    b)  If you are doing validation against incoming data
        //    c)  Creating a property that generates output from other data sources
        //        wth the class (readonly properties)
        //        ie:  Fullname -> _FirstName + " " + _LastName;

        public string Title
        {
            //  accessor
            //  The get "method" will return the contents of the data field (_Title)
            //  as an expression
            get { return _Title; }
            set
            {
                //  mutator
                //  The set "Method" receives an invoming value
                //    and places it in the associated data field.
                //  During the setting, you might wish to validate the incoming data.
                //  During the setting, you might wish to do some type of loigical
                //   processing using the data to set another field.
                //  The incoming piece of data is referred using the keyword "value"

                //  ensure that the incoming data is not null, empty or just whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data");
                }
                //  data is considered valid
                _Title = value;
            }
        }

        //  Auto-implemented property

        //  These properties differ only in syntax.
        //  Each property is responsible for a single piece of data
        //  These properties do NOT reference a declared private data member.
        //  The system generates an internal storage area of the return data type.
        //  The system manages the internal storage for the accessor and mutator.
        //  There is NO additional logic applied to the data value.

        public SupervisoryLevel Level { get; set; }
        public double Years
        { get { return _Years; } 
            set {
                if (!Utilities.IsPositive(value))
                {
                    throw new Exception("Year cannot be a negative value");
                }
                _Years = value; 
            } 
        }

        //  Constructor
        //  Used to initialize the physical object (instance) during the
        //   creation.
        //  The results of the creation ensure that the coder gets an
        //   instance in a known state.

        //  If your class definition has NO constructor coded, then the data
        //   members uses the auto implemented properties are set to the
        //   C# default data values.

        //  You can code one or more constrcutors in your class definition.
        //  IF YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE
        //   FOR ALL CONSTRUCTORS USED BY THE CLASS.

        //  Generally, if you are going to code your constructor(s), you
        //   code two types.
        //  Default:  This constructor does NOT take any parameters (it 
        //             mimics the default system constructor).
        //  Greedy:  This constructor has a list of parameters, one for each
        //            properties declare for incoming data.
        //
        //  Syntax:  AccessType classname([list of parameters]) 
        //             {constructor body}
        //
        //  IMPORTANT:  The constructor DOES NOT have a return data type.
        //  You DO NOT call constructor directly, instead you call the
        //   "new" operator.

        //  Default constructor
        public Employment()
        {
            //  Constructor Body:
            //  a)  Empty (no code)
            //  b)  assign literal values to your properties using this
            //       constructor.
            Level = SupervisoryLevel.TeamMember;  //  or any number we want.  So default not 0;
            Title = "Unknown";
        }

        //  Greedy Constructor
        //  Will take in value(s) for your fields(s)

        public Employment(string title, SupervisoryLevel level, double years)
        {
            // constructor body
            //  a) a parameter for each property
            //  b)  you COULD do validation with the constructor instead of 
            //       the property
            //  c)  Validation for public readonly data members.
            //  Validation for a property with a private set.
            Title = title;
            Level = level;
            Years = years;
        }


        //  Behavior (method)
        //  Behavior are no different than method elsewhere

        //  Syntax:  accesstype [static] returnDataType behaviorName (methodName)
        //             ([list of parameters])
        //             { code body}

        //  There maybe times you wish to obtain all the data in your instance.
        //   all at once.
        //  Generally, to accomplish this, your class overrides the
        //    .ToString() method of the class.

        public override string ToString()
        {
            // common separate value string (csv)
            // The string is being created using string interpolation
            return $"{Title},{Level},{Years}";

            //  straight concatenation of strings
            //  return Title + "," + Level + "," + Years.ToString();
        }

        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            //  you could validate within this method to ensure acceptable value.
            if (level < 0)
            {
                throw new Exception("Responsibility must be a positive value");
            }
            Level = level;
        }











    }
}
