using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class DirectedGraphDepthFirst
    {
        private bool[] marked;

        public DirectedGraphDepthFirst(DirectedGraph g, int vertex)
        {
            marked = new bool[g.getTotalVertices()];
            dfs(g, vertex);
        }

        public void dfs(DirectedGraph g, int vertex)
        {
            marked[vertex] = true;
            Console.WriteLine(vertex);
            ArrayList adjacent = g.Adjacent(vertex);
            for (int i = 0; i < adjacent.Count; i++)
            {
                int currentVertex = (int) adjacent[i];
                if (!marked[currentVertex])
                {
                    dfs(g, currentVertex);
                }
            }
        }

        public bool hasPath(int vertex)
        {
            return marked[vertex];
        }

        public static void main()
        {
            DirectedGraph g = new DirectedGraph(13);
            g.AddEdge(4, 2);
            g.AddEdge(2, 3);
            g.AddEdge(3, 2);
            g.AddEdge(6, 0);
            g.AddEdge(0, 1);
            g.AddEdge(2, 0);
            g.AddEdge(11, 12);
            g.AddEdge(12, 9);
            g.AddEdge(9, 10);
            g.AddEdge(9, 11);
            g.AddEdge(7, 9);
            g.AddEdge(10, 12);
            g.AddEdge(11, 4);
            g.AddEdge(4, 3);
            g.AddEdge(3, 5);
            g.AddEdge(6, 8);
            g.AddEdge(8, 6);
            g.AddEdge(5, 4);
            g.AddEdge(0, 5);
            g.AddEdge(6, 4);
            g.AddEdge(6, 9);
            g.AddEdge(7, 6);

            DirectedGraphDepthFirst dp = new DirectedGraphDepthFirst(g, 2);

        }

    }
}
