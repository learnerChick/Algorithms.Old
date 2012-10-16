using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
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
