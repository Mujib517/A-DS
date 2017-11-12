using AandDS.Demo;
using AandDS.Week1;
using System;

namespace AandDS
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 5;

            Console.WriteLine(Convert.ToString(0x5555, 2));
            Console.WriteLine(n & 0xaa);

            //Console.WriteLine(Assignments.SwapBits(10));
            //Console.WriteLine(Assignments.SwapBits(7));
            //Console.WriteLine(Assignments.SwapBits(43));
            //Console.WriteLine(Assignments.SwapBits(100));


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
