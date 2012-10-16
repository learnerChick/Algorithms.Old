using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Stack
    {
        private Node top;
        private int n;

        private sealed class Node
        {
            public Node next { get; set; }
            public int item { get; set; }

        }

        public Stack()
        {
            n = 0;
        }

        public void push(int item)
        {
            Node newItem = new Node();
            newItem.item = item;
            newItem.next = top;
            top = newItem;
            n++;
        }

        public int pop()
        {
            if (n == 0)
            {
                throw new Exception("Stack underflow");
            }

            int toBeRemoved = top.item;
            top = top.next;
            n--;
            return toBeRemoved;
        }

        public int peek()
        {
            if (n == 0)
            {
                throw new Exception("Stack underflow");
            }
            return top.item;
        }

        public int size()
        {
            return n;
        }

        public static void main()
        {
            Stack s = new Stack();
            s.push(19);
            s.push(10);
            s.push(11);
            s.pop();
            s.peek();
        }
    }
}
