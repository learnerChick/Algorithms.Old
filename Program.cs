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
            UndirectedGraph g = new UndirectedGraph(13);
            g.AddEdge(0, 6);
            g.AddEdge(0, 2);
            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(1, 0);
            g.AddEdge(2, 0);
            g.AddEdge(3, 5);
            g.AddEdge(3, 4);
            g.AddEdge(4, 5);
            g.AddEdge(4, 6);
            g.AddEdge(4, 3);
            g.AddEdge(5, 3);
            g.AddEdge(5, 4);
            g.AddEdge(5, 0);
            g.AddEdge(6, 0);
            g.AddEdge(6, 4);
            g.AddEdge(7, 8);
            g.AddEdge(8, 7);
            g.AddEdge(9, 11);
            g.AddEdge(9, 10);
            g.AddEdge(9, 12);
            g.AddEdge(10, 9);
            g.AddEdge(11, 9);
            g.AddEdge(11, 12);
            g.AddEdge(12, 11);
            g.AddEdge(12, 9);

            UndirectedGraphDepthFirst depthFirst = new UndirectedGraphDepthFirst(g);
            depthFirst.search(g, 8);

            Queue<int> q = depthFirst.getPath();
            Console.WriteLine("Path is: ");
            foreach (int value in q)
            {
                Console.Write(value + " ");
            }


            for (int i = 0; i < g.getTotalEdges(); i++)
            {
                if (depthFirst.pathExists(i) != false)
                {
                    Console.Write(i);
                }
            }

            Console.WriteLine("Connected: " + depthFirst.isConnected(g));
        }
    }
}
