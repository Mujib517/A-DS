using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AandDS.Week2
{
    public class Assignments
    {
        //Tower of hanoi
        public static void TOH(int n, char src, char dest, char temp, List<String> result)
        {
            if (n == 0) return;
            TOH(n - 1, src, temp, dest, result);
            result.Add("Move " + n + " from " + src + " to " + dest);
            TOH(n - 1, temp, dest, src, result);
        }

        //Find out two repeated numbers in an array. array contains 
        //n+2 elements raning from 1 to n
        public static void Repeated2Numbers(int[] arr)
        {
            Array.Sort(arr);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1]) Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        //Every number repeats thrice in an array except one.
        public static int NonRepeatingNumber(int[] arr)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (count.ContainsKey(arr[i])) count[arr[i]]++;
                else count.Add(arr[i], 1);
            }

            foreach (var key in count.Keys)
            {
                if (count[key] == 1) return key;
            }
            return -1;
        }

        //find out whether a[i]+a[j]=k element exists or not where i<j
        public static bool SumOfParis(int[] arr, int n, int k)
        {
            Array.Sort(arr);
            int p1 = 0;
            int p2 = n - 1;

            while (p1 < p2)
            {
                int sum = arr[p1] + arr[p2];
                if (sum < k) p1++;
                else if (sum > k) p2--;
                else return true;
            }

            return false;
        }

        public static int BubbleSort(int[] arr, int n)
        {
            var count = 0;
            for (int i = 0; i < n; i++)
            {
                var swaps = 0;
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swaps++;
                        Swap(ref arr[i], ref arr[j]);
                    }
                }
                if (swaps == 0) break;
                count += swaps;
            }

            return count;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static string LargestNumberConcatenated(string[] arr)
        {
            Array.Sort(arr, new NumberComparer());
            return string.Join("", arr);
        }

        public static int MaxContSubSeq(int[] a, int size)
        {
            int[] arr = a.Distinct().ToArray();
            size = arr.Length;
            int[] match = new int[size];
            int max = 0;

            for (var i = 0; i < size; i++)
            {
                for (var j = i + 1; j < size; j++)
                {
                    if (arr[i] < arr[j])
                    {

                        match[i]++;
                        if (match[i] > max) max = match[i];

                    }
                }
            }

            return max;
        }

        public static int GetAWinningChances(int[] teamA, int[] teamB, int size)
        {
            int count = 0;

            Array.Sort(teamA);
            Array.Sort(teamB);

            int p1 = size - 1;
            int p2 = size - 1;

            while (p1 >= 0 && p2 >= 0)
            {
                if (teamA[p1] > teamB[p2])
                {
                    count++;
                    p1--;
                }
                p2--;
            }

            return count;
        }

        public static void InsertionSort(int[] arr, int n)
        {

            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
                Console.WriteLine((j + 1) + " ");
            }
        }

        public static void SelectionSort(int[] arr, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {

                int min = i;
                int j = i + 1;
                while (j < n)
                {
                    if (arr[j] <= arr[min])
                        min = j;
                    j++;
                }
                Console.Write(min + " ");
                Swap(ref arr[i], ref arr[min]);
            }

            Print(arr);
        }

        public static void SelectionSort2(int[] arr, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                int temp = arr[min_idx];
                //Console.Write(i - min_idx + n + " ");

                Console.WriteLine("from {0} {1}  values {2},{3}", min_idx, i, arr[min_idx], arr[i]);
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }
        
        public static void StrInterleaving(string a, string b, int m, int n, char[] result, int i)
        {
            if (m == 0 && n == 0) Console.WriteLine(result);

            if (m != 0)
            {
                result[i] = a[0];
                StrInterleaving(a.TrimStart(a[0]), b, m - 1, n, result, i + 1);
            }
            if (n != 0)
            {
                result[i] = b[0];
                StrInterleaving(a, b.TrimStart(b[0]), m, n - 1, result, i + 1);
            }
        }

        public static int MaxContSubArray(int[] arr, int n)
        {
            HashSet<int> S = new HashSet<int>();
            int ans = 0;

            for (int i = 0; i < n; ++i)
                S.Add(arr[i]);

            for (int i = 0; i < n; ++i)
            {
                if (!S.Contains(arr[i] - 1))
                {
                    int j = arr[i];
                    while (S.Contains(j))
                        j++;

                    if (ans < j - arr[i])
                        ans = j - arr[i];
                }
            }
            return ans;
        }
        private static void Print(int[] arr)
        {
            foreach (var item in arr) Console.Write(item + " ");
            Console.WriteLine();
        }
    }

    public class NumberComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return (y + x).CompareTo((x + y));
        }
    }
}
