using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Demo
{
    class Divisor
    {
        //O(N)
        public static int Solution1(int n)
        {
            if (n == 0) return 0;

            var count = 1;

            for (var i = 1; i < n; i++)
            {
                if (n % i == 0) count++;
            }

            return count;
        }

        //O(N)
        public static int Solution2(int n)
        {
            if (n == 0) return 0;
            var count = 1;

            for (var i = 1; i <= n / 2; i++)
            {
                if (n % i == 0) count++;
            }

            return count;
        }

        //O(sqrt(N))
        public static int Solution3(int n)
        {
            int count = 0;

            for (var i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    if (i * i == n) count++;
                    else count += 2;
                }
            }

            return count;
        }
    }
}
