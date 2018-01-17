using AandDS.Demo;
using AandDS.Week1;
using AandDS.Week6;
using AandDS.Week8;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AandDS
{
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
    }

    class MinHeap
    {
        int count = 0;
        int n = (int)1e6;
        int[] arr;

        public MinHeap()
        {
            arr = new int[n];
        }

        public void GetMin()
        {
            if (count == 0) Console.WriteLine("Empty");
            else Console.WriteLine(arr[0]);
        }

        public void Insert(int item)
        {
            arr[count++] = item;
            BalanceUp();
        }

        public void DeleteMin()
        {
            if (count == 0) return;
            int last = arr[count - 1];
            arr[0] = last;
            count--;
            BalanceDown();
        }

        private void BalanceUp()
        {
            for (int i = count - 1; i >= 0; i--)
            {
                int root = i / 2 - 1;
                if (root < 0) break;
                if (root > arr[i])
                {
                    int temp = arr[root];
                    arr[root] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        private void BalanceDown()
        {
            for (int i = 0; i < count; i++)
            {
                int left = 2 * i + 1;
                int right = left + 1;

                if (left < count)
                {
                    if (right < count)
                    {
                        int smallerIndex = left < right ? left : right;
                        if (arr[i] < arr[smallerIndex]) continue;
                        int temp = arr[smallerIndex];
                        arr[smallerIndex] = arr[i];
                        arr[i] = temp;
                    }
                    else
                    {
                        if (arr[i] < arr[left]) continue;
                        int temp = arr[left];
                        arr[left] = arr[i];
                        arr[i] = temp;
                    }
                }
                else break;
            }
        }
    }
    class Program
    {
        public static object BinaryNoAdj1s { get; private set; }

        static void Main(string[] args)
        {
            Node head1 = CreateList(new[] { 1, 1, 5, 4 });
            Node head2 = CreateList(new[] { 1, 4, 5, 6 });

            Node result = IDeserve.LList.SumRecursion(head1, head2);
            Print(result);

            //var arr = new int[] { -24, 0, 28, 28, 55, -31, -27, -45, -24 };
            //int end = 0;
            //int start = 0;
            //Week9.Assignments.Kadane(arr);

            //Dictionary<int, long> dict = new Dictionary<int, long>();
            //dict.Add(0, 1);
            //dict.Add(1, 1);
            //Console.WriteLine(Warmup.Assignments.Factorial(5, dict));
            //Console.WriteLine(Warmup.Assignments.Factorial(4, dict));


            //int testCases = Convert.ToInt32(Console.ReadLine());
            //while (testCases > 0)
            //{
            //    int size = Convert.ToInt32(Console.ReadLine());
            //    int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            //    Node root = CreateBST(arr, size);
            //    Console.WriteLine(IsCBT(root) ? "Yes" : "No");
            //    testCases--;
            //}

            //int testCases = Convert.ToInt32(Console.ReadLine());
            //while (testCases > 0)
            //{
            //    int size = Convert.ToInt32(Console.ReadLine());
            //    int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            //    Console.WriteLine(FindMissingNumber(arr, size));
            //    testCases--;
            //}
        }

        static void CreateLists(out Node head1, out Node head2)
        {
            Node n6 = new Node { Data = 9 };
            Node n5 = new Node { Data = 8, Next = n6 };
            Node n4 = new Node { Data = 6, Next = n5 };
            Node n3 = new Node { Data = 5, Next = n4 };
            Node n2 = new Node { Data = 4, Next = n3 };
            Node n1 = new Node { Data = 2, Next = n2 };
            n5.Next = n3;

            Node n24 = new Node { Data = 7 };
            Node n25 = new Node { Data = 3, Next = n24 };
            Node n26 = new Node { Data = 1, Next = n25 };

            head1 = n1;
            head2 = n26;
        }

        static Node CreateList(int[] arr)
        {
            Node temp = null;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                var node = new Node { Data = arr[i], Next = temp };
                temp = node;
            }
            return temp;
        }

        static void Print(Node head)
        {
            while (head != null)
            {
                Console.Write(head.Data + " --> ");
                head = head.Next;
            }
            Console.WriteLine();
        }

        static void PrintReverse(Node head)
        {
            if (head == null) return;
            PrintReverse(head.Next);
            Console.Write(head.Data + " --> ");
        }

        static Node Reverse(Node head)
        {
            if (head == null) return head;
            Node previous = null;
            while (head.Next != null)
            {
                head.Next = previous;
                previous = head.Next;
                head = head.Next.Next;
            }

            return previous;
        }
    }
}
