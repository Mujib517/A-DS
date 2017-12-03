using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Contests
{
    class Contest1
    {

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

        public static double Reverse(int n)
        {
            int r = 0;
            while (n > 0)
            {
                int remainder = n % 10;
                r = (r * 10) + remainder;
                n = n / 10;
            }
            return r;
        }

        public static bool CheckPair(int[] arr, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += arr[i];
            if (sum % 2 != 0)
                return false;
            sum = sum / 2;
            HashSet<int> s = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                int val = sum - arr[i];

                if (s.Contains(val))
                    return true;
                s.Add(arr[i]);
            }
            return false;
        }


        public static int countValues(int n)
        {
            int unset_bits = 0;
            while (n > 0)
            {
                if ((n & 1) == 0)
                    unset_bits++;
                n = n >> 1;
            }

            return 1 << unset_bits;
        }
    }
}
