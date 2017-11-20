using System;

namespace AandDS.Week1
{
    class Swap
    {
        public static void Solution1(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;

            Console.WriteLine("a is " + a + " b is " + b);
        }
        public static void Solution2(int a, int b)
        {
            if (a == b) return;
            //a=2+3=5
            //b=a-b = 2
            //a=a-b = 3
            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine("a is " + a + " b is " + b);
        }
        public static void Solution3(int a, int b)
        {
            //1. (b=a) part will execute
            //2  a and b would be fetch from memory a=2, b=3
            //3  b would be set to a. i.e a=2,b=2
            //4 (a+b) b would be 3 already ready fetched from step 2
            a = a + b - (b = a);
            Console.WriteLine("a is " + a + " b is " + b);
        }
    }
}
