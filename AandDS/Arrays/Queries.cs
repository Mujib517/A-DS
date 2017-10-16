using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Arrays
{
    public class Queries
    {
        public int[] Source { get; set; } = new[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        public Queries()
        {
            //sum : [10,30,60,100,150,210,280,360,450,550]
            for (int i = 1; i < Source.Length; i++)
            {
                Source[i] += Source[i - 1];
            }
        }



        public int GetSum(int start, int end)
        {
            return 0;
        }


    }
}
