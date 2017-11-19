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



            //Console.WriteLine(Assignments.SwapBits(10));
            //Console.WriteLine(Assignments.SwapBits(7));
            //Console.WriteLine(Assignments.SwapBits(43));
            //Console.WriteLine(Assignments.SwapBits(100));


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
