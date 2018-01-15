

using System;
using System.Collections.Generic;

namespace AandDS.Week8
{
    class Assignments
    {
        public bool IsBST(Week7.Assignments.Node root, int min, int max)
        {
            if (root == null) return true;
            if (root.Data < min || root.Data > max) return false;
            return IsBST(root.Left, min, root.Data) && IsBST(root.Right, root.Data, max);
        }

        public static int Diameter(Week7.Assignments.Node root)
        {
            if (root == null) return 0;

            int lh = Height(root.Left);
            int rh = Height(root.Right);

            int ld = Diameter(root.Left);
            int rd = Diameter(root.Right);

            return Math.Max(lh + rh + 1, Math.Max(ld, rd));
        }

        public static int Height(Week7.Assignments.Node root)
        {
            if (root == null) return -1;
            return Math.Max(Height(root.Left), Height(root.Right)) + 1;
        }
    }

    class MinHeap
    {
        private List<int> list = new List<int>((int)1e6);

        public void Insert(int item)
        {
            list.Add(item);
            BalanceUp();
        }

        public int GetMin()
        {
            return list.Count > 0 ? list[0] : int.MinValue;
        }

        public void DeleteMin()
        {
            if (list.Count > 0)
            {
                list[0] = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                Balance();
            }
        }

        private void Balance()
        {
            for (int i = 0; i < list.Count; i++)
            {
                int left = 2 * i + 1;
                int right = left + 1;
                int n = list.Count;

                if (left < n)
                {
                    if (right < n)
                    {
                        int smallerIndex = left < right ? left : right;
                        if (list[i] < list[smallerIndex]) continue;
                        int temp = list[smallerIndex];
                        list[smallerIndex] = list[i];
                        list[i] = temp;
                    }
                    else
                    {
                        if (list[i] < list[left]) continue;
                        int temp = list[left];
                        list[left] = list[i];
                        list[i] = temp;
                    }
                }
                else break;
            }
        }

        private void BalanceUp()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int root = i / 2 - 1;
                if (root < 0) break;
                if (root > list[i])
                {
                    int temp = list[root];
                    list[root] = list[i];
                    list[i] = temp;
                }
            }
        }
    }
}
