using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Warmup
{
    class Assignments
    {
        public static void PrintRightAngleTriangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                /*
                 i=1 j=4        *
                 i=2 j=3       **
                 i=3 j=2      ***
                 i=4 j=1     ****
                 i=5 j=0    *****
                 */
                int j = n - i;
                int k = i;
                while (j > 0)
                {
                    Console.Write(" ");
                    j--;
                }
                while (k > 0)
                {
                    Console.Write("*");
                    k--;
                }

                Console.WriteLine();
            }
        }

        public static long SumOfArray(long[] arr, int n)
        {
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public static long TrailingZeros(long n)
        {

            long count = 0;

            for (int i = 5; n / i >= 1; i *= 5)
                count += n / i;

            return count;
        }

        public static void DiagnolSum(int[,] matrix, int n)
        {
            int i = 0;
            for (int j = n - 1; j >= 0; j--)
            {
                int sum = matrix[i, j];
                int k = i + 1;
                int l = j + 1;
                while (k < n && l < n - i)
                {
                    sum += matrix[k, l];
                    k++;
                    l++;
                }
                Console.Write(sum + " ");
            }

            for (i = 1; i < n; i++)
            {
                int j = 0;
                int k = i + 1;
                int sum = matrix[i, j];
                j++;
                while (j < n - i && k < n)
                {
                    sum += matrix[k, j];
                    j++;
                    k++;
                }
                Console.Write(sum + " ");
            }
            Console.WriteLine();
        }

        private static int RectArea(int[] rect1, int[] rect2)
        {

            int area1 = (rect1[0] - rect1[2]) * (rect1[1] - rect1[3]);
            int area2 = (rect2[0] - rect2[2]) * (rect2[1] - rect2[3]);

            int common = OverlapLength(rect1[0], rect1[2], rect2[0], rect2[2]) * OverlapLength(rect1[1], rect1[3], rect2[1], rect2[3]);

            return area1 + area2 - common;
        }

        private static int OverlapLength(int x1, int y1, int x2, int y2)
        {
            if (y1 < x2 || x1 > y2)
                return 0;
            return Math.Min(y1, y2) - Math.Max(x1, x2);
        }

        public static long[] PreCalculatePrime(int n)
        {
            long[] result = new long[n + 1];
            result[0] = 1;
            result[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                result[i] = result[i - 1] * i;
            }

            return result;
        }

        public static long Factorial(int n, Dictionary<int, long> cache)
        {
            if (!cache.ContainsKey(n))
                cache.Add(n, n * Factorial(n - 1, cache));
            return cache[n];
        }
    }
}
