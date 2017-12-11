using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Week5
{
    class Assignments
    {
        public static int CalculateWater(int[] arr, int n)
        {
            int[] maxLeft = new int[n];

            maxLeft[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
                maxLeft[i] = Math.Max(maxLeft[i + 1], arr[i]);

            var total = 0;
            var maxRight = arr[0];
            for (var i = 0; i < n; i++)
            {
                if (arr[i] > maxRight) maxRight = arr[i];
                total += Math.Min(maxLeft[i], maxRight) - arr[i];
            }
            return total;
        }

        public static string GetWinner(int coins)
        {
            return coins % 6 == 0 ? "Banta" : "Santa";
        }

        public static string GetWinner(string str)
        {
            var hash = new int[26];

            for (int i = 0; i < str.Length; i++)
            {
                hash[str[i] - 'a']++;
            }
            int XOR = 0;
            for (int i = 0; i < 26; i++)
            {
                XOR = XOR ^ hash[i];
            }
            return XOR != 0 ? "Santa" : "Banta";
        }

        //Q queries
        public static int SumOfSubArrays(int[] arr, int n, int start, int end)
        {
            return start == 0 ? arr[end] : arr[end] - arr[start - 1];
        }

        public static void GetPrefixSum(int[] arr, int n)
        {
            for (int i = 1; i < n; i++)
                arr[i] += arr[i - 1];
        }

        #region SubSeqSum

        public static int SubSeqSum(int[] arr, int n, int start, int end)
        {
            var newArr = new int[n / 2];

            Array.Copy(arr, 0, newArr, 0, n / 2);
            var subset1 = GenerateSubSeq(newArr, n / 2);

            newArr = new int[n / 2];
            Array.Copy(arr, n / 2, newArr, 0, n / 2);
            var subset2 = GenerateSubSeq(newArr, n / 2);


            return FindSum(subset1, subset2, start, end);
        }

        public static int FindSum(int[] arr1, int[] arr2, int start, int end)
        {
            return 0;
        }
        public static int[] GenerateSubSeq(int[] arr, int n)
        {
            int upper = 1 << n; //2 power n
            int[] result = new int[upper];
            for (int i = 0; i < upper; i++)
            {
                int j = 0;
                var count = 0;
                while (j < n)
                {
                    if (IsBitSet(i, j)) count = count + arr[j];
                    j++;
                }
                result[i] = count;
            }
            return result;
        }

        private static bool IsBitSet(int n, int i)
        {
            return ((n >> i) & 1) > 0;
        }

        #endregion

        #region Prime Fear
        private static int[] PreCalculatePower()
        {
            int[] powers = new int[7];
            powers[1] = 10;
            for (int i = 2; i < 7; i++) powers[i] = (int)Math.Pow(10, i);
            return powers;
        }

        private static bool[] PreCalculatePrimes()
        {
            int n = (int)1e6;
            bool[] arr = new bool[n + 1];

            for (int i = 2; i <= n; i++)
            {
                if (!HasZero(i))
                    arr[i] = true;
            }

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (arr[i])
                {
                    for (int j = i * i; j <= n; j = j + i)
                        arr[j] = false;
                }
            }

            return arr;
        }

        private static int GetPrimeCount(bool[] arr, int[] powers, int n)
        {
            var count = 0;
            for (int i = 2; i <= n; i++)
            {
                if (arr[i] && IsTruePrime(arr, powers, i))
                    count++;
            }
            return count;
        }

        private static bool HasZero(int i)
        {
            while (i > 0)
            {
                if (i % 10 == 0) return true;
                i = i / 10;
            }
            return false;
        }

        private static bool IsTruePrime(bool[] arr, int[] powers, int n)
        {
            int digits = (int)Math.Floor(Math.Log10(n) + 1);
            var count = digits - 1;
            for (int i = 0; i < digits - 1; i++)
            {
                int number = (int)(n % powers[count]);
                if (!IsPrime(arr, number)) return false;
                count--;
            }
            return true;
        }

        private static bool IsPrime(bool[] arr, int n)
        {
            return arr[n];
        }

        #endregion
    }
}
