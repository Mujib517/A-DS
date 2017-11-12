using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Week1
{
    public class Assignments
    {
        //timeout error.
        public static void ToBinary(double n)
        {
            int i;
            int[] a = new int[65];
            for (i = 0; n > 0; i++)
            {
                a[i] = (int)n % 2;
                n = n / 2;
            }
            for (i = i - 1; i >= 0; i--)
                Console.Write(a[i]);
            Console.WriteLine();
        }

        public static bool IsPowerOf2(long n)
        {
            var count = 0;
            for (var i = 0; i < 64; i++)
            {
                if (((n >> i) & 1) > 0) count++;
                if (count > 1) return false;
            }
            return true;
        }

        public static int FindMissingNumber(int[] arr)
        {
            int actualSum = 0;
            //O(N)
            for (int i = 0; i < arr.Length; i++)
            {
                actualSum += arr[i];
            }

            int n = arr.Length + 1;
            //Sum of natural numbers formual n(n+1)/2
            int expectedSum = (n * (n + 1)) / 2;
            return expectedSum - actualSum;
        }
    }
}
