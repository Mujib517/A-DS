using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Week1
{
    //Generate x 1's and y 0's 
    // x=2 y=3
    // result ===   1   1   0   0   0   (24)
    // x=3 y=5 
    // 1    1   1   0   0   0   0   0
    // 2^3 = 8  and the value we need is 7 which is 1   1   1 (with desired number of 1s)
    // 
    class Random
    {
        public static int Solution1(int x, int y)
        {
            //2^n
            int value = (1 << x) - 1;   //if x=3 value woulbe 2^3-1
            return (value << y);
        }
    }
}
