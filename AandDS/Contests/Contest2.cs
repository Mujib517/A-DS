using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Contests
{

    class Time
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
    class Contest2
    {
        static bool IsSubSeq(String str1, String str2, int m, int n)
        {
            if (m == 0)
                return true;
            if (n == 0)
                return false;

            if (str1[m - 1] == str2[n - 1])
                return IsSubSeq(str1, str2, m - 1, n - 1);

            return IsSubSeq(str1, str2, m, n - 1);
        }

        public static int FindCount(int[] result, int start, int end)
        {
            if (start == 0) return result[end];
            return result[end] - result[start];
        }

        public static int[] PrePopulateCount(bool[] arr)
        {
            int count = 0;
            int[] result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]) count++;
                result[i] = count;
            }

            return result;
        }

        public static bool[] PreCalculatePrimes()
        {
            int n = 20;
            bool[] arr = new bool[n + 1];

            for (int i = 2; i <= n; i++)
            {
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

        public static int FindRooms()
        {
            var times = new List<Time>
            {
                new Time{Start=16,End=58 },
                new Time{Start=4,End=16 },
                new Time{Start=12,End=71    },
                new Time{Start=57,End=72}
        };
            times.Sort(new TimeComprator());
            int count = 1;
            for (int i = 1; i < times.Count; i++)
            {
                if (times[i].Start <= times[i - 1].End) count++;
            }

            return count;
        }

        public static int GetSmallestStrength(int[] arr, int n)
        {
            Array.Sort(arr);
            CalcPrefixSum(arr, n);

            for (int i = 1; i < n; i++)
            {
                if (arr[i] - arr[i - 1] != 1) return arr[i - 1] + 1;
            }

            return int.MinValue;
        }

        static void CalcPrefixSum(int[] arr, int n)
        {
            for (int i = 1; i < n; i++) arr[i] += arr[i - 1];
        }

        public static int GetSubArray(int[] arr, int k)
        {
            int total = 0;
            int startIdx = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (startIdx == -1 && arr[i] == 0) startIdx = i;
                if (arr[i] == 1) total++;
            }

            for (int i = startIdx; i < arr.Length && k != 0; i++)
            {
                if (arr[i] == 0) total++;
                k--;
            }
            return total;
        }

        static int GetZerosCount(int[] arr, int n)
        {
            int count = 0;
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] == 0)
                    count = 0;
                else
                {
                    count++;
                    result = Math.Max(result, count);
                }
            }

            return result;
        }

        public static string GetResult(int n)
        {
            if (n == 1) return "Win";
            if (n == 2) return "Lose";
            if (n == 3) return "Win";
            if (IsPerfectSqure(n)) return "Win";

            return GetResult(n - (int)Math.Sqrt(n));
        }

        static bool IsPerfectSqure(int n)
        {
            int sqrtN = (int)Math.Sqrt(n);
            return sqrtN * sqrtN == n;
        }
    }

    class TimeComprator : IComparer<Time>
    {
        public int Compare(Time x, Time y)
        {
            return x.End.CompareTo(y.Start);
        }
    }
}
