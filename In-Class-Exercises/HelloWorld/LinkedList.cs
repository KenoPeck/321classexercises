using System;

namespace HelloWorldLL
{
    internal class LinkedList
    {
        public LinkedList()
        {
            head = null;
        }

        public LinkedListNode? Head
        { get; set; }

        public void Insert(int numInput)
        {
            if (Head == null)
            {
                Head = new LinkedListNode(numInput);
            }
            else
            {
                LinkedListNode? current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new LinkedListNode(numInput);
            }
        }

        public int Add()
        {
            if(Head != null && Head.Next != null)
            {
                return Head.Num + Head.Next.Num;

            }
            else
            {
                return 0;
            }
        }

        
        private LinkedListNode? head;
    }
}
