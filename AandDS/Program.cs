using System;

namespace AandDS
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays.Queries q = new Arrays.Queries();
            Console.WriteLine(q.GetSum(0, 3));
            Console.WriteLine(q.GetSum(1, 3));
            Console.WriteLine(q.GetSum(2, 5));
            Console.WriteLine(q.GetSum(0, 6));
            Console.WriteLine(q.GetSum(1, 5));
        }
    }
}
