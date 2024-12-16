using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public struct ResidentAddress
    {
        //  Struct is another developer defined data type
        //  Looks like a class definition
        //  Struct however is a value type storage was as a class
        //  is a reference storage.

        public int Number;
        public string Address1;
        public string Address2;

        private string _Unit;
        private string _City;
        public string ProvinceState;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public ResidentAddress(int number, string Address1,
                    string address2, string unit, string city,
                    string provinceState):this()
        {
            Number = number;
            this.Address1 = Address1;
            Address2 = address2;
            ProvinceState = provinceState;
            _Unit = unit;
            _City = city;
        }

        //  NOTE: That no "Default" constructor was created because we 
        //  wish the program to assign the address with all necessary data
        //  at the time of creation.

        public override string ToString()
        {
            return $"{Number},{Address1},{Address2},{Unit},{City},{ProvinceState}";
        }
    }
}
