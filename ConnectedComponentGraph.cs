using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /* 
     * computes all the connected component in a graph using depth first search 
       Runs in O(E+V) time 
     */

    public class ConnectedComponentGraph
    {
        private bool[] marked; //stores vertices that have been visited
        private int count; //total connected components
        private int[] id; // id of a connected component
        private int[] size; //number of vertices in a connected component

        public ConnectedComponentGraph(UndirectedGraph g)
        {
            marked = new bool[g.getTotalVertices()];
            id = new int[g.getTotalVertices()];
            size = new int[g.getTotalVertices()];

            for (int i = 0; i < g.getTotalVertices(); i++)
            {
                if (!marked[i])
                {
                    dfs(g, i);
                    count++;
                }
            }
        }

        public void dfs(UndirectedGraph g, int vertex){
            marked[vertex] = true;
            id[vertex] = count;
            size[vertex]++;

            ArrayList adjacent = g.Adjacent(vertex);
            for (int i = 0; i < adjacent.Count; i++)
            {
                int currentVertex = (int) adjacent[i];
                if(!marked[currentVertex]){
                    dfs(g, currentVertex);
                }
            }
        }

        //return id of connected component containing vertex
        public int connectedComponentId(int vertex)
        {
            return id[vertex];
        }

        //return size of connected component
        public int connectedComponentSize(int vertex)
        {
            return size[vertex];
        }

        //returm the number of connected components
        public int numberOfConnectedComponent()
        {
            return count;
        }

        public static void main()
        {
            UndirectedGraph g = new UndirectedGraph(13);
            g.AddEdge(0, 5);
            g.AddEdge(4, 5);
            g.AddEdge(0, 1);
            g.AddEdge(9, 12);
            g.AddEdge(6, 4);
            g.AddEdge(5, 4);
            g.AddEdge(0, 2);
            g.AddEdge(11, 12);
            g.AddEdge(9, 10);
            g.AddEdge(0, 6);
            g.AddEdge(7, 8);
            g.AddEdge(9, 11);
            g.AddEdge(5, 3);

            ConnectedComponentGraph cc = new ConnectedComponentGraph(g);
            Console.WriteLine("Total connected components: " + cc.numberOfConnectedComponent());

            //display vertices in each connnected component
            Dictionary<int, Queue<int>> dict = new Dictionary<int, Queue<int>>();
            for (int i = 0; i < cc.numberOfConnectedComponent(); i++)
            {
                dict[i] = new Queue<int>();
            }

            for (int i = 0; i < g.getTotalVertices(); i++)
            {
                dict[cc.connectedComponentId(i)].Enqueue(i);
            }

            for (int i = 0; i < cc.numberOfConnectedComponent(); i++)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Component: " + i);
                while (dict[i].Count > 0)
                {
                    Console.Write(dict[i].Dequeue() + " ");
                }
            }
        }
    }
}
