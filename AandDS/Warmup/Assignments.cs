using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Warmup
{
    class Assignments
    {
        public static void PrintRightAngleTriangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                /*
                 i=1 j=4        *
                 i=2 j=3       **
                 i=3 j=2      ***
                 i=4 j=1     ****
                 i=5 j=0    *****
                 */
                int j = n - i;
                int k = i;
                while (j > 0)
                {
                    Console.Write(" ");
                    j--;
                }
                while (k > 0)
                {
                    Console.Write("*");
                    k--;
                }

                Console.WriteLine();
            }
        }

        public static long SumOfArray(long[] arr, int n)
        {
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public static long TrailingZeros(long n)
        {

            long count = 0;

            for (int i = 5; n / i >= 1; i *= 5)
                count += n / i;

            return count;
        }

    }
}
