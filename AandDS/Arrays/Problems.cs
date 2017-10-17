using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Arrays
{
    public class Problems
    {
        /// <summary>
        /// Seggrate all 0s and 1s in O(n) and single pass
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] SeggregateArray(int[] arr)
        {
            int p1 = 0, p2 = arr.Length - 1;

            while (p1 < p2)
            {
                if (arr[p1] == 0) p1++;
                if (arr[p2] == 1) p2--;

                if (arr[p1] == 1 && arr[p2] == 0)
                {
                    var tmp = arr[p1];
                    arr[p1] = arr[p2];
                    arr[p2] = tmp;
                    p1++;
                    p2--;
                }
            }

            return arr;
        }
    }
}
