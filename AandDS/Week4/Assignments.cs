using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AandDS.Week4
{
    public class Assignments
    {
        public static char FirstRepeatingChar(string str)
        {
            int[] cnt = new int[26];
            foreach (char c in str)
            {
                cnt[c - 97]++;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (cnt[str[i] - 97] > 1) return str[i];
            }
            return '.';
        }
        public static bool AreAnagrams(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            int[] cnt = new int[26];
            foreach (char c in s1)
                cnt[c - 97]++;

            foreach (char c in s2)
                cnt[c - 97]--;

            foreach (int i in cnt)
                if (i != 0) return false;
            return true;
        }

        public static string Print(string s)
        {
            s = s.ToLower();
            Regex regex = new Regex("[ ]{2,}");
            s = regex.Replace(s, " ");

            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (dict.ContainsKey(c)) dict[c]++;
                else dict.Add(c, 1);
            }
            var words = 1;
            var vowels = 0;
            var consonants = 0;

            foreach (var key in dict.Keys)
            {
                if (key == ' ') words++;
                else if (key == 'a' || key == 'e' || key == 'i' || key == 'o' || key == 'u') vowels++;
                else consonants++;
            }


            return words + " " + vowels + " " + consonants;
        }

        public static bool Pow(int x)
        {
            for (int i = 1; i <= Math.Sqrt(x); i++)
            {
                var log = Math.Log(x) / Math.Log(i);
                if (log % 1 == 0) return true;
            }
            return false;
        }
        public static bool PowerRepresentation(int n)
        {
            int factor = 2;
            int x = n;
            while (factor <= Math.Sqrt(n))
            {
                if (IsPower(n, factor)) return true;
                factor++;

                //if (x % factor == 0) x = x / factor;
                //else
                //{
                //    factor++;
                //    x = n;
                //}
                //if (x == 1) return true;
            }
            return false;
        }

        public static bool IsPower(int x, int y)
        {
            if (x == 1)
                return (y == 1);

            int pow = 1;
            while (pow < y)
                pow = pow * x;

            return (pow == y);
        }

        static bool CheckVowel(int i)
        {
            return i == 97 || i == 101 || i == 105 || i == 111 || i == 117;
        }

        public static int FindSubArrayCount(List<List<int>> list)
        {
            int count = 0;
            foreach (var arr in list)
            {
                if (IsEqualZerosOnes(arr, arr.Count)) count++;
            }
            return count;
        }

        public static List<List<int>> GenerateSubArr(int[] arr, int n)
        {
            List<List<int>> list = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    var a = new List<int>();
                    for (int k = i; k <= j; k++)
                    {
                        a.Add(arr[k]);
                    }
                    list.Add(a);
                    Console.WriteLine();
                }
            }

            return list;
        }

        public static bool IsEqualZerosOnes(List<int> arr, int n)
        {
            if (arr.Count <= 1) return false;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == 0) arr[i] = -1;

                if (i != 0)
                    arr[i] += arr[i - 1];
            }

            return arr[n - 1] == 0;
        }
    }
}
