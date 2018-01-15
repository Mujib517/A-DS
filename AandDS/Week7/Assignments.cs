using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AandDS.Week7
{

    class Assignments
    {


        private static int maxLevel = 0;
        private static bool v1;
        private static bool v2;


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

        public static void PostOrder(Node root)
        {
            if (root == null) return;
            PostOrder(root.Left);
            PostOrder(root.Right);
            Console.Write(root.Data + " ");
        }
        public static void InOrder(Node root)
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
                BottomUpZigZag(root, 0, i);
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

        public static int lowestCommonAncestor(Node root, int p, int q)
        {
            if (root.Data > Math.Max(p, q))
            {
                return lowestCommonAncestor(root.Left, p, q);
            }
            else if (root.Data < Math.Min(p, q))
            {
                return lowestCommonAncestor(root.Right, p, q);
            }
            else
            {
                return root.Data;
            }
        }

        public static int LowestCommonAncestor(Node root, int u, int v)
        {
            while (root != null)
            {
                if (root.Data > u && root.Data < v) return root.Data;
                if (root.Data < u) root = root.Right;
                else root = root.Left;
            }
            return int.MinValue;
        }

        void PrintKDistDown(Node node, int k)
        {
            if (node == null || k < 0)
                return;

            if (k == 0)
            {
                Console.Write(node.Data);
                Console.WriteLine();
                return;
            }

            PrintKDistDown(node.Left, k - 1);
            PrintKDistDown(node.Right, k - 1);
        }

        int PrintkDistNode(Node node, Node target, int k)
        {
            if (node == null)
                return -1;

            if (node == target)
            {
                PrintKDistDown(node, k);
                return 0;
            }

            int dl = PrintkDistNode(node.Left, target, k);

            if (dl != -1)
            {

                if (dl + 1 == k)
                {
                    Console.Write(node.Data);
                    Console.WriteLine();
                }

                else
                    PrintKDistDown(node.Right, k - dl - 2);

                return 1 + dl;
            }

            int dr = PrintkDistNode(node.Right, target, k);
            if (dr != -1)
            {
                if (dr + 1 == k)
                {
                    Console.Write(node.Data);
                    Console.WriteLine();
                }
                else
                    PrintKDistDown(node.Left, k - dr - 2);
                return 1 + dr;
            }

            return -1;
        }
        private static Node Find(Node root, int x)
        {
            if (root == null) return null;
            if (root.Data == x) return root;
            if (x > root.Data) return Find(root.Right, x);
            return Find(root.Left, x);
        }

        public static long SumRootToLeaf(Node node, long val)
        {
            int largestPrime = (int)1e9 + 7;
            if (node == null)
                return 0;

            if (node.Data <= 9)
                val = (val * 10 + node.Data);
            else GetDigit(node.Data, ref val);

            if (node.Left == null && node.Right == null)
                return val % largestPrime;
            return SumRootToLeaf(node.Left, val) % largestPrime
                    + SumRootToLeaf(node.Right, val) % largestPrime;
        }

        public static void GetDigit(int num, ref long val)
        {
            if (num < 10)
            {
                val = (val * 10 + num);
                return;
            }
            else
            {

                GetDigit(num / 10, ref val);
                val = (val * 10 + num % 10);
            }
        }

        public static int NumberOfBST(int[] arr, int n)
        {
            int start = 0;
            int end = n - 1;
            int count = 0;
            while (start <= end)
            {
                if (IsBST(arr, start, start, end, int.MinValue, int.MaxValue)) count++;
                start++;
            }
            return count;
        }
        public static bool IsBST(int[] arr, int idx, int start, int end, int min, int max)
        {
            if (start > end || idx < start || idx > end) return false;
            if (idx >= arr.Length) return true;
            int elem = arr[idx];
            if (elem < min || elem > max) return false;
            return IsBST(arr, 2 * idx + 1, start, end, min, elem) && IsBST(arr, 2 * idx + 2, start, end, elem, max);
        }

        public static bool IsBST(int[] arr, int idx, int min, int max)
        {
            if (idx >= arr.Length) return true;
            int elem = arr[idx];
            if (elem < min || elem > max) return false;
            return IsBST(arr, 2 * idx + 1, min, elem) && IsBST(arr, 2 * idx + 2, elem, max);
        }

        public static Node ConstructBinaryTreeFromTraversals(int[] pre, int[] inorder, int n)
        {
            return Construct(pre, inorder, 0, 0, n - 1);
        }

        private static Node Construct(int[] pre, int[] inorder, int index, int start, int end)
        {
            if (start > end || index >= end) return null;

            Node tNode = new Node { Data = pre[index++] };
            if (start == end) return tNode;

            int inIndex = LinearSearch(inorder, tNode.Data, start, end);

            tNode.Left = Construct(inorder, pre, index, start, inIndex - 1);
            tNode.Right = Construct(inorder, pre, index, inIndex + 1, end);
            return tNode;
            //if (start > end || end < 0 || index >= pre.Length) return null;
            //Node root = new Node { Data = pre[index] };
            //int idx = LinearSearch(inorder, pre[index++], start, end);
            //root.Left = Construct(pre, inorder, index, start, idx - 1);
            //root.Right = Construct(pre, inorder, index + 1, idx + 1, end);
            //return root;
        }

        private static int LinearSearch(int[] inorder, int v, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (inorder[i] == v) return i;
            }
            return -1;
        }

        public static Node helper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
        {
            if (preStart > preorder.Length - 1 || inStart > inEnd || inEnd < 0)
            {
                return null;
            }
            Node root = new Node { Data = preorder[preStart++] };
            int inIndex = -1;
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == root.Data)
                {
                    inIndex = i;
                    break;
                }
            }
            root.Left = helper(preStart, inStart, inIndex - 1, preorder, inorder);
            root.Right = helper(preStart + inIndex - inStart, inIndex + 1, inEnd, preorder, inorder);
            return root;
        }

        public static Node CreateBinaryTree(int[] arr, int n)
        {
            if (arr.Length == 0) return null;
            Node root = new Node { Data = arr[0] };
            Node temp = root;
            int index = 1;

            while (temp != null && index < n)
            {
                Node child = new Node { Data = arr[index++] };
                temp.Left = child;

                if (index < n)
                {
                    temp.Right = new Node { Data = arr[index++] };
                }

                temp = temp.Left;
            }

            return root;
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
