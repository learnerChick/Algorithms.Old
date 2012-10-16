using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Algorithms
{
    class MyQueue
    {
        private int activeStack = 0;
        private int inactiveStack = 1;
        private Stack[] stacks;
        private int n;

        public MyQueue()
        {
            n = 0;
            stacks = new Stack[2];
            stacks[activeStack] = new Stack();
            stacks[inactiveStack] = new Stack();
        }

        public Boolean isEmpty()
        {
            return n == 0;
        }

        public void enqueue(int item)
        {
            stacks[activeStack].push(item);
            n++;
        }

        public int dequeue()
        {
            if(stacks[activeStack].isEmpty()){
                throw new Exception("Queue is empty");

            }
            while(!stacks[activeStack].isEmpty()){
                stacks[inactiveStack].push(stacks[activeStack].pop());
            }

            int item = stacks[inactiveStack].pop();
            n--;

            while (!stacks[inactiveStack].isEmpty())
            {
                stacks[activeStack].push(stacks[inactiveStack].pop());
            }

            return item;
        }

        public static void main(){
            MyQueue q = new MyQueue();
            q.enqueue(10);
            q.enqueue(122);
            q.enqueue(103);
            q.enqueue(5);
            q.enqueue(3);
            Console.WriteLine(q.dequeue());
            q.enqueue(4);
            Console.WriteLine(q);
        }
    }
}
