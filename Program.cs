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
            Stack s = new Stack();
            s.push(19);
            s.push(10);
            s.push(11);
            s.pop();
            Console.Write(s.peek());
        }
    }
}
