using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class LinkedList
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;

            int carry = 0;

            while (l1 != null || l2 != null || carry > 0)
            {
                int x = (l1 != null) ? l1.val : 0;
                int y = (l2 != null) ? l2.val : 0;

                int sum = x + y + carry;

                carry = sum / 10;

                curr.next = new ListNode(sum % 10);
                curr = curr.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            return dummy.next;
        }
    }

}
