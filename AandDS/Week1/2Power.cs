

namespace AandDS.Week1
{
    //calculate Pow(2,n)
    class _2Power
    {
        public static int Solution1(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= 2;
            }
            return result;
        }
        public static int Solution2(int n)
        {
            if (n == 0) return 1;
            return 2 * Solution1(n - 1);
        }

        /*
         1 =   0    0   0   0   0   0   0   1   1
         1<<1= 0    0   0   0   0   0   1   0   2
         1<<2= 0    0   0   0   0   1   0   0   4
         1<<3= 0    0   0   0   1   0   0   0   8
         1<<4= 0    0   0   1   0   0   0   0   32

         1<<n= 1    0   0   0   0   0   0   0   2^n
             */
        public static int Solution3(int n)
        {
            return 1 << n;
        }
    }
}
