using AandDS.Demo;
using AandDS.Week1;
using System;
using System.Collections.Generic;

namespace AandDS
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = new[] {3,7,10 };
            var b = new[] { 5,20,15 };


            Console.WriteLine(Week2.Assignments.GetAWinningChances(a, b, 2));




            //long test = (long)1e18;

            //Console.WriteLine(Assignments.FindNthNumberWithTwoSetBits(1));
            //Console.WriteLine(Assignments.FindNthNumberWithTwoSetBits(2));
            //Console.WriteLine(Assignments.FindNthNumberWithTwoSetBits(5));
            //Console.WriteLine(Assignments.FindNthNumberWithTwoSetBits(50));
            //Console.WriteLine(Assignments.FindNthNumberWithTwoSetBits(test));



            //int testCases = Convert.ToInt32(Console.ReadLine());
            //while (testCases > 0)
            //{
            //    int size = Convert.ToInt32(Console.ReadLine());
            //    int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            //    Console.WriteLine(FindMissingNumber(arr, size));
            //    testCases--;
            //}

            //static void Main(String[] args)
            //{
            //    int testCases = Convert.ToInt32(Console.ReadLine());
            //    while (testCases > 0)
            //    {
            //        int n = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine(FindNthNumberWithTwoSetBits(n));
            //        testCases--;
            //    }
            //}

            //private static int FindNthNumberWithTwoSetBits(int n)
            //{
            //    int largestPrime = (int)1e9 + 7;
            //    long x1 = (long)Math.Round(Math.Sqrt(n * 2), 0) - 1;
            //    long y1 = n - ((long)((x1 * (x1 + 1)) / 2) + 1);

            //    int x = (int)x1 % largestPrime;
            //    int y = (int)y1 % largestPrime;

            //    return ((2 << (int)x) | (1 << (int)y) % largestPrime);
            //}
        }
    }   
}
