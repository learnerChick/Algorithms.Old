using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
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

            UndirectedGraphBreadthFirst br = new UndirectedGraphBreadthFirst(g);
            //int[] shortestPath = br.getShortestPath(g, 0);
            br.bfs(g, 5);
        }
    }
}
