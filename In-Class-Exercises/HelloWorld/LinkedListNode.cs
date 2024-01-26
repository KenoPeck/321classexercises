using System;

namespace HelloWorldLL
{
    internal class LinkedListNode
    {
        public LinkedListNode(int numInput)
        {
            Num = numInput;
            Next = null;
        }

        internal int Num { get; set; }

        public LinkedListNode? Next { get; set; }

        

    }
}
