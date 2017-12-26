using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Week7
{

    class Assignments
    {
        public static void TreeTraversals(int[] arr, int n)
        {
            Node root = CreateBST(arr, n);
            PreOrder(root);
            Console.WriteLine();
            InOrder(root);
            Console.WriteLine();
            PostOrder(root);
            Console.WriteLine();
        }

        private static void PostOrder(Node root)
        {
            if (root == null) return;
            PostOrder(root.Left);
            PostOrder(root.Right);
            Console.Write(root.Data + " ");
        }
        private static void InOrder(Node root)
        {
            if (root == null) return;
            InOrder(root.Left);
            Console.Write(root.Data + " ");
            InOrder(root.Right);
        }
        public static void PreOrder(Node root)
        {
            if (root == null) return;
            Console.Write(root.Data + " ");
            PreOrder(root.Left);
            PreOrder(root.Right);
        }
        public static int Height(Node root)
        {
            if (root == null) return -1;
            return 1 + Math.Max(Height(root.Left), Height(root.Right));
        }
        public static void LevelOrder(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            q.Enqueue(null);

            while (q.Count != 0)
            {
                Node node = q.Dequeue();
                if (node == null)
                {
                    Console.WriteLine();
                    if (q.Count != 0) q.Enqueue(null);
                }
                else
                {
                    if (node.Left != null) q.Enqueue(node.Left);
                    if (node.Right != null) q.Enqueue(node.Right);
                    Console.Write(node.Data + " ");
                }
            }
        }
        public static int Depth(Node root, int val, int depth)
        {
            if (root == null) return depth;

            if (val < root.Data) return Depth(root.Left, val, ++depth);
            if (val > root.Data) return Depth(root.Right, val, ++depth);
            else return depth;
        }

        public static void LevelOrderBottomUp(Node root, int nodeCount)
        {
            List<Node> list = new List<Node>();
            Node temp = root;
            list.Add(temp);
            list.Add(null);

            while (temp != null)
            {
                if (temp.Right != null) list.Add(temp.Right);
                if (temp.Left != null) list.Add(temp.Left);

                temp = list[list.Count - 1];
                list.Add(null);
            }

            for (int i = list.Count - 1; i >= 0; i--)
            {
                Node node = list[i];
                if (node == null) Console.WriteLine();
                else Console.Write(node.Data + " ");
            }
        }
        public static Node CreateBST(int[] arr, int n)
        {
            Node root = new Node { Data = arr[0] };

            for (int i = 1; i < n; i++)
            {
                Node temp = root;
                while (temp != null)
                {
                    if (arr[i] < temp.Data)
                    {
                        if (temp.Left == null)
                        {
                            temp.Left = new Node
                            {
                                Data = arr[i]
                            };
                            break;
                        }
                        temp = temp.Left;
                    }
                    else
                    {
                        if (temp.Right == null)
                        {
                            temp.Right = new Node { Data = arr[i] };
                            break;
                        }
                        temp = temp.Right;
                    }
                }

            }

            return root;
        }
        public class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
    }
}
