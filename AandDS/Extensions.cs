
using System;

namespace AandDS
{
    public static class Extensions
    {
        public static void Print(this int[] arr)
        {
            foreach (var elem in arr)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }
    }
}
