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
            int[] arr = new[] { -2, -4, -2, 4, -2 };

            Week3.Assignments.DistinctElementsInWindow(arr, arr.Length, 3);
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
