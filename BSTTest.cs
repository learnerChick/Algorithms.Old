using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Element { get; set; }
        public int Count { get; set; }

        public Node(T element)
        {
            Element = element;
        }
    }

    class BSTTest<T>
    {
        public Node<T> root;

        public BSTTest()
        {
            root = null;
        }

        public int size()
        {
            return size(root);
        }

        public int size(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return node.Count;
            }
        }

        public Node<T> add(T element)
        {
            root = add(element, root);
            return root;
        }

        public Node<T> add(T element, Node<T> node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if ((element as IComparable).CompareTo(node.Element) < 0)
            {
                node.Left = add(element, node.Left);
            }
            else if ((element as IComparable).CompareTo(node.Element) > 0)
            {
                node.Right = add(element, node.Right);
            }

            node.Count = 1 + size(node.Left) + size(node.Right);

            return node;
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

        public Node<T> removeMin()
        {
            root = removeMin(root);
            return root;
        }

        public Node<T> removeMin(Node<T> node)
        {
            if (node == null)
            {
                throw new Exception("No such element");
            }
            else if (node.Left != null)
            {
                node.Left = removeMin(node.Left);
                return node;
            }
            else
            {
                return node.Right;
            }
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
                throw new Exception("No such element found");
            }
            else if ((element as IComparable).CompareTo(node.Element) < 0)
            {
                node.Left = remove(element, node.Left);
            }
            else if ((element as IComparable).CompareTo(node.Element) > 0)
            {
                node.Right = remove(element, node.Right);
            }
            else if (node.Left != null && node.Right != null)
            {
                Node<T> minNode = findMin(node.Right);
                node.Element = minNode.Element;
                node.Right = removeMin(node.Right);
            }
            else
            {
                node = node.Left == null ? node.Right : node.Left;
            }
            return node;
        }

        public void inOrderTraversal()
        {
            inOrderTraversal(root);
        }

        //LVR
        public void inOrderTraversal(Node<T> node)
        {
            if (node.Left != null)
            {
                inOrderTraversal(node.Left);
            }

            Console.WriteLine(node.Element);
            if (node.Right != null)
            {
                inOrderTraversal(node.Right);
            }
        }

        public void preOrderTraversal()
        {
            preOrderTraversal(root);
        }

        public void preOrderTraversal(Node<T> node)
        {
            Console.WriteLine(node.Element);

            if (node.Left != null)
            {
                preOrderTraversal(node.Left);
            }

            if (node.Right != null)
            {
                preOrderTraversal(node.Right);
            }
        }

        public void breadthFirst()
        {
            Queue<Node<T>> q = new Queue<Node<T>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                Node<T> item = q.Dequeue();
                if (item == null)
                    continue;
                Console.WriteLine(item.Element);

                q.Enqueue(item.Left);
                q.Enqueue(item.Right);
            }

        }

        public boolean isBalanced(){

    }
        

    }
}
