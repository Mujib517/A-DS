using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Week6
{
    class Data
    {
        public int Value { get; set; }
        public int Max { get; set; }
    }
    class Assignments
    {
        private static Stack<Data> stack = new Stack<Data>();


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

        static void Process(string[] arr)
        {
            switch (arr[0])
            {
                case "A":
                    var value = Convert.ToInt32(arr[1]);
                    var data = new Data { Value = value };
                    if (stack.Count == 0) data.Max = value;
                    else
                    {
                        var top = stack.Peek();
                        data.Max = top.Max > value ? top.Max : value;
                    }
                    stack.Push(data);
                    break;
                case "R":
                    if (stack.Count != 0) stack.Pop();
                    break;
                case "Q":
                    if (stack.Count == 0) Console.WriteLine("Empty");
                    else Console.WriteLine(stack.Peek().Max);
                    break;
            }
        }

        public static int LargestRect(int[] arr, int n)
        {
            var max = 0;
            var area = 0;
            var stack = new Stack<int>();

            int i = 0;

            while (i < n)
            {
                if (stack.Count == 0 || arr[stack.Peek()] <= arr[i])
                    stack.Push(i++);
                else
                {
                    var top = stack.Pop();
                    area = arr[top] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
                    if (area > max) max = area;
                }
            }

            while (stack.Count != 0)
            {
                var top = stack.Pop();
                area = arr[top] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
                if (area > max) max = area;
            }
            return max;
        }

        public static int HighestElemInWindow(int[] arr, int n, int k)
        {
            var count = 0;
            for (int i = 0; i < n - k + 1; i++)
            {
                var max = int.MinValue;
                for (int j = i; j < i + k; j++)
                {
                    if (arr[j] > max) max = arr[j];
                }
                count += max;
            }
            return count;
        }

        private static void EnQ(LinkedList<Data> q, int val)
        {
            var max = val;

            if (q.Count != 0)
            {
                var top = q.Last.Value;
                max = top.Max > val ? top.Max : val;
            }

            q.AddLast(new Data { Value = val, Max = max });
        }

        public static void ChangingDirectories(Stack<Dir> stack, string[] commands)
        {
            switch (commands[0])
            {
                case "cd":
                    Push(stack, commands[1]);
                    break;
                case "pwd":
                    if (stack.Count == 0) Console.WriteLine("/");

                    else
                    {
                        var path = stack.Peek().FullPath;
                        Console.WriteLine((path + "/").Replace("//", "/"));
                    }
                    break;
            }
        }

        private static void Push(Stack<Dir> stack, string str)
        {
            if (str.StartsWith("/"))
            {
                stack.Clear();
                stack.Push(new Dir { Name = "/", FullPath = "/" });
            }
            var dirs = str.Split('/');

            foreach (var dir in dirs)
            {
                if (dir == "..") stack.Pop();
                else if (dir != "")
                {
                    var currentDir = new Dir
                    {
                        Name = dir
                    };
                    if (stack.Count == 0) currentDir.FullPath = dir;
                    else currentDir.FullPath = stack.Peek().FullPath + "/" + currentDir.Name;
                    stack.Push(currentDir);
                }
            }
        }

        public static void StockSpan(int[] arr, int n)
        {
            var result = new int[n];

            result[0] = 1;
            for (int i = 1; i < n; i++)
            {
                result[i] = 1;
                for (int j = i - 1; (j >= 0) && (arr[i] >= arr[j]); j--)
                    result[i]++;
            }

            foreach (var item in result) Console.Write(item + " ");
            Console.WriteLine();
        }

        static void StockSpan2(int[] arr, int n, int S[])
        {
            Stack<int> st = new Stack<int>();
            int[] result = new int[n];
            st.Push(0);

            result[0] = 1;

            for (int i = 1; i < n; i++)
            {
                while (st.Count!=0 && arr[st.Peek()] <= arr[i])
                    st.Pop();

                result[i] = (st.Count==0) ? (i + 1) : (i - st.Peek());
                st.Push(i);
            }
        }
    }

    public class Dir
    {
        public string FullPath { get; set; }
        public string Name { get; set; }
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

    class CustomQueue
    {
        private LinkedList<int> list = new LinkedList<int>();

        public void EnQueue(int x)
        {
            list.AddLast(x);
        }

        public void DeQueue()
        {
            if (list.Count == 0) Console.WriteLine("Empty");
            else
            {
                Console.WriteLine(list.First.Value);
                list.RemoveFirst();
            }
        }

        static void Process(string[] tokens, Stack<int> stack)
        {
            switch (tokens[0])
            {
                case "A":
                    stack.Push(Convert.ToInt32(tokens[1]));
                    break;
                case "Q":
                    Console.WriteLine(stack.Count == 0 ? "Empty" : stack.Peek().ToString());
                    break;
                case "R":
                    stack.Pop();
                    break;
            }
        }
    }
}
