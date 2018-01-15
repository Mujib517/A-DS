using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.IDeserve
{
    class LList
    {
        static Node head = null;
        public static Node Reverse(Node current, Node prev)
        {
            if (current == null) return prev;
            Node next = current.Next;
            current.Next = prev;
            prev = current;
            return Reverse(next, prev);
        }
        public static Node ReverseIterative(Node head)
        {
            Node previous = null;
            while (head != null)
            {
                Node next = head.Next;
                head.Next = previous;
                previous = head;
                head = next;
            }

            return previous;
        }

        //O(M+N)
        public static Node MergePoint(Node head1, Node head2)
        {
            int l1 = Length(head1);  //O(M)
            int l2 = Length(head2);  // O(N)

            if (l2 > l1)
            {
                Node temp = head1;
                head1 = head2;
                head2 = temp;
            }

            int diff = Math.Abs(l1 - l2);
            while (diff > 0 && head1 != null)
            {
                head1 = head1.Next;
                diff--;
            }

            return GetMergeNode(head1, head2);
        }

        public static Node MergeLists(Node head1, Node head2)
        {
            Node dummy = new Node { };
            Node temp = dummy;

            while (head1 != null && head2 != null)
            {
                if (head1.Data < head2.Data)
                {
                    dummy.Next = head1;
                    head1 = head1.Next;
                }
                else
                {
                    dummy.Next = head2;
                    head2 = head2.Next;
                }
                dummy = dummy.Next;
            }

            Append(head1, dummy);
            Append(head2, dummy);

            return temp.Next;
        }

        //not working.
        public static Node FindLoop(Node head1)
        {
            if (head1 == null) return head1;
            Node fast = head1;
            Node slow = head1;

            while (slow != null && fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast) return slow;
            }
            return null;
        }

        //O(N)==O(N)+O(N-K)
        public static Node FindNthNodeReverse(Node head, int k)
        {
            int len = Length(head);  //O(N)
            while (len > 0)  //O(N-k)
            {
                if (len == k) return head;
                head = head.Next;
                len--;
            }
            return null;
        }

        public static Node TreeToLList(Week7.Assignments.Node root, Node hd, LinkedList<Node> list)
        {
            if (root == null) return hd;

            TreeToLList(root.Left, hd, list);
            hd.Next = new Node { Data = root.Data };
            hd = hd.Next;
            list.AddLast(hd);
            TreeToLList(root.Right, hd, list);

            return head;
        }

        public static Node ReverseKNodes(Node head, int k)
        {
            int count = k;
            Node prev = null;
            Node temp = head;

            while (head != null)
            {
                Node next = head.Next;
                if (count > 0)
                {
                    head.Next = prev;
                    prev = next;
                    head = next;
                    count--;
                }
                else
                {
                    temp.Next = head;
                    head = head.Next;
                }
            }
            return head;
        }

        public static Node Sum(Node head1, Node head2, Node prev = null)
        {
            if (head1 == null && head2 == null) return prev;
            prev = head1;
            Sum(head1.Next, head2.Next, prev);
            head1.Data += head2.Data;
            return prev;
        }

        #region
        private static void Append(Node head, Node dummy)
        {
            while (head != null)
            {
                dummy.Next = head;
                head = head.Next;
                dummy = dummy.Next;
            }
        }
        private static int Length(Node head)
        {
            int count = 0;
            while (head != null)
            {
                head = head.Next;
                count++;
            }
            return count;
        }
        private static Node GetMergeNode(Node head1, Node head2)
        {
            while (head1 != null && head2 != null)
            {
                if (head1 == head2) return head1;
                head1 = head1.Next;
                head2 = head2.Next;
            }
            return null;
        }
        #endregion
    }
}
