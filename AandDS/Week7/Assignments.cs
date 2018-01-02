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
        public static bool IsBST(Node root, int min, int max)
        {
            if (root == null) return true;
            if (root.Data >= max || root.Data <= min) return false;

            return IsBST(root.Left, min, root.Data) && IsBST(root.Right, root.Data, max);
        }

        public static bool IsBST(int[] arr, int n)
        {
            Stack<int> stack = new Stack<int>();

            int lower = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                int data = arr[i];

                if (data < lower) return false;


                while (stack.Count != 0 && stack.Peek() < data)
                {
                    lower = stack.Peek();
                    stack.Pop();
                }
                stack.Push(data);
            }
            return true;
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

        public static Node CreateBinaryTree(int[] arr, int n)
        {
            Node root = null;
            Node temp = null;

            for (int i = 0; i < n; i++)
            {
                temp = new Node { Data = arr[i] };
                if (i == 0) root = temp;
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                if (left < n) temp.Left = new Node { Data = arr[left] };
                if (right < n) temp.Right = new Node { Data = arr[right] };
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
