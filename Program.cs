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
            BST<int> bst = new BST<int>();
            bst.add(200);
            bst.add(1);
            bst.add(31);
            bst.add(4);
            bst.add(500);
            //Console.WriteLine(bst.find(31).Element);
            //Console.WriteLine(bst.remove(31).Element);
            //Console.WriteLine(bst.findMax().Element);
            //bst.inorderTraversal();  /* 1 4 31 200 500 */
            //bst.postorderTraversal();  /* 4 31 1 500 200 */
            bst.breadthFirstTraversal();  /* 200 1 31 4 500 */
        }
    }
}
