using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Week1
{
    class CheckBit
    {
        public static bool Solution1(int n, int i)
        {
            /*          
             modulus is expensive operation
             it divides number to return reminder
             divide operation is subtraction operation
             18/4 == 18-4=14
                     14-4=14
                     10-4=6
                     6-4 =2
             */

            return ((n >> i) % 2) != 0;
        }

        //Right shift
        //  5     0  1 0 1
        //  5>>5  1 0 1 0
        //         1 0 
        public static bool Solution2(int n, int i)
        {
            return ((n >> i) & 1) > 0;
        }
    }
}
