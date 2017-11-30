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
                if (arr[mid] < k) start = mid;
                else end = mid - 1;
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
            int count = 0;
            var result = GetDistinctCount(arr, l, ref count);
            Console.Write(count + " ");
            for (int i = 0; i <= n - l; i++)
            {
                result[arr[i - 1]]--;
                count = result[arr[i - 1]] == 0 ? --count : count;
                var value = arr[i + l - 2];
                if (result.ContainsKey(value))
                {
                    var frequency = result[value];
                    count = frequency == 0 ? ++count : count;
                }
                else count++;
                Console.Write(count + " ");
            }
            Console.WriteLine();
        }

        static Dictionary<int, int> GetDistinctCount(int[] arr, int l, ref int count)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();

            for (int i = 0; i < l; i++)
            {
                if (!hash.ContainsKey(arr[i]))
                {
                    count++;
                    hash.Add(arr[i], 1);
                }
                else hash[arr[i]]++;

            }
            return hash;
        }

        public static int SmallerElemntCountToRight(int[] arr, int n)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                count += GetSmallerElemntCount(arr, i);
            }
            return count;
        }

        private static int GetSmallerElemntCount(int[] arr, int start)
        {
            int count = 0;
            for (int i = start + 1; i < arr.Length; i++)
            {
                if (arr[start] > arr[i]) count++;
            }
            return count;
        }

        public static int JobPartition(int[] arr, int n, int k)
        {
            int start = 0;
            int end = GetSum(arr, ref start);
            int mid = 0;

            while (start < end)
            {
                mid = start + (end - start) / 2;
                if (IsFeasible(arr, mid, k)) end = mid;
                else start = mid + 1;
            }
            return start;
        }

        private static int GetSum(int[] arr, ref int max)
        {
            int sum = arr[0];
            max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
                if (arr[i] > max) max = arr[i];
            }

            return sum;
        }

        private static bool IsFeasible(int[] arr, int mid, int k)
        {
            int count = 1;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (sum + arr[i] > mid)
                {
                    sum = 0;
                    count++;
                }

                sum += arr[i];
            }
            return count <= k;
        }


        public static bool TripletSum(int[] arr, int n, int sum)
        {
            int l, r;

            Array.Sort(arr);

            for (int i = 0; i < n - 2; i++)
            {
                l = i + 1;
                r = n - 1;
                while (l < r)
                {
                    if (arr[i] + arr[l] + arr[r] == sum)
                        return true;
                    else if (arr[i] + arr[l] + arr[r] < sum)
                        l++;
                    else
                        r--;
                }
            }

            return false;
        }

        public static int Floor2(int[] arr, int n, int x)
        {
            if (x == arr[n - 1]) return arr[n - 1];
            if (x < arr[0])
                return int.MinValue;
            for (int i = 1; i < n - 1; i++)
                if (arr[i] > x)
                    return arr[i - 1];

            return int.MinValue;
        }

        public static int Floor3(int[] arr, int low, int high, int x)
        {
            if (low > high)
                return int.MinValue;

            int mid = (low + high) / 2;

            if (arr[mid] == x)
                return arr[mid];

            if (mid > 0 && arr[mid - 1] <= x && x < arr[mid])
                return arr[mid - 1];

            if (x < arr[mid])
                return Floor3(arr, low, mid - 1, x);

            return Floor3(arr, mid + 1, high, x);
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
