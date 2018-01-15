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

        public static void PrintDiamond(int n)
        {
            int h = n / 2;
            for (int i = 0; i < n; i++)
            {
                int left = Math.Abs(h - i);
                for (int j = 0; j < left; j++) Console.Write(" ");
                if (i == 0 || i == n - 1) Console.Write("*");
                else
                {
                    Console.Write("*");
                    int total = Math.Abs(n - 2 * left - 2);
                    for (int j = 0; j < total; j++) Console.Write(" ");
                    Console.Write("*");
                }
                for (int j = 0; j < left; j++) Console.Write(" ");
                Console.WriteLine();
            }
        }

        public static void TransformMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int j = n - 1;
                while (j >= 0)
                {
                    Console.Write(matrix[j, i] + " ");//1,0, 1,1
                    j--;
                }

                Console.WriteLine();
            }
        }

        public static void DiagnolSum(int[,] matrix, int n)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int sum = 0;
                    int k = i;
                    while (k < n)
                    {
                        sum += matrix[j, k];
                        j++;
                        k++;
                    }
                    Console.WriteLine(sum + " ");
                }

            }
        }

        public static int[,] Product(int[,] a, int[,] b)
        {
            int[,] c = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    for (int k = 0; k < b.GetLength(1); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }

        public static void SpiralTraversal(int[,] a, int n)
        {
            int i, rStart = 0, cStart = 0, rEnd = n;

            while (rStart < rEnd && cStart < n)
            {
                for (i = cStart; i < n; ++i)
                {
                    Console.Write(a[rStart, i] + " ");
                }
                rStart++;

                
                for (i = rStart; i < rEnd; ++i)
                {
                    Console.Write(a[i, n - 1] + " ");
                }
                n--;

                if (rStart < rEnd)
                {
                    for (i = n - 1; i >= cStart; --i)
                    {
                        Console.Write(a[rEnd - 1, i] + " ");
                    }
                    rEnd--;
                }

                if (cStart < n)
                {
                    for (i = rEnd - 1; i >= rStart; --i)
                    {
                        Console.Write(a[i, cStart] + " ");
                    }
                    cStart++;
                }
            }
        }


    }
}

