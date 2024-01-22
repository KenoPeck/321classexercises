using System;

namespace HelloWorldLL
{
    internal class LinkedListNode
    {
        LinkedListNode(int numInput)
        {
            num = numInput;
            next = null;
            prev = null;
        }

        private int num;
        private LinkedListNode? next;
        private LinkedListNode? prev;
    }
}
