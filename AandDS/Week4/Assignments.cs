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



        public static bool PowerRepresentation(int n)
        {
            int factor = 2;
            int x = n;
            while (factor <= Math.Sqrt(n))
            {
                if (x % factor == 0) x = x / factor;
                else
                {
                    factor++;
                    x = n;
                }
                if (x == 1) return true;
            }
            return false;
        }

        static bool CheckVowel(int i)
        {
            return i == 97 || i == 101 || i == 105 || i == 111 || i == 117;
        }
    }
}
