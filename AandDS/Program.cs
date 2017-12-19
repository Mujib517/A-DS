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
            var arr = new[] { 5, 4, 3, 2, 1 };
            var list = CreateList(arr);
            var rList = Reverse(list);
            Print(rList);
            //PrintReverse(list);

            //int testCases = Convert.ToInt32(Console.ReadLine());
            //while (testCases > 0)
            //{
            //    int size = Convert.ToInt32(Console.ReadLine());
            //    int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            //    Console.WriteLine(FindMissingNumber(arr, size));
            //    testCases--;
            //}
        }

        // 1 --> 2 --> 3 --> 4 --> 5
        // 5 --> 4 --> 3 --> 2 --> 1

        //     4-5->null

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
