using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AandDS.Week3
{
    public class Assignments
    {
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
