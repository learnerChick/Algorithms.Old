using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /*Given a sorted (increasing order) array, write an algorithm to create a binary tree with minimal height.*/
    /* O(N) time */

    public class MinimalHeightBinaryTree
    {
        public MinimalHeightBinaryTree() { }

        public Node<int> add(int[] array, int start, int end)
        {
            if (end < start)
            {
                return null;
            }

            int mid = (start + end) / 2;
            Node<int> node = new Node<int>(array[mid]);

            node.Left = add(array, start, mid - 1);
            node.Right = add(array, mid + 1, end);
            return node;
        }

        public static void main()
        {
            int[] arr = { 2, 4, 6, 8, 11, 32, 58, 199 };
            MinimalHeightBinaryTree minHeightTree = new MinimalHeightBinaryTree();
            Node<int> tree = minHeightTree.add(arr, 0, arr.Length - 1);
        }
    }
}
