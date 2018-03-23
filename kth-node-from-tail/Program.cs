using System;

namespace kth_node_from_tail
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static Node GetKthNodeFromTail(Node head, int k)
        {
            if (head == null)
                return null;

            var fast = head;
            var count = k - 1;
            while (fast.Next != null && count >= 0)
            {
                count--;
                fast = fast.Next;
            }
            if (count > 0)
                return null;
            var slow = head;
            while (fast.Next != null)
            {
                fast = fast.Next;
                slow = slow.Next;
            }
            return slow;
        }
    }
}
