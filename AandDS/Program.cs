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
            int[] arr = new[] { 176, -272, -272, -45, 269, -327, -945, 176 };
            var arr3 = new[] { 5, 3, 1, 5 };
            var arr4 = new[] { 40, 10, 20, 40 };
            var arr5 = new[] { 154, -109 };
            int[] arr2 = new[] { 12, 45, 52, 65, 21, 645, 234, 14, 575, 112 };
            var arr6 = new[] { 274, 204, -161, 481, -606, -767, -351 };
            var arr7 = new[] { 176, -272, -272, -45, 269, -327, -945, 176 };
            // Array.Sort(arr);

            Week2.Assignments.SelectionSortDesc(arr, arr.Length);

            //foreach (var item in arr3)
            //{
            //    Console.WriteLine(item);
            //}
            //Week2.Assignments.SelectionSortDesc(arr4, arr4.Length);
            //Week2.Assignments.SelectionSortDesc(arr5, arr5.Length);
            //Week2.Assignments.SelectionSortDesc(arr6, arr6.Length);
            //Week2.Assignments.SelectionSortDesc(arr7, arr7.Length);

            //Console.WriteLine(Week3.Assignments.SumWithDifference(arr, arr.Length, 60));
            //Console.WriteLine(Week3.Assignments.SumWithDifference(arr2, arr2.Length, 11));

            //Console.WriteLine(Week3.Assignments.Floor(arr, 6, -1));
            //Console.WriteLine(Week3.Assignments.Floor(arr, 6, 10));
            //Console.WriteLine(Week3.Assignments.Floor(arr, 6, 8));
            //Console.WriteLine(Week3.Assignments.Floor(arr, 6, -10));
            //Console.WriteLine(Week3.Assignments.Floor(arr, 6, -4));


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
