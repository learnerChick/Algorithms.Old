using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /*
     * 1.  If current node is null or one of the nodes we need to find for LCA is null, then return null.
     * 2.  If both nodes are present in left subtree, call left subtree.  Repeat for right subtree.
     */

    public static class LowestCommonAncestor
    {
        public static Node<int> FindCommonAncestor(BST<int> tree, int i, int j)
        {
            //if either node is root, there cannot be a common parent
            if (tree.getRoot().Element == i || tree.getRoot().Element == j)
            {
                return null;
            }
            return FindCommonAncestor(tree.getRoot(), i, j);
        }

        public static Node<int> FindCommonAncestor(Node<int> node, int i, int j)
        {
            
            if (Contains(node.Left, i) && Contains(node.Left, j))
            {
                return FindCommonAncestor(node.Left, i, j);
            }

            if (Contains(node.Right, i) && Contains(node.Right, j))
            {
                return FindCommonAncestor(node.Right, i, j);
            }

            return node;
        }

        private static Boolean Contains(Node<int> node, int elem)
        {
            if (node == null)
            {
                return false;
            }
            else if (node.Element == elem)
            {
                return true;
            }
            else
            {
                return Contains(node.Left, elem) ||
                    Contains(node.Right, elem);
            }
        }

        public static void main()
        {
            BST<int> bst = new BST<int>();
            bst.add(20);
            bst.add(8);
            bst.add(22);
            bst.add(4);
            bst.add(12);
            bst.add(10);
            bst.add(14);


            //bst.breadthFirstTraversal();

            Node<int> node = LowestCommonAncestor.FindCommonAncestor(bst, 4, 14);
            Console.WriteLine(node.Element);

            Node<int> node2 = LowestCommonAncestor.FindCommonAncestor(bst, 12, 300);
            Console.WriteLine(node2.Element);

            //Node<int> node3 = LeastCommonAncestor.FindCommonAncestor(bst, 30, 31);
            // Console.WriteLine(node3.Element);
        }
    }
}
