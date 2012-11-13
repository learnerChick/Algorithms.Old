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
            int[] arr = { 2, 4, 6, 8, 11, 32, 58, 199 };
            MinimalHeightBinaryTree minHeightTree = new MinimalHeightBinaryTree();
            Node<int> tree = minHeightTree.add(arr, 0, arr.Length - 1);
            
        }
    }
}
