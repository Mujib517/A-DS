using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Bits
{
    class Problems
    {
        public static int ComputeXOR(int n)
        {
            if (n % 4 == 0) return n;
            if (n % 1 == 1) return 1;
            if (n % 2 == 2) return n + 1;
            return 0;
        }
    }
}
