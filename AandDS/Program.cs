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
            int[] arr = new[] { 92, 10, 963, 5, 334, 928, 973, 2, 9, 263, 860 };
            var arr2 = new[] { 156, 153, 6947, 149, 154, 1761, 7230, 9, 152 };
            var arr3 = new[] { 736, 43, 882, 3, 460, 741, 887, 0, 42, 247, 465, 739, 844, 886, 888 };
            var root = Week7.Assignments.CreateBinaryTree(arr, arr.Length);
            Console.WriteLine(Week7.Assignments.IsBST(arr,arr.Length));
            Console.WriteLine(Week7.Assignments.IsBST(arr2,arr2.Length));
            Console.WriteLine(Week7.Assignments.IsBST(arr3,arr3.Length));


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
