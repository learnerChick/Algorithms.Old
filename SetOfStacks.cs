using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace Algorithms
{
    public class SetOfStacks
    {
        private int pointer;
        private int totalStack;
        private int totalItemsInStack;
        private List<Stack<int>> list;
        private int totalItems;

        public SetOfStacks()
        {
            pointer = 0;
            totalStack = 0;
            totalItems = 0;
            totalItemsInStack = 2;
            list = new List<Stack<int>>();
        }

        public void push(int num)
        {
            if (pointer >= totalItemsInStack || totalItems == 0)
            {
                Stack<int> s = new Stack<int>();
                s.Push(num);
                pointer = 1;
                totalStack++;
                list.Add(s);
            }
            else
            {
                list[totalStack - 1].Push(num);
                pointer++;
            }
            totalItems++;
        }

        public int pop()
        {
            if (totalItems == 0)
            {
                throw new Exception("Stack underflow");
            }

            int item = list.ElementAt(totalStack - 1).Pop();
            pointer--;
            if (pointer <= 0)
            {
                totalStack--;
                pointer = totalItemsInStack;
            }
            else
            {
                pointer--;
            }

            totalItems--;
            return item;
        }

        public int peek()
        {
            if (totalItems == 0)
            {
                throw new Exception("Stack underflow");
            }
            return list[totalStack - 1].Peek();
        }

        public static void Main()
        {
            SetOfStacks s = new SetOfStacks();
            s.push(10);
            s.push(5);
            s.push(3);
            s.push(29);
            s.push(34);
            s.pop();
            s.pop();
            s.pop();
            s.pop();
            int p = s.peek();
            Console.Write(p);
        }
    }
}