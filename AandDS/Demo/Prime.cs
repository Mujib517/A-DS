using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Demo
{
    class Prime
    {
        //O(N)
        public static bool Solution1(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        //O(Sqrt(N))
        public static bool Solution2(int n)
        {
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
