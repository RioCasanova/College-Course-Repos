using System;

namespace Temperature.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Name: Rio Casanova
            Course: CPSC1012
            Section: OA03
            Input: Temperature in Fahrenheit
            Output: Temperatire in Celsius
            Algorithm: (32°F − 32) × 5/9 = 0°C - Take(subtract) 32 from the desired (input)Fahrenheit temp then multiply
            it by the quotient given by 5/9, and that should equal the equivalent (output)Celsius temperature.
            Last Modified: Sept. 23, 2021 8:56pm
            */

            Console.Write("Enter temperature in Fahrenheit: ");
            double Fahrenheit = Convert.ToDouble(Console.ReadLine());

            double Celsius = (Fahrenheit - 32) * 5 / 9;

            Console.WriteLine("\nPress any key to convert to Celcius");
            Console.ReadLine();

            Console.WriteLine(Fahrenheit + " degrees fahrenheit " + "is " + Celsius + " degrees celsius.");

        } // end of method
    } // end of class
} // end of namespace
