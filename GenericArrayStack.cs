using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class GenericArrayStack<T>
    {
        T[] collection;
        int totalItems;

        public GenericArrayStack()
        {
            collection = new T[1];
            totalItems = 0;
        }

        public void push(T item)
        {
            if (collection.Length == totalItems)
            {
                resizeStack(collection.Length * 2);
            }

            collection[totalItems] = item;
            totalItems++;
        }

        public void resizeStack(int size)
        {
            T[] copy = new T[size];
            for (int i = 0; i < size/2; i++)
            {
                copy[i] = collection[i];
            }
            collection = copy;
        }

        public T pop()
        {
            if (totalItems <= 0)
            {
                throw new Exception("Stack Underflow Exception");
            }

            T item = collection[--totalItems];
            
            if(collection.Length <= totalItems/4){
                resizeStack(collection.Length/4);
            }
         
            return item;
        }

        public T peek()
        {
            if (totalItems <= 0)
            {
                throw new Exception("Stack Underflow Exception");
            }

            
            return collection[totalItems - 1];
        }

        public Boolean isEmpty()
        {
            return totalItems == 0;
        }

        public override string ToString()
        {
            string output = string.Empty;
            for (int i = 0; i < totalItems; i++)
            {
                output += collection[i] + ", ";
            }
            return output;
        }

        public static void main()
        {
            GenericArrayStack<int> s = new GenericArrayStack<int>();
            s.push(10);
            s.push(20);
            s.push(222);
            s.pop();
            Console.WriteLine(s.ToString());
            s.push(56);
        }

    }
}
