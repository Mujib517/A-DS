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
            Console.WriteLine(Week4.Assignments.AreAnagrams("a", "a"));
            Console.WriteLine(Week4.Assignments.AreAnagrams("b", "h"));
            Console.WriteLine(Week4.Assignments.AreAnagrams("post", "stop"));
            Console.WriteLine(Week4.Assignments.AreAnagrams("hi", "hey"));



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
