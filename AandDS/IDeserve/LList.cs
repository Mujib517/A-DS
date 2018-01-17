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

        public static Node SumUsingStacks(Node head1, Node head2)
        {
            Node result = new Node { Data = int.MinValue };

            Node temp = result;

            Stack<int> stack1 = AddToStack(head1);
            Stack<int> stack2 = AddToStack(head2);
            Stack<int> stack3 = new Stack<int>();
            int carry = 0;
            while (stack1.Count != 0 || stack2.Count != 0)
            {
                int a = 0;
                int b = 0;

                if (stack1.Count != 0) a = stack1.Pop();
                if (stack2.Count != 0) b = stack2.Pop();
                int sum = (a + b + carry) % 10;
                carry = (a + b + carry) / 10;
                stack3.Push(sum);
            }

            if (carry != 0) stack3.Push(carry);

            while (stack3.Count != 0)
            {
                result.Next = new Node { Data = stack3.Pop() };
                result = result.Next;
            }

            return temp.Next;
        }

        private static Stack<int> AddToStack(Node head)
        {
            Stack<int> stack = new Stack<int>();
            while (head != null)
            {
                stack.Push(head.Data);
                head = head.Next;
            }
            return stack;
        }


        public static Node ReverseTest(Node head)
        {
            if (head.Next == null) return head;
            return ReverseTest(head.Next);
        }


        public static Node SumRecursion(Node head1, Node head2)
        {
            head = new Node { Data = int.MinValue };
            Node result = head;
            SumRecursionUtil(head1, head2);
            if (carry > 0) head.Next = new Node { Data = carry };
            return ReverseIterative(result.Next);
        }

        static int carry = 0;

        public static void SumRecursionUtil(Node head1, Node head2)
        {
            if (head1 == null) return;

            SumRecursionUtil(head1.Next, head2.Next);
            int value = (head1.Data + head2.Data + carry) % 10;
            carry = (head1.Data + head2.Data + carry) / 10;
            head.Next = new Node { Data = value };
            head = head.Next;
        }

        public static void Print(Node head)
        {
            if (head == null) return;
            Print(head.Next);
            Console.Write(head.Data + " ");
        }
        private static Node SumRecursion(Node head1, Node head2, Node result, int carry)
        {
            if (head1 == null) return null;

            int a = head1.Data;
            int b = head2.Data;
            int c = (a + b + carry) % 10;
            carry = (a + b + carry) / 10;
            result.Next = new Node { Data = c };
            return SumRecursion(head1.Next, head2.Next, result.Next, carry);

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
