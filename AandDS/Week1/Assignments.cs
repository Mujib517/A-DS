using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AandDS.Week1
{
    public class Assignments
    {
        //timeout error.
        public static void ToBinary(double n)
        {
            int i;
            int[] a = new int[65];
            for (i = 0; n > 0; i++)
            {
                a[i] = (int)n % 2;
                n = n / 2;
            }
            for (i = i - 1; i >= 0; i--)
                Console.Write(a[i]);
            Console.WriteLine();
        }

        public static bool IsPowerOf2(long n)
        {
            var count = 0;
            for (var i = 0; i < 64; i++)
            {
                if (((n >> i) & 1) > 0) count++;
                if (count > 1) return false;
            }
            return true;
        }

        public static int FindMissingNumber(int[] arr)
        {
            int actualSum = 0;
            //O(N)
            for (int i = 0; i < arr.Length; i++)
            {
                actualSum += arr[i];
            }

            int n = arr.Length + 1;
            //Sum of natural numbers formual n(n+1)/2
            int expectedSum = (n * (n + 1)) / 2;
            return expectedSum - actualSum;
        }

        //Reverse the number in binary format and return equivalent decimal value
        public static UInt32 ReverseBinaryNumber(int n)
        {
            var binaryStr = "";

            for (var i = 0; i < 32; i++)
            {
                binaryStr += ((n >> i) & 1) > 0 ? "1" : "0";
            }

            return Convert.ToUInt32(binaryStr, 2);
        }

        //how many bits need to be flipped inorder to transform n1 to n2
        public static int FlipBits(int n1, int n2)
        {
            int result = n1 ^ n2;

            int count = 0;
            for (var i = 0; i < 32; i++)
            {
                if (((result >> i) & 1) > 0) count++;
            }

            return count;
        }

        public static int SwapBits(int n)
        {
            return ((n & 0xaa) >> 1) | ((n & 0x55) << 1);
        }

        public static void PrintSubset(int[] arr)
        {
            int totalSubsets = PowerOf2(arr.Length);
            string[] result = new string[totalSubsets - 1];
            string str = "";
            for (int i = 1; i < totalSubsets; i++)
            {
                int j = 0;
                while (j < arr.Length)
                {
                    if (IsBitSet(i, j)) str += "t" + arr[j] + " ";
                    j++;
                }
                result[i - 1] = str;
                str = "";
            }
            Print(result);
        }

        private static int PowerOf2(int n)
        {
            return 1 << n;
        }

        private static bool IsBitSet(int n, int i)
        {
            return ((n >> i) & 1) > 0;
        }

        private static void Print(string[] arr)
        {
            Array.Sort(arr, new OrdinalComparer());

            foreach (string str in arr) Console.WriteLine(str.Replace("t", ""));
        }

        public static void Generate(List<string> st, string s)
        {
            if (s.Length == 0)
                return;

            // If current string is not already present.
            if (!st.Contains(s))
            {
                st.Add(s);

                // Traverse current string, one by one 
                // remove every character and recur.
                for (int i = 0; i < s.Length; i++)
                {
                    string t = s;
                    t.Remove(i, 1);
                    Generate(st, t);
                }
            }

            for (int i = 0; i < st.Count; i++) Console.WriteLine(st[i]);
            return;
        }

        public static long FindNthNumberWithTwoSetBits(long n)
        {
            long largestPrime = (long)1e9 + 7;
            long x = ((long)Math.Round(Math.Sqrt(n * 2), 0) - 1) % largestPrime;
            long y = (n - ((long)((x * (x + 1)) / 2) + 1)) % largestPrime;

            return ((2 << (int)x) | (1 << (int)y) % largestPrime);
        }

        public static int FindMissingNumber2(int[] arr)
        {
            var result = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                result ^= arr[i];
                result ^= arr[i];
            }
            return result;
        }

        public static long Pow(int a, int b)
        {
            long temp = 1;
            if (b == 0) return 1;
            temp = Pow(a, b / 2);
            long result = 0;
            if (b % 2 == 0) result = temp * temp;
            else result = a * temp * temp;

            long longestPrime = (long)1e9 + 7;
            return result % longestPrime;
        }

        public static long Pow2(long x, int b)
        {
            long a = 1;
            long longestPrime = (long)1e9 + 7;

            for (int i = 0; i < 32; i++)
            {
                if (IsBitSet(b, i))
                    a = (a * x) % longestPrime;
                x = (x * x) % longestPrime;
            }

            return a % longestPrime;
        }

        public static int singleNumber(List<int> A)
        {
            var result = A[0];
            var dict = new Dictionary<int, int>();
            for (int i = 1; i < A.Count; i++)
            {
                if (dict.ContainsKey(A[i])) dict[A[i]]++;
                else dict.Add(A[i], 1);
            }
            foreach (var key in dict.Keys)
            {
                if (dict[key] == 1) return key;
            }
            return 0;
        }

        //-2147483648
        //B : -1
        public static long divide(long A, int B)
        {
            long count = 0;

            long val = A;
            int val2 = B;

            if (A < 0)
            {
                val = A - 2 * A;
            }
            if (B < 0)
            {
                val2 = B - 2 * B;
            }

            while (val > 1)
            {
                val = val - val2;
                count++;
            }

            if ((A < 0 && B < 0) || (A > 0 && B > 0)) return count;
            return count - 2 * count;
        }

        public static int SetBits(int n)
        {
            int bit2Position = (int)Math.Round(Math.Sqrt(n * 2), 0) - 1;
            int bit1Position = n - ((int)((bit2Position * (bit2Position + 1)) / 2) + 1);

            return (2 << bit2Position) | (1 << bit1Position);
        }

        public static void printTwoSetBitNums(int n)
        {
            int x = 1;
            int y = 0;
            if (y < x)
            {
                Console.Write((1 << n) + (1 << y) + " ");
                y++;
            }
            x++;
            Console.WriteLine();
            // Increment higher set bit
        }

        public static long getNthNumber(long n)
        {
            long a = (long)Math.Floor((1 + Math.Sqrt(1 + 8 * n - 8)) / 2);
            long b = n - a * (a - 1) / 2 - 1;

            return a + b;
        }

        public static int Next2BitsNum(int n)
        {
            int bit0 = 0;
            int bit1 = 1;
            int i;
            for (i = 1; i <= n; i++)
            {
                bit0++;
                if (bit0 == bit1)
                {
                    bit0 = 0;
                    bit1++;
                }
            }

            return (1 << bit0) | (1 << bit1);
        }

        public static string ToBinary2(int n)
        {
            string str = "";
            while (n > 0)
            {
                for (var i = 16; i >= 0; i--)
                {
                    int val = (1 << i);
                    if (val <= n)
                    {
                        n = n - val;
                        str += "1";
                    }
                    else str += "0";
                }
            }
            return str.TrimStart('0');
        }
    }
}



class OrdinalComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        StringComparison comparisonMode = StringComparison.CurrentCultureIgnoreCase;

        string[] splitX = Regex.Split(x.Replace(" ", ""), "([0-9]+)");
        string[] splitY = Regex.Split(y.Replace(" ", ""), "([0-9]+)");

        int comparer = 0;

        for (int i = 0; comparer == 0 && i < splitX.Length; i++)
        {
            if (splitY.Length <= i)
            {
                comparer = 1; // x > y 
            }

            int numericX = -1;
            int numericY = -1;
            if (int.TryParse(splitX[i], out numericX))
            {
                if (int.TryParse(splitY[i], out numericY))
                {
                    comparer = numericX - numericY;
                }
                else
                {
                    comparer = 1; // x > y 
                }
            }
            else
            {
                comparer = String.Compare(splitX[i], splitY[i], comparisonMode);
            }
        }

        return comparer;
    }
}
