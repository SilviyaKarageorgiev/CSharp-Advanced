using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    public class Tire
    {
        private int age;
        private double pressure;

        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;            
        }

        public int Age { get; set; }
        public double Pressure { get; set; }
    }
}
