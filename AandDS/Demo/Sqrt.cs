using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Demo
{
    public class Sqrt
    {
        //O(N)
        public static int Solution1(int n)
        {
            for (var i = 0; i <= n; i++)
            {
                if (i * i == n) return i;
            }
            return 0;
        }

        //O(N)
        public static int Solution2(int n)
        {
            if (n == 1) return 1;
            for (var i = 0; i <= n / 2; i++)
            {
                if (i * i == n) return i;
            }

            return 0;
        }

        //O(LogN) binary search
        public static int Solution3(int n)
        {
            if (n == 1) return 1;

            int start = 1;
            int end = n;
            int mid = (start + end) / 2;

            while (start < end)
            {
                var sum = mid * mid;
                if (sum == n) return mid;
                else if (sum > n) end = mid;
                else start = mid;

                mid = (start + end) / 2;
            }

            return 0;
        }
    }
}
