using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole
{
    public static class Utilities
    {
        //  These types of classes shold not hold and retain data.
        //  "Static" amkes only one active copy of the class when the 
        //    program runs.

        //  When using a static class, the developer does NOT creat an
        //   individual instance, instead the developer will reference
        //   items in the static class by ClassName.Method().

        public static bool IsEmpty(string value)
        {
            //  Don way
            //bool valid = false;
            // if (string.IsNullOrEmpty(value))
            //{
            //    valid = true;
            //} 
            // return valid;
            return string.IsNullOrEmpty(value); 
        }

        public static bool IsPositive(int value)
        {
            //  Don way
            bool valid = false;
            if (value >= 0)
            {
                valid = true;
            }
            return valid;
            //return (value >-0);
        }

        //  overload method
        public static bool IsPositive(double value)
        {
            //  Don way
            bool valid = false;
            if (value >= 0.0)
            {
                valid = true;
            }
            return valid;
            //return (value >-0);
        }

        public static bool IsPositive(decimal value)
        {
            //  Don way
            bool valid = false;
            if (value >= 0.0M)
            {
                valid = true;
            }
            return valid;
            //return (value >-0);
        }
    }
}
