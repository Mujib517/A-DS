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
         * Most significant bit is important to find out the sign
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

        public static bool Solution3(int a, int b)
        {
            //doesn't work for zero
            return (a * b) > 0; //danger of overflow
        }

        /*
         Right shift 31 bits (coz number is int. 32nd bit would be sign)

             */
        public static bool Solution4(int a, int b)
        {
            return ((a >> 31) ^ (b >> 31)) == 0;
        }
    }
}
