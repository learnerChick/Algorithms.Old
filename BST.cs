using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    /*--http://www.algolist.net/Data_structures/Binary_search_tree/Removal */

    public class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Element { get; set; }

        public Node(T item)
        {
            Element = item;
        }
    }

    public class BST<T>
    {
        private Node<T> root;

        public BST()
        {
            root = null;
        }

        public Node<T> find(T element)
        {
            Node<T> current = root;
            while (current != null)
            {
                if ((element as IComparable).CompareTo(current.Element) < 0)
                {
                    current = current.Left;
                }
                else if ((element as IComparable).CompareTo(current.Element) > 0)
                {
                    current = current.Right;
                }
                else if ((element as IComparable).CompareTo(current.Element) == 0)
                {
                    return current;
                }
            }
            return null;
        }

        public Node<T> remove(T element)
        {
            root = remove(element, root);
            return root;
        }

        public Node<T> remove(T element, Node<T> node)
        {
            if (node == null)
            {
                throw new Exception("Item wasn't found");
            }
            else if ((element as IComparable).CompareTo(node.Element) < 0)
            {
                node.Left = remove(element, node.Left);
            }
            else if ((element as IComparable).CompareTo(node.Element) > 0)
            {
                node.Right = remove(element, node.Right);
            }

            //if node has both children, find the minimum in the right node.  
            //Replace the value of node to be removed with found minimum.  
            //Since right tree now contains duplicate, remove the duplicate item in the right subtree
            else if (node.Left != null && node.Right != null)
            {
                Node<T> minNode = findMin(node.Right);
                node.Element = minNode.Element;
                node.Right = removeMin(node.Right);
            }

            //if either node is enmpty, replace the node to be removed with either node
            else
            {
                node = node.Left == null ? node.Right : node.Left;
            }
            return node;
        }

        public Node<T> removeMin(Node<T> node)
        {
            if (node == null)
            {
                throw new Exception("No such node found");
            }

            if (node.Left != null)
            {
                node.Left = removeMin(node.Left);
                return node;
            }
            else
            {
                return node.Right;
            }
        }

        public Node<T> removeMax(Node<T> node){
            if (node == null)
            {
                throw new Exception("No such node found");
            }

            if (node.Right != null)
            {
                node.Right = findMax(node.Right);
                return node;
            }
            else
            {
                return node.Left;
            }
        }

        public Node<T> add(T element)
        {
            root = add(element, root);
            return root;
        }

        public Node<T> findMin()
        {
            return findMin(root);
        }

        public Node<T> findMin(Node<T> node)
        {
            if (node != null)
            {
                while (node.Left != null)
                {
                    node = node.Left;
                }
            }
            return node;
        }

        public Node<T> findMax()
        {
            return findMax(root);
        }

        public Node<T> findMax(Node<T> node)
        {
            if (node != null)
            {
                while (node.Right != null)
                {
                    node = node.Right;
                }
            }
            return node;
        }

        /*  1. Check if value in current node and new value are equal
            2. If less: if current node has no left child, add there. Else, handle left child with same algorithm.
         *  3. If more: if current node has no right child, add there. Else repeat.
         */

        public Node<T> add(T element, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(element);
            }
            else if ((element as IComparable).CompareTo(node.Element) < 0)
            {
                node.Left = add(element, node.Left);
            }
            else if ((element as IComparable).CompareTo(node.Element) > 0)
            {
                node.Right = add(element, node.Right);
            }

            return node;
        }

       
        /*
         * Inorder, postorder, preorder are depth first traversal.
         */
        //LVR, if a node is missing on left or right, parent will be visited
        //recursively visit the left, then print value, then recursively go to the right
        public void inorderTraversal()
        {
            inorderTraversal(root);
        }

        public void inorderTraversal(Node<T> node)
        {
            if (node.Left != null)
            {
                inorderTraversal(node.Left);
            }
            
            Console.WriteLine(node.Element);
            
            if (node.Right != null)
            {
                inorderTraversal(node.Right);
            }
        }

        //LRV (left, right, value, recursively)
        public void postorderTraversal()
        {
            postorderTraversal(root);
        }


        public void postorderTraversal(Node<T> node)
        {
            if(node.Left != null){
                preorderTraversal(node.Left);
            }

            if(node.Right != null){
                preorderTraversal(node.Right);
            }

            Console.WriteLine(node.Element);
        }

        //VLR (value, left, right, check the value, go recursively down the left node, get all the lefts, then the rights
        public void preorderTraversal()
        {
            preorderTraversal(root);
        }


        public void preorderTraversal(Node<T> node)
        {
            Console.WriteLine(node.Element);
            if (node.Left != null)
            {
                preorderTraversal(node.Left);
            }

            if (node.Right != null)
            {
                preorderTraversal(node.Right);
            }
        }

        //queue
        //BFS is much more efficient than DFS.
        public void breadthFirstTraversal()
        {
            breadthFirstTraversal(root);
        }

        public void breadthFirstTraversal(Node<T> node)
        {
            Queue<Node<T>> q = new Queue<Node<T>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                Node<T> current = q.Dequeue();
                if (current == null)
                    continue;

                Console.WriteLine(current.Element);

                q.Enqueue(current.Left);
                q.Enqueue(current.Right);
            }
        }


        public static void main()
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
            //bst.preorderTraversal();  /* 200 1 31 4 500 */
            bst.breadthFirstTraversal(); /* 200 1 500 31 4 */


        }

    }
}
