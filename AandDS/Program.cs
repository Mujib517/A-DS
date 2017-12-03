using AandDS.Demo;
using AandDS.Week1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AandDS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new[] { -3, 5, 8, 2, -4 };
            int[] arr2 = new[] { 5, -10, 8, 4, 2, -3 };
            // Array.Sort(arr);
            //Console.WriteLine(Week3.Assignments.CeilSearch(arr, 0, arr.Length - 1, -1));
            //Console.WriteLine(Week3.Assignments.  CeilSearch(arr, 0, arr.Length - 1, 10));
            //Console.WriteLine(Week3.Assignments.CeilSearch(arr, 0, arr.Length - 1, 13));
            //Console.WriteLine(Week3.Assignments.CeilSearch(arr, 0, arr.Length - 1, 25));
            //Console.WriteLine(Week3.Assignments.CeilSearch(arr, 0, arr.Length - 1, -10));


            Console.WriteLine(Week3.Assignments.countValues(5));
            Console.WriteLine(Week3.Assignments.countValues(10));
            // Console.WriteLine(Week3.Assignments.CheckPair(arr2, arr2.Length));
            //Console.WriteLine(Week3.Assignments.Reverse(123));

            //int testCases = Convert.ToInt32(Console.ReadLine());
            //while (testCases > 0)
            //{
            //    int size = Convert.ToInt32(Console.ReadLine());
            //    int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            //    Console.WriteLine(FindMissingNumber(arr, size));
            //    testCases--;
            //}
        }
    }
}
