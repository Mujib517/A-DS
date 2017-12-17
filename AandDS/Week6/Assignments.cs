using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Week6
{
    class Assignments
    {
        static void Reverse(string[] arr)
        {
            Stack<string> stack = new Stack<string>();
            foreach (var word in arr)
            {
                stack.Push(word);
            }

            while (stack.Count != 0) Console.Write(stack.Pop() + " ");
            Console.WriteLine();
        }
    }

    class CustomStack
    {

        private int[] arr = new int[201];
        private int count = -1;

        public void Push(int x)
        {
            arr[++count] = x;
        }

        public void Pop()
        {
            if (count == -1) Console.WriteLine("Empty");
            else Console.WriteLine(arr[count--]);
        }
    }
}
