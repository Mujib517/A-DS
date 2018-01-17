using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AandDS.Week9
{
    class Assignments
    {

        static int largestPrime = (int)1e9 + 7;
        //binary string with no adjacent 1's
        public static int BinaryNoAdj1s(int n, Dictionary<int, int> cache)
        {
            if (n == 0) return 1;
            if (n == 1) return 2;
            if (n == 2) return 3;
            if (!cache.ContainsKey(n)) cache[n] = (BinaryNoAdj1s(n - 1, cache) + BinaryNoAdj1s(n - 2, cache)) % largestPrime;
            return cache[n];
        }

        public static int NCR(int n, int r, Dictionary<string, int> dp)
        {
            if (n == r || r == 0) return 1;

            if (dp.ContainsKey(n + " " + r)) return dp[n + " " + r];

            int a = NCR(n - 1, r - 1, dp) % largestPrime;

            int b = NCR(n - 1, r, dp) % largestPrime;

            dp[(n - 1) + " " + (r - 1)] = a;
            dp[(n - 1) + " " + r] = b;

            return a + b;
        }

        public static bool HasSubsetSum(int[] set, int n, int sum)
        {
            bool[,] subset = new bool[sum + 1, n + 1];

            for (int i = 0; i <= n; i++)
                subset[0, i] = true;

            for (int i = 1; i <= sum; i++)
                subset[i, 0] = false;

            for (int i = 1; i <= sum; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    subset[i, j] = subset[i, j - 1];
                    if (i >= set[j - 1])
                        subset[i, j] = subset[i, j] || subset[i - set[j - 1], j - 1];
                }
            }

            return subset[sum, n];
        }

        public static int knapSack(int W, int[] wt, int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, W + 1];

            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(val[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }

        public static int SumOfDice(int n)
        {
            if (n == 0 || n == 1) return 1;
            if (n == 2) return 2;
            if (n == 3) return 4;
            return SumOfDice(n - 1) + SumOfDice(n - 2) + SumOfDice(n - 3) + SumOfDice(n - 4);
        }

        static int LongestSubSeqSum(int[] arr)
        {
            int[] lis = new int[arr.Length];
            int[] lds = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                lis[i] = 1;
                lds[i] = 1;
            }
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] >= arr[j])
                    {
                        lis[i] = Math.Max(lis[i], lis[j] + 1);
                    }
                }
            }

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[i] >= arr[j])
                    {
                        lds[i] = Math.Max(lds[i], lds[j] + 1);
                    }
                }
            }
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < lis[i] + lds[i] - 1)
                {
                    max = lis[i] + lds[i] - 1;
                }
            }
            return max;
        }

        static int MaxNonAdjSubSeqSum(int[] arr, int n)
        {
            int excl = 0;
            int incl = arr[0];
            for (int i = 1; i < n; i++)
            {
                int temp = incl;
                incl = Math.Max(excl + arr[i], incl);
                excl = temp;
            }
            return incl;
        }

        static int numberOfPaths(int m, int n)
        {
            int[,] count = new int[m, n];

            for (int i = 0; i < m; i++)
                count[i, 0] = 1;

            for (int j = 0; j < n; j++)
                count[0, j] = 1;

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)

                    count[i, j] = count[i - 1, j] + count[i, j - 1]; //+ count[i-1][j-1];

            }
            return count[m - 1, n - 1];
        }


        static BigInteger Fibonacci(BigInteger n, Dictionary<BigInteger, BigInteger> cache)
        {
            if (n == 0 || n == 1) return 1;
            if (!cache.ContainsKey(n)) cache[n] = Fibonacci(n - 1, cache) + Fibonacci(n - 2, cache);
            return cache[n];
        }

        public static int countDecoding(string digits, int n)
        {
            if (n == 0 || n == 1)
                return 1;
            int count = 0;

            if (digits[n - 1] > '0')
                count = countDecoding(digits, n - 1);

            if (digits[n - 2] == '1' || (digits[n - 2] == '2'))
                count += countDecoding(digits, n - 2);

            return count;
        }


        static int kadane_algo(int[] a, int n)
        {
            int csum = 0, msum = 0;
            for (int i = 0; i < n; i++)
            {
                csum = Math.Max(a[i], csum + a[i]);
                msum = Math.Max(msum, csum);
            }
            return msum;
        }

        int max_circular_subarray_sum(int[] a, int n)
        {
            int msum = -1;
            int total_sum = 0;
            for (int i = 0; i < n; i++)
                total_sum += a[i];

            msum = kadane_algo(a, n);

            for (int i = 0; i < n; i++)
            {
                if (a[i] != 0)
                    a[i] = (-1) * a[i];
            }
            int mini = kadane_algo(a, n);

            return Math.Max(msum, total_sum - (-mini));
        }
        //max subarray sum
        public static int Kadane(int[] inputArray)
        {
            int start = 0;
            int end = 0;
            int sum = int.MinValue;

            int cumulativeSum = 0;
            int maxStartIndexUntilNow = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {

                cumulativeSum += inputArray[i];

                if (cumulativeSum > sum)
                {
                    sum = cumulativeSum;
                    start = maxStartIndexUntilNow;
                    end = i;
                }
                if (cumulativeSum < 0)
                {
                    maxStartIndexUntilNow = i + 1;
                    cumulativeSum = 0;
                }
            }
            return sum;
        }

        static int MaxCircularSum(int[] a)
        {
            int n = a.Length;

            int max_kadane = Kadane(a);

            int max = 0;
            for (int i = 0; i < n; i++)
            {
                max += a[i];
                a[i] = -a[i];
            }

            max = max + Kadane(a);

            return (max > max_kadane) ? max : max_kadane;
        }


        public static long BinaryMax2Consecutive1s(int n, Dictionary<int, long> cache)
        {
            if (n == 0) return 1;
            if (n == 1) return 2;
            if (n == 2) return 4;
            if (!cache.ContainsKey(n)) cache[n] = BinaryMax2Consecutive1s(n - 1, cache) + BinaryMax2Consecutive1s(n - 2, cache) + BinaryMax2Consecutive1s(n - 3, cache);
            return cache[n];
        }
    }
}
