using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Week1
{
    /*
     Find all combinations of an array elements
    input: [a,b,c]
        null
        a
        b
        c
        a b
        b c
        a c
        a b c

        Similar to
        0   0   0   null
        0   0   1   a
        0   1   0   b
        0   1   1   b c
        1   0   0   c
        1   0   1   a c
        1   1   0   b c
        1   1   1   a b c

         */
    class Combinations
    {
        public static void Solution1(char[] arr)
        {
            //total combinations would be 2^n

            int total = (1 << arr.Length);  // (1<<2) to calcualte 2^n;

            for (int i = 0; i < total; i++)
            {
                var j = arr.Length - 1;
                while (j >= 0)
                {
                    if (((i >> j) & 1) > 0)
                        Console.Write(arr[j] + " ");
                    j--;
                }
                Console.WriteLine();
            }
        }
    }
}

