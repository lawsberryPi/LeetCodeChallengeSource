using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic.LinkedListOperation
{
    public class LinkedListOperation
    {
        private readonly ListNode _node;
        public LinkedListOperation()
        {
            var _node = new ListNode(1);
            _node.next = new ListNode(2);
            _node.next.next = new ListNode(3);
            _node.next.next.next = new ListNode(4);
            _node.next.next.next.next = new ListNode(4);

        }
        public void DeleteNode(ListNode node)
        {
            ListNode currentNode  = _node;
            while(currentNode.next != null)
            {
                if(currentNode.val == node.val)
                {
                    currentNode.val = currentNode.next.val;
                    currentNode.next = currentNode.next.next;
                }
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
