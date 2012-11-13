using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class DirectedGraphBreadthFirst
    {
        private bool[] marked;
        private int[] distanceMatrix; //number of edges in shortest path
        private int[] pathMatrix; //previous edge in shortest path

        public DirectedGraphBreadthFirst(DirectedGraph g)
        {
            marked = new bool[g.getTotalVertices()];
            distanceMatrix = new int[g.getTotalVertices()];
            pathMatrix = new int[g.getTotalVertices()];
        }

        public bool hasPath(DirectedGraph g, int vertex1, int vertex2)
        {
            int[] vertices = getPath(g, vertex1);
            if (vertices[vertex2] > 0)
            {
                return true;
            }
            return false;
        }

        public int[] getPath(DirectedGraph g, int vertex)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(vertex);

            //set up the entire distance matrix with -1 except for the vertex node
            for (int i = 0; i < g.getTotalVertices(); i++)
            {
                distanceMatrix[i] = -1;
            }
            //set up current vertex with 0 because there will be no distance
            distanceMatrix[vertex] = 0;

            while (q.Count > 0)
            {
                int v = q.Dequeue();
                Console.Write(v); //this is the breadth first traversal
                ArrayList adjacent = g.Adjacent(v);
                //loop through all the adjacent nodes, if the currentVertex is still -1, then go in and do process
                for (int i = 0; i < adjacent.Count; i++)
                {
                    int currentVertex = (int)adjacent[i];
                    if (distanceMatrix[currentVertex] == -1)
                    {
                        //add one to the distanceMatrix here because it's going to be from v to the current path
                        distanceMatrix[currentVertex] = distanceMatrix[v] + 1;
                        pathMatrix[currentVertex] = v;
                        q.Enqueue(currentVertex);

                    }
                }
            }
            return distanceMatrix;
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

            DirectedGraphBreadthFirst dp = new DirectedGraphBreadthFirst(g);
            bool flag = dp.hasPath(g, 0, 6);
            Console.WriteLine(flag);
        }
    }
}
