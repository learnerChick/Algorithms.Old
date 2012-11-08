using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class UndirectedGraphBreadthFirst
    {
        bool[] marked;
        public UndirectedGraphBreadthFirst(UndirectedGraph g, int vertex) 
        {
            marked = new bool[g.getTotalVertices()];
            search(g, vertex); 
        }

        public void search(UndirectedGraph g, int vertex)
        {
            Queue<int> queue = new Queue<int>();
            
            //set the first vertex into the queue first and mark it visited
            queue.Enqueue(vertex);
            marked[vertex] = true;

            while (queue.Count > 0)
            {
                int v = queue.Dequeue();
                ArrayList adj = g.Adjacent(v);
                for (int i = 0; i < adj.Count; i++)
                {
                    int currentVertex = (int)adj[i];
                    if (marked[currentVertex] != true)
                    {
                        queue.Enqueue(i);
                    }
                }
            }
        }

        public static void main()
        {
            UndirectedGraph g = new UndirectedGraph(6);
            g.AddEdge(0, 2);
            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(1, 0);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 1);
            g.AddEdge(2, 3);
            g.AddEdge(2, 4);
            g.AddEdge(3, 5);
            g.AddEdge(3, 4);
            g.AddEdge(3, 2);
            g.AddEdge(4, 3);
            g.AddEdge(4, 2);
            g.AddEdge(5, 3);
            g.AddEdge(5, 0);

            UndirectedGraphBreadthFirst br = new UndirectedGraphBreadthFirst(g, 8);
           
        }
    }
}
