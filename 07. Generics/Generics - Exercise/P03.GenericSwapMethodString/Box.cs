using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.GenericSwapMethodString
{
    public class Box<T>
    {
        public Box()
        {
            this.Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public List<T> Swap(int index1, int index2)
        {
            T toSwapIndex1 = this.Items[index1];
            T toSwapIndex2 = this.Items[index2];
            this.Items[index1] = toSwapIndex2;
            this.Items[index2] = toSwapIndex1;
            return Items;
        }

        public override string ToString() => string.Join(Environment.NewLine, Items.Select(x => $"{typeof(T)}: {x}"));
        
    }
}
