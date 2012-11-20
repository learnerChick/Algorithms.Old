using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{

    /*
     *  Think about in order traversal.
     *  If the node you're currently on has a right subtree, then, the successor must be the min of the right subtree. (same as remove min).
     *  If no right subtree, go up the tree using parent nodes until you reach a node that is a left child.  The parent of this node is the successor.
     *  Basically, go up the tree and check if the parent is null and if the current node == parent.right.  Keep going until this fails.
     *  Time complexity: O(h) - height of tree.
     */

    public class BSTSuccessor<T>{
        
        public  Node<T> successor(BST<T> tree, Node<T> node)
        {
            if (node.Right != null)
            {
                return tree.findMin(node.Right);
            }
            else
            {
                Node<T> parent = node.Parent;
                while (parent != null && node == parent.Right)
                {
                    node = parent;
                    parent = parent.Parent;
                }
                return parent;
            }
        }

        public static void main()
        {
            BST<int> binTree = new BST<int>();
            binTree.add(20);
            binTree.add(8);
            binTree.add(22);
            binTree.add(4);
            binTree.add(12);
            binTree.add(10);
            binTree.add(14);
            BSTSuccessor<int> succ = new BSTSuccessor<int>();
            Node<int> node = succ.successor(binTree, binTree.getRoot().Left.Right.Left);
            Console.Write(node.Element);
        }


     }

}