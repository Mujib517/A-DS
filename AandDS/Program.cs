using AandDS.Demo;
using AandDS.Week1;
using System;

namespace AandDS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SameSign.Solution2(2, 3));
            Console.WriteLine(SameSign.Solution2(-2, -3));
            Console.WriteLine(SameSign.Solution2(2, -3));
            Console.WriteLine(SameSign.Solution2(-2, 3));
            Console.WriteLine(SameSign.Solution2(0, 0));
            Console.WriteLine(SameSign.Solution2(0, 2));
            Console.WriteLine(SameSign.Solution2(0, -2));
            Console.WriteLine(SameSign.Solution2(-2, 0));
        }
    }
}
