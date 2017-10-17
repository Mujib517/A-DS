using System;

namespace AandDS
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Arrays.Problems.SeggregateArray(new[] { 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0 });

            result.Print();
        }


    }
}
