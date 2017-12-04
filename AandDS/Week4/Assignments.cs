using System;
using System.Collections.Generic;
using System.Text;

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

        static bool checkVowel(int i)
        {
            return i == 97 || i == 101 || i == 105 || i == 111 || i == 117;
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
    }
}
