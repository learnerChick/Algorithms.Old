using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algos
{
    public class Mergesort<T>
    {
        /*
         * 1. Worst case: O(n log n) comparison algorithm.
         * 2. Stable sort.
         * 3. First, divide the array into halfs.  Recursively divide array into halfs until the length of the array is less than 2.
         * 4. Then start a counter on the left array and right array. Both begin at 0.  
         * 5. Then, compare item on left with item on right.  Whichever is smaller gets copied to new result array and that particular counter gets incremented.  Then comparison goes on until counter is more than length.
         * 6. Copy the rest of the data into the result array.
         */


        //end is not inclusive
        private T[] slice(int begin, int end, T[] toCopy)
        {
            int j = 0;
            T[] copy = new T[end - begin];
            for (int i = begin; i < end; i++)
            {
                copy[j] = toCopy[i];
                j++;
            }
            return copy;
        }

        public T[] sort(T[] arr)
        {
            if (arr.Length < 2)
            {
                return arr;
            }

            int mid = arr.Length / 2;
            T[] leftArr = slice(0, mid, arr);
            T[] rightArr = slice(mid, arr.Length, arr);
            //continue slicing until it's down to 1 element and then do the merge part
            return mergesort(sort(leftArr), sort(rightArr));
        }

        private T[] mergesort(T[] leftArr, T[] rightArr)
        {
            int il = 0, ir = 0, i = 0;
            T[] result = new T[leftArr.Length + rightArr.Length];

            while (il < leftArr.Length && ir < rightArr.Length)
            {
                if ((leftArr[il] as IComparable).CompareTo(rightArr[ir]) < 0)
                {
                    result[i++] = leftArr[il++];
                }
                else if ((leftArr[il] as IComparable).CompareTo(rightArr[ir]) > 0)
                {
                    result[i++] = rightArr[ir++];
                }
            }

            //copy the rest of the array data into result
            for (int j = il; j < leftArr.Length; j++)
            {
                result[i++] = leftArr[j];
            }

            for (int k = ir; k < rightArr.Length; k++)
            {
                result[i++] = rightArr[k];
            }

            return result;
        }

        public void test()
        {
            Mergesort<int> merge = new Mergesort<int>();
            int[] arr = { 90, 21, 32, 3, 43, 12, 8, 4 };
            int[] res1 = merge.sort(arr);
            Console.WriteLine(res1.ToString());

            Mergesort<string> merge2 = new Mergesort<string>();
            string[] arr2 = { "me", "one", "blah", "genesis", "amish", "cataract", "aspen" };
            string[] res2 = merge2.sort(arr2);
            Console.WriteLine(res2.ToString());

        }

    }
}

