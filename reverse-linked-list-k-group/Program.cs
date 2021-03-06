﻿using System;

namespace reverse_linked_list_k_group
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            var result = ReverseKGroup(head, 2);

            while (result != null)
            {
                System.Console.Write(result.val + "-->");
                result = result.next;
            }
        }

        private static ListNode ReverseKGroup(ListNode head, int k)
        {
            var node = head;
            var count = 0;

            while (count < k)
            {
                if (node == null)
                    return head;
                node = node.next;
                count++;
            }
            //up to this point, if there are less than k nodes left, do nothing;
            // if there are enough nodes, count == k

            var pre = ReverseKGroup(node, k);
            // pre is now pointing to the first node right to the k range
            while (count > 0)
            {
                var next = head.next;
                head.next = pre;
                pre = head;
                head = next;
                count--;
            }

            return pre;
        }
    }
}
