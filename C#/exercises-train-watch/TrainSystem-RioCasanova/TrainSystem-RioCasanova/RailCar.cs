﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSystem_RioCasanova.Data;

namespace TrainSystem_RioCasanova
{
    public class RailCar
    {

        // FIELDS --------------------------------------------------------------------
        private string _SerialNumber;
        private int _LightWeight;
        private int _Capacity;
        private int _LoadLimit;
        private bool _InService;
        private bool _IsFull;
        private int _GrossWeight;
        private int _NetWeight;

        
        // PROPERTIES -----------------------------------------------------------------
        public RailCarType Type { get; set; }

        public string SerialNumber
        {
            get { return _SerialNumber; }
            private set
            {
                if (Utilities.IsEmpty(value))
                {
                    throw new Exception("Serial Number must be declared");
                }
                _SerialNumber = value;
            }
        }

        public int LightWeight
        {
            get { return _LightWeight; }
            private set 
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new Exception("LightWeight must be a positive Integer");
                }
                _LightWeight = value;
            }
        }
        // Railcar when empty - weight of the railcar without the stuff inside
        public int Capacity
        {
            get { return _Capacity; }
            private set 
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new Exception("Capacity must be a positive Integer");
                }
                _Capacity = value;
            }
            // weight is in lbs
        }
        // Standard Maximum Net Weight - "ballpark figure"

        public int LoadLimit
        {
            get { return _LoadLimit; }
            private set 
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentOutOfRangeException("LoadLimit must be a positive Integer");
                }
                if (!Utilities.AcceptableLoadLimit(value, Capacity))
                {
                    throw new ArgumentOutOfRangeException("Load Limit must be more than Capacity");
                }
                _LoadLimit = value; 
            }
        }
        // MAX Net Weight allowed - doesn't include Light Weight
        // might have some issues on this one later when testing 

        public int GrossWeight
        {
            get 
            { return _GrossWeight; }
            private set
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentOutOfRangeException("GrossWeight must be a positive Integer");
                }
                int exceptionType = Utilities.AcceptableGrossWeight(value, LoadLimit, LightWeight);
                if (exceptionType == 1)
                {
                    throw new ArgumentException("Unsafe Load - The Gross Load Limit has exceeded the legal weight limit for this car. " +
                    "Please contact your supervisor. \"For safety, a rail car should be loaded so that Gross Weight" +
                    " is less than the sum of its stenciled Load Limit + Light Weight.\"");
                }
                if (exceptionType == 2)
                {
                    throw new ArgumentException("Scale Error - The Gross Weight supplied is less than the Light Weight supplied");
                }
                _GrossWeight = value;
            }
        }
        public bool InService
        {
            get { return _InService; }
            private set 
            {
                if (Utilities.IsEmptyBool(value))
                {
                    throw new Exception("You must enter a True or False statement / specify" +
                                        "whether or not the car is in service");
                }
                _InService = value; 
            }
        }

        // CALCULATED VALUES ----------------------------------------------------------
        public int NetWeight
        {
            get 
            {
                _NetWeight = GrossWeight - LightWeight;
                return _NetWeight; 
            } 
        }

        public bool IsFull
        {
            get 
            {
                if (Utilities.FullLoadYN(Capacity, GrossWeight))
                {
                    bool _IsFull = false;
                    return _IsFull;
                }
                _IsFull = true;
                return _IsFull;
            } 
        }

        // GREEDY CONSTRUCTOR ----------------------------------------------------------
        public RailCar(string serialnumber, int lightweight, int capacity, 
                        int loadlimit, bool inservice, RailCarType type)
        {
            SerialNumber = serialnumber;
            LightWeight = lightweight;
            Capacity = capacity;
            LoadLimit = loadlimit;
            InService = inservice;
            Type = type;
        }
        // DEFAULT CONSTRUCTOR ---------------------------------------------------------
        public RailCar()
        {

        }
        // ToString() OVERRIDE ---------------------------------------------------------
        public override string ToString()
        {
            return $"{SerialNumber}, {LightWeight}, {Capacity}, {LoadLimit}, {Type}, " +
                $"{GrossWeight}, {InService}, {NetWeight}, {IsFull}";
        }

        public void RecordScaleWeight(int grossweight)
        {
            GrossWeight = grossweight;
        }

    } // end of class
}
