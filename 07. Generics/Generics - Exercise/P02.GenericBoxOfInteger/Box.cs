using System;
using System.Collections.Generic;
using System.Text;

namespace P02.GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box()
        {
            this.Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");               
            }
            return sb.ToString();
        }
    }
}
