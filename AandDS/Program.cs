using AandDS.Demo;
using AandDS.Week1;
using System;

namespace AandDS
{
    class Program
    {
        static void Main(string[] args)
        {

            var str = "1 2 7 9 5 6 3 8";

            int[] arr = Array.ConvertAll(str.Split(' '), Int32.Parse);
            //var input3 = new[] { 8, 11, 10, 2, 7, 4, 3, 5, 1, 6 };
            //var input2 = new[] { 3, 5, 8, 1, 4, 7, 2 };
            //var input = new[] { 1, 2, 7, 9, 5, 6, 3, 8 };

            //var str = "1 2 3 4";

            //Array.ConvertAll(str.Split(' '), int.Parse);

            //Console.WriteLine(Assignments.FindMissingNumber(input));
            //Console.WriteLine(Assignments.FindMissingNumber(input2));
            //Console.WriteLine(Assignments.FindMissingNumber(input3));


            //int testCases = Convert.ToInt32(Console.ReadLine());
            //while (testCases > 0)
            //{
            //    int size = Convert.ToInt32(Console.ReadLine());
            //    int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            //    Console.WriteLine(FindMissingNumber(arr, size));
            //    testCases--;
            //}
        }
    }
}
