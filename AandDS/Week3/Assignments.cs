using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AandDS.Week3
{
    public class Assignments
    {
        //url: https://www.hackerrank.com/contests/smart-interviews/challenges/si-distinct-elements-in-window
        public static double CBRT(double n, double start, double end)
        {
            var absN = Math.Abs(n);
            double mid = start + (end - start) / 2;

            var value = mid * mid * mid;
            if (value == absN) return n > 0 ? mid : mid - 2 * mid;
            if (value > absN)
                end = mid - 1;
            if (value < absN)
                start = mid + 1;
            return CBRT(n, start, end);
        }

        public static void FrequencySort(int[] arr, int n)
        {
            int[] result = new int[2001];
            for (var i = 0; i < n; i++)
            {
                int index = arr[i] + 1000;
                result[index]++;
            }

            Print(result);
        }

        //a[i]-a[j]==k i!=j
        public static bool SumWithDifference(int[] arr, int n, int k)
        {
            HashSet<int> hash = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!hash.Contains(i)) hash.Add(arr[i]);
            }

            for (var i = 0; i < arr.Length; i++)
            {
                if (hash.Contains(arr[i] - k) || hash.Contains(k - arr[i])) return true;
            }
            return false;
        }

        static void Print(int[] arr)
        {
            List<Data> result = new List<Data>();
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] > 0)
                {
                    var data = new Data { Key = i - 1000, Frequency = arr[i] };
                    result.Add(data);
                }
            }

            result.Sort(new DataComparer());

            foreach (var obj in result)
            {
                int frequency = obj.Frequency;
                while (frequency > 0)
                {
                    Console.Write(obj.Key + " ");
                    frequency--;
                }
            }
            Console.WriteLine();
        }

        //accepts sorted array
        public static int Floor(int[] arr, int n, int k)
        {
            int start = 0;
            int end = n;
            int mid = 0;

            while (start < end)
            {
                mid = start + (end - start) / 2;
                if (arr[mid] == k) break;
                if (arr[mid] >= k)
                    end = mid;
                else start = mid + 1;
            }

            return arr[mid] <= k ? arr[mid] : int.MinValue;
        }

        public static void SaveFrequency(int[] arr, int n)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(arr[i])) dict[arr[i]]++;
                else dict.Add(arr[i], 1);
            }
        }

        int GetFrequency(Dictionary<int, int> dict, int key)
        {
            return dict.ContainsKey(key) ? dict[key] : 0;
        }

        public static void DistinctElementsInWindow(int[] arr, int n, int l)
        {
            for (int i = 1; i <= n - l; i++)
            {
                int start = i;
                int end = i + l;
                Console.Write(GetDistinctCount(arr, start, end) + " ");
            }
            Console.WriteLine();
        }

        static int GetDistinctCount(int[] arr, int start, int end)
        {
            HashSet<int> hash = new HashSet<int>();
            int count = 0;

            for (int i = start; i < end; i++)
            {
                if (!hash.Contains(arr[i]))
                {
                    count++;
                    hash.Add(arr[i]);
                }

            }
            return count;
        }


        private static int GetMaximum(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            return max;
        }

        private static int GetSum(int[] arr)
        {
            int sum = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public static int Calculate(int[] arr, int n, int k)
        {
            int start = GetMaximum(arr);
            int end = GetSum(arr);
            int mid = 0;

            while (start < end)
            {
                mid = start + (end - start) / 2;
                if (Feasible(arr, k, mid)) start = mid + 1;
                else end = mid;
            }
            return mid;
        }

        private static bool Feasible(int[] arr, int k, int time)
        {
            int count = 0;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1 && count == k) return false;
                if (sum + arr[i] <= time)
                    sum += arr[i];
                else
                {
                    count++;
                    sum = arr[i];
                }
            }
            return count == k - 1;
        }


        public static string IsPanlindrom(string str, int n)
        {
            int p1 = 0;
            int p2 = n - 1;
            while (p1 < p2)
            {
                if (str[p1] != str[p2]) return "No";
                p1++;
                p2--;
            }
            return "Yes";
        }

        public static int CountDivisors(double n)
        {
            int count = 0;
            for (int i = 1; i <= Math.Sqrt(n) + 1; i++)
            {
                if (n % i == 0)
                {
                    if (n / i == i)
                        count++;
                    else count += 2;
                }
            }
            return count;
        }

        class Data
        {
            public int Key { get; set; }
            public int Frequency { get; set; }



        }

        class DataComparer : IComparer<Data>
        {
            public int Compare(Data x, Data y)
            {
                int compare = x.Frequency.CompareTo(y.Frequency);
                return compare == 0 ? x.Key.CompareTo(y.Key) : compare;
            }
        }
    }
}
