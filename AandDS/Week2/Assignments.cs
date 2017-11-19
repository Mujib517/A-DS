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

        public static void BubbleSort(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        Swap(ref arr[i], ref arr[j]);
                        Console.Write(j + " ");
                    }
                }
            }
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
    }

    public class NumberComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return (y + x).CompareTo((x + y));
        }
    }
}
