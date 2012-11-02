using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return FindCommonAncestor(tree.getRoot(), i, j);
        }

        public static Node<int> FindCommonAncestor(Node<int> node, int i, int j)
        {

            if (node == null)
            {
                return null;
            }
            else if (node.Left != null && (node.Left.Element == i || node.Left.Element == j))
            {
                return node;
            }
            else if (node.Right != null && (node.Right.Element == i || node.Right.Element == j))
            {
                return node;
            }

            else
            {
                Node<int> left = FindCommonAncestor(node.Left, i, j);
                Node<int> right = FindCommonAncestor(node.Right, i, j);

                if (left != null && right != null)
                {
                    return node;
                }
                else
                {

                    Node<int> elem = left == null ? right : left;
                    return elem;
                }
            }
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
            Console.WriteLine(node.Element);//8

            Node<int> node2 = LowestCommonAncestor.FindCommonAncestor(bst, 10, 14);
            Console.WriteLine(node2.Element); //12

            Node<int> node3 = LowestCommonAncestor.FindCommonAncestor(bst, 8, 22);
            Console.WriteLine(node3.Element); //20

            Node<int> node4 = LowestCommonAncestor.FindCommonAncestor(bst, 4, 22);
            Console.WriteLine(node4.Element);//20

            Node<int> node5 = LowestCommonAncestor.FindCommonAncestor(bst, 4, 8);
            Console.WriteLine(node5.Element); //20
        }
    }
}
