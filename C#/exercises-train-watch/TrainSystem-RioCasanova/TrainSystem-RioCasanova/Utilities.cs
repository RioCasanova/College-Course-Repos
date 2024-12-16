﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem_RioCasanova.Data
{
    public static class Utilities
    {
        // THIS PAGE IS EXCLUSIVELY FOR METHODS JUST TO CLEAN UP MY OTHER PAGES

        public static bool IsEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }
        public static bool IsPositive(int value)
        {
            bool valid = false;
            if (value >= 0)
            {
                valid = true;
            }
            return valid;
        }
        public static bool IsEmptyBool(bool value)
        {
            try 
            {
                if (true != value || false != value)
                {
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                StringFormat(ex.Message);
                Console.WriteLine(ex.GetType());
            }
            catch (Exception ex)
            {
                StringFormat(ex.Message);
            }
            return true;
        }
        public static bool AcceptableHorsepower(int value)
        {
            bool valid = false;
            if (value >= 3500 && value <= 5500)
            {
                valid = true;
                return valid;
            }
            return valid;
        }
        //Horse Power must be a positive whole number between 3500 and 5500.
        //HP is measured in 100 HP increments.
        public static void StringFormat(string text)
        {
            Console.WriteLine(text);
        }
        public static bool AcceptableLoadLimit(int loadlimit, int capacity)
        {
            if (loadlimit > capacity)
            {
                return true;
            }
            return false;
        }

        public static int AcceptableGrossWeight(int grossweight, int loadlimit, int lightweight)
        {
            if (grossweight > loadlimit + lightweight)
            {
                return 1;
            }
            if (grossweight < lightweight)
            {
                return 2;
            }
            return 0;
        }

        public static bool FullLoadYN(int capacity, int grossweight)
        {
            double capacityPercent = capacity * 0.90;
            if (capacityPercent >= grossweight)
            {
                return false;
            }
            return true;
        }

        public static int TotalCarWeight(List<RailCar> railcars)
        {
            int weight = 0;
            foreach (var car in railcars)
            {
                weight =+ car.GrossWeight;
                return weight;
            }
            return weight;
        }

        public static int MaxGrossWeight(int horsepower)
        {
            int weightInPounds = horsepower * 2000;
            return weightInPounds;
        }

        public static bool IsEmptyList(List<RailCar> cars)
        {
            if (cars == null)
            {
                return true;
            }
            return false;
        }

        public static void AddEngine(List<Engine> engines, Engine engine)
        {
            engines.Add(engine);
        }
        public static void RemoveEngine(List<Engine> engines, Engine engine)
        {
            engines.Remove(engine);
        }

        public static bool CorrectIncrementedWeight(int weight)
        {
            if (weight % 100 == 0)
            {
                return false;
            }
            return true;
        }
        public static bool CorrectIncrementedHorsepower(int horsepower)
        {
            if (horsepower % 100 == 0)
            {
                return false;
            }
            return true;
        }

    }
}
