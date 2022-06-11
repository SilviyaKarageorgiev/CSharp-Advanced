using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        //public override string ToString()
        //{
        //    return $"{this.Model}:\n" +
        //        $" {this.Engine.Model}:\n" +
        //        $"  Power: {this.Engine.Power}\n" +
        //        $"  Displacement: " = this.Engine.Displacement == 0 ?  n/a : {this.Engine.Displacement}\n"
        //        //{this.Engine.Efficiency == null} ? Efficiency: n/a : Efficiency: {this.Engine.Efficiency}\n {this.Weight == 0} ? Weight: n/a : Weight: {this.Weight}\n Color: {this.Color == null} ? n/a : {this.Color}";
        //}

    }
}
