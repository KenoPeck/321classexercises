using System;

namespace HelloWorldLL
{
    internal class LinkedList
    {
        LinkedList()
        {
            head = null;
        }

        public LinkedListNode? Head
        { get; set; }

        
        private LinkedListNode? head;
    }
}
