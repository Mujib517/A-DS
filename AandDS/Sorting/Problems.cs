using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Sorting
{
    class Problems
    {
        public static void Bubble(int[] arr)
        {
            int totalSwaps = 0;
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int swaps = 0;
                for (int j = 1; j < arr.Length; j++)
                {
                    counter++;
                    if (arr[j] < arr[j - 1])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                        swaps++;
                    }
                }
                if (swaps == 0) break;
                totalSwaps += swaps;
            }
            Console.WriteLine(counter);
        }

        private static void Swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        private static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
