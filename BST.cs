using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Node<T>
    {
        public T Element { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T element)
        {
            Element = element;
            //same as this.Element = element;
        }
    }

    public class BST<T>
    {
        private Node<T> root;

        public BST()
        {
            root = null;
        }

        public Node<T> find(T item)
        {
            Node<T> x = root;
            while (x != null)
            {
                if ((item as IComparable).CompareTo(x.Element) < 0)
                {
                    x = root.Left;
                }
                else if ((x as IComparable).CompareTo(x.Element) > 0)
                {
                    x = root.Right;
                }
            }
            return x;
        }

    }
}
