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
            GenericArrayStack<int> s = new GenericArrayStack<int>();
            s.push(10);
            s.push(20);
            s.push(222);
            s.pop();
            Console.WriteLine(s.ToString());
            s.push(45);
            Console.WriteLine(s.ToString());
        }
    }
}
