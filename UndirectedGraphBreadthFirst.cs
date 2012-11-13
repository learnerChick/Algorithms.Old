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
        /*
         * 1)all vertices of G are first painted white
	       2)the graph root is painted gray and put in a queue
           3)while the queue is not empty{
	        a) a vertex u is removed from the queue
            b) for all white successors v of u{
	            i. v is painted gray
		        ii. v is added to the queue
	        }
	        c) u is painted black
	       }
         */

        private bool[] marked;

        private int[] distanceMatrix; //number of edges in shortest path
        private int[] pathMatrix; //previous edge in shortest path

        private int[] visitedMatrix;

        public UndirectedGraphBreadthFirst(UndirectedGraph g)
        {
            marked = new bool[g.getTotalVertices()];
            distanceMatrix = new int[g.getTotalVertices()];
            pathMatrix = new int[g.getTotalVertices()];
            visitedMatrix = new int[g.getTotalVertices()];
        }

        public void bfs(UndirectedGraph g, int vertex)
        {
            Queue<int> q = new Queue<int>();

            //set up the entire visitedMatrix with -1 except for the vertex node
            for (int i = 0; i < g.getTotalVertices(); i++)
            {
                visitedMatrix[i] = -1;
            }
            
            //mark root with 1 to sat it's visited
            visitedMatrix[vertex] = 1;
            q.Enqueue(vertex);

            while (q.Count > 0)
            {
                int v = q.Dequeue();
                Console.WriteLine(v);
                marked[v] = true;

                //get all adjacent
                ArrayList adj = g.Adjacent(v);
                
                for (int i = 0; i < adj.Count; i++)
                {
                    int currentVertex = (int) adj[i];
                    if (visitedMatrix[currentVertex] == -1)
                    {
                        q.Enqueue(currentVertex);
                        visitedMatrix[currentVertex] = 1;
                    }
                }
                visitedMatrix[v] = 0;
                marked[v] = false;
            }
        }

        public int[] getShortestPath(UndirectedGraph g, int vertex)
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
