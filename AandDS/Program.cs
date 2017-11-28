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
            Array.Sort(arr);

            Week2.Assignments.SelectionSortDesc(arr, arr.Length);

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
