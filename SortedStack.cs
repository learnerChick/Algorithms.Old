using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class SortedStack
    {
        private Stack tempStack;

        public SortedStack()
        {
            tempStack = new Stack();
        }

        public Stack sort(Stack s)
        {
            while (!s.isEmpty())
            {
                int tmp = s.pop();
                while (!tempStack.isEmpty() && tempStack.peek() > tmp)
                {
                    s.push(tempStack.pop());
                }
                tempStack.push(tmp);
            }
            return tempStack;
        }

        public void print(Stack s){
            while (!s.isEmpty())
            {
                Console.WriteLine(s.pop());
            }
        }


        public static void main()
        {
            SortedStack sorter = new SortedStack();
            Stack s = new Stack();
            s.push(10);
            s.push(12);
            s.push(4);
            s.push(22);
            s.push(3);
            s.push(153);
            Stack sorted = sorter.sort(s);
            sorter.print(sorted);
        }
    }
}
