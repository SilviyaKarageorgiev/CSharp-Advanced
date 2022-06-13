using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06.GenericCountMethodDouble
{
    public class Box<T>
        where T : IComparable
    {
        public Box()
        {
            this.Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public int CountGraterThan(T itemTocompare)
        {
            int counter = 0;
            foreach (var item in Items)
            {
                if(item.CompareTo(itemTocompare) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
