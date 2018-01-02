using AandDS.Demo;
using AandDS.Week1;
using AandDS.Week6;
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
    class Program
    {

        static void Main(string[] args)
        {
            int[,] arr = new[,] {
                { -2, -3, -6, -5, 50, 3 },
                { 8, 7, 10, -5, -3, 30 },
                { 6    , 3 ,  70,  9, - 20, - 7 },
                { -9  ,  9, - 6,  7 ,  3 ,  2 },
                {-1 ,    7,   7,   6,   -4,  3  },
                { 8,5  , 6  , -9 , 40,  8} };

            Warmup.Assignments.DiagnolSum(arr, 6);

            //int testCases = Convert.ToInt32(Console.ReadLine());
            //while (testCases > 0)
            //{
            //    int size = Convert.ToInt32(Console.ReadLine());
            //    int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            //    Node root = CreateBST(arr, size);
            //    Console.WriteLine(IsCBT(root) ? "Yes" : "No");
            //    testCases--;
            //}

            //3 2 4  null 1  5 null

            //3 4 2 5 1 

            // 3 4 2  null 1 5


            //int testCases = Convert.ToInt32(Console.ReadLine());
            //while (testCases > 0)
            //{
            //    int size = Convert.ToInt32(Console.ReadLine());
            //    int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            //    Console.WriteLine(FindMissingNumber(arr, size));
            //    testCases--;
            //}
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
