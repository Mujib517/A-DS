﻿using System;
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
        public static void ZigZagLevelOrder(Node root)
        {
            if (root == null) return;

            Stack<Node> s1 = new Stack<Node>();
            Stack<Node> s2 = new Stack<Node>();

            s1.Push(root);

            while (s1.Count != 0 || s2.Count != 0)
            {
                while (s1.Count != 0)
                {
                    Node node = s1.Pop();
                    Console.Write(node.Data + " ");
                    if (node.Right != null) s2.Push(node.Right);
                    if (node.Left != null) s2.Push(node.Left);
                }

                while (s2.Count != 0)
                {
                    Node node = s2.Pop();
                    Console.Write(node.Data + " ");

                    if (node.Left != null) s1.Push(node.Left);
                    if (node.Right != null) s1.Push(node.Right);
                }
            }
        }

        public static bool IsFBT(Node root)
        {
            if (root == null) return true;
            if ((root.Left == null && root.Right != null) || (root.Left != null && root.Right == null)) return false;
            return IsFBT(root.Left) && IsFBT(root.Right);
        }

        public static bool IsCBT(Node root, int i, int n)
        {
            if (root == null) return true;
            if (root.Left != null && 2 * i + 1 >= n || IsCBT(root.Left, 2 * i + 1, n)) return false;
            if (root.Right != null && 2 * i + 2 >= n || IsCBT(root.Right, 2 * i + 2, n)) return false;
            return true;
        }

        public static void LeftView(Node root)
        {
            LeftView(root, 1);
        }

        public static void RightView(Node root)
        {
            RightView(root, 1);
        }

        private static void RightView(Node root, int level)
        {
            if (root == null) return;
            if (maxLevel < level)
            {
                Console.Write(root.Data + " ");
                maxLevel = level;
            }
            RightView(root.Right, level + 1);
            RightView(root.Left, level + 1);
        }

        private static int maxLevel = 0;

        private static void LeftView(Node root, int level)
        {
            if (root == null) return;
            if (maxLevel < level)
            {
                Console.Write(root.Data + " ");
                maxLevel = level;
            }
            LeftView(root.Left, level + 1);
            LeftView(root.Right, level + 1);
        }

        public static bool IsBalnaced(Node root)
        {
            if (root == null) return true;
            return (Math.Abs(Height(root.Left) - Height(root.Right)) <= 1) && IsBalnaced(root.Left) && IsBalnaced(root.Right);
        }

        //root left 2*i
        //root right 2i+1
        public static bool IsBST(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int root = arr[i];
                if (2 * i + 1 < n)
                {
                    int left = arr[2 * i + 1];
                    if (root < left) return false;
                }
                if (2 * i + 2 < n)
                {
                    int right = arr[2 * i + 2];
                    if (root > right) return false;
                }
            }
            return true;
        }

        public static void VerticalOrder(Node root)
        {
            int min = 0, max = 0;
            GetHorizontalDistance(root, ref min, ref max, 0);

            for (int i = min; i <= max; i++)
            {
                PrintVOrder(root, i, 0);
                Console.WriteLine();
            }

        }

        private static void PrintVOrder(Node root, int vLine, int hDistance)
        {
            if (root == null) return;
            if (hDistance == vLine) Console.Write(root.Data + " ");

            PrintVOrder(root.Left, vLine, hDistance - 1);
            PrintVOrder(root.Right, vLine, hDistance + 1);
        }

        private static void GetHorizontalDistance(Node root, ref int min, ref int max, int current)
        {
            if (root == null) return;
            if (current < min) min = current;
            if (current > max) max = current;

            GetHorizontalDistance(root.Left, ref min, ref max, current - 1);
            GetHorizontalDistance(root.Right, ref min, ref max, current + 1);
        }

        public static void BottomUpLevelOrder(Node root)
        {
            int height = Height(root);
            for (int i = height; i >= 0; i--)
            {
                BottomUpLevelOrder(root, 0, i);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private static void BottomUpLevelOrder(Node root, int current, int height)
        {
            if (root == null) return;
            if (current == height) Console.Write(root.Data + " ");
            BottomUpLevelOrder(root.Left, current + 1, height);
            BottomUpLevelOrder(root.Right, current + 1, height);
        }

        public static void BottmUpZigZag(Node root)
        {
            int h = Height(root);
            bool direction = false;
            for (int i = h; i >= 0; i--)
            {
                BottomUpZigZag(root, 0, i, direction);
                direction = !direction;
            }
            Console.WriteLine();
        }

        private static void BottomUpZigZag(Node root, int current, int height)
        {
            if (root == null) return;

            if (current == height) Console.Write(root.Data + " ");
            if (height % 2 == 0)
            {
                BottomUpZigZag(root.Left, current + 1, height);
                BottomUpZigZag(root.Right, current + 1, height);
            }
            else
            {
                BottomUpZigZag(root.Right, current + 1, height);
                BottomUpZigZag(root.Left, current + 1, height);
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
