using System;
using System.Collections.Generic;
using System.Text;

namespace P07.Tuple
{
    public class MyTuple<T1, T2>
    {
        public MyTuple(T1 t1, T2 t2)
        {
            Item1 = t1;
            Item2 = t2;
        }

        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public override string ToString()
        => $"{Item1} -> {Item2}";
    }
}
