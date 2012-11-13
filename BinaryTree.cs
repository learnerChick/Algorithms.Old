using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BinaryTreeNode<T>
    {
        private T _data;
        private BinaryTreeNode<T> _left;
        private BinaryTreeNode<T> _right;
        private int _offset;                // left to right (0 = center)
        private int _depth;                 // top to bottom

        public BinaryTreeNode(T t)
        {
            _data = t;
        }

        public BinaryTreeNode<T> Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public BinaryTreeNode<T> Right
        {
            get { return _right; }
            set { _right = value; }
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public int Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }


    }

    public delegate void NodeWalkedInOrder<T>(T node, T parent);
    public delegate void NodeWalked<T>(T node, T parent);

    public class BinaryTree<T> where T : IComparable
    {
        private BinaryTreeNode<T> _center;

        public NodeWalkedInOrder<BinaryTreeNode<T>> onNodeWalkedInOrder;
        public NodeWalked<BinaryTreeNode<T>> onNodeWalked;

        public BinaryTreeNode<T> Center
        {
            get { return _center; }
        }

        public string WalkInOrder()
        {
            string s = DoWalkInOrder(_center, true, null);
            return s;
        }

        public override string ToString()
        {
            return DoWalkInOrder(_center, false, null);
        }

        public void Add(T t)
        {
            if (_center == null)
            {
                _center = new BinaryTreeNode<T>(t);
                _center.Depth = 1;
                _center.Offset = 0;
            }
            else
            {
                BinaryTreeNode<T> current = _center;
                BinaryTreeNode<T> next;
                int nodeDepth = _center.Depth;
                int nodeOffset = _center.Offset;
                while (true)
                {
                    nodeDepth++;
                    if (t.CompareTo(current.Data) <= 0)
                    {
                        nodeOffset--;
                        next = current.Left;
                        if (next == null)
                        {
                            current.Left = new BinaryTreeNode<T>(t);
                            current.Left.Depth = nodeDepth;
                            current.Left.Offset = nodeOffset;
                            break;
                        }
                    }
                    else
                    {
                        nodeOffset++;
                        next = current.Right;
                        if (next == null)
                        {
                            current.Right = new BinaryTreeNode<T>(t);
                            current.Right.Depth = nodeDepth;
                            current.Right.Offset = nodeOffset;
                            break;
                        }
                    }
                    current = next;
                }

            }
        }

        private void AddStringToString(ref string s, string newString)
        {
            if ((s == null) || (s.Length == 0))
            {
                s = newString;
            }
            else
            {
                s += ", " + newString;
            }
        }

        private void AddNodeToString(ref string s, BinaryTreeNode<T> node)
        {
            AddValueToString(ref s, node.Data);
        }

        private void AddValueToString(ref string s, T value)
        {
            if ((s == null) || (s.Length == 0))
            {
                s = value.ToString();
            }
            else
            {
                s += ", " + value.ToString();
            }
        }

        private string DoWalkInOrder(BinaryTreeNode<T> node, bool useDelegates, BinaryTreeNode<T> parent)
        {
            string retVal = "";
            bool nodeWalked = false;

            if (node == null)
            {
                return "";
            }

            if (useDelegates && onNodeWalked != null) onNodeWalked(node, parent);

            if (node.Left == null && node.Right == null)
            {
                // it's a leaf
                if (useDelegates && onNodeWalkedInOrder != null) onNodeWalkedInOrder(node, parent);
                AddNodeToString(ref retVal, node);
            }

            if (node.Left != null)
            {
                retVal += DoWalkInOrder(node.Left, useDelegates, node);         // find lower values
                AddNodeToString(ref retVal, node);
                if (useDelegates && onNodeWalkedInOrder != null) onNodeWalkedInOrder(node, parent);
                nodeWalked = true;
            }

            if (node.Right != null)
            {
                if (!nodeWalked)
                {
                    if (useDelegates && onNodeWalkedInOrder != null) onNodeWalkedInOrder(node, parent);
                    AddNodeToString(ref retVal, node);  // show yourself (if not shown before)
                }
                string retVal2 = DoWalkInOrder(node.Right, useDelegates, node);
                AddStringToString(ref retVal, retVal2); // find higher values                
            }

            return retVal;
        }

    }
}
