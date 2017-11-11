using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Week1
{
    //find whether two numbers have same sign
    class SameSign
    {
        //inputs 2 3, -2 -3  -2 3  2 -3, 0 0, -2 0, 0 -2
        public static bool Solution1(int a, int b)
        {
            if (a >= 0 && b >= 0) return true;
            if (a < 0 && b < 0) return true;
            return false;
        }

        /*
         0    0   0
         0    1   1
         1    0   1
         1    1   0

        a 2 =       0   0   1   0 
        b 3 =       0   1   0   0
        a^b (14) =  1   1   1   0

        a-2             1   1   1   1
        b 3             0   1   0   0
        a^b(-3)         1   0   1   1
        
             */
        public static bool Solution2(int a, int b)
        {
            if ((a == 0 && b == 0) || a == b) return true;
            return (a ^ b) > 0;
        }
    }
}
