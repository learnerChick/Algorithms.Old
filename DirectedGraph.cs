using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class DirectedGraph
    {
        private int totalVertices;
        private int totalEdges;
        private ArrayList[] adjacentMatrix;


        public DirectedGraph(int v)
        {
            if (v < 0)
            {
                throw new ArgumentException("Number of vertices should be larger than 0");
            }
            totalVertices = v;
            totalEdges = 0;
            adjacentMatrix = new ArrayList[totalVertices];

            for (int i = 0; i < totalVertices; i++)
            {
                adjacentMatrix[i] = new ArrayList();
            }
        }

        public void AddEdge(int start, int end)
        {
            if ((start < 0 || start >= totalVertices) || (end < 0 || end >= totalVertices))
            {
                throw new IndexOutOfRangeException();
            }
            adjacentMatrix[start].Add(end);
            totalEdges++;
        }

        public int getTotalVertices()
        {
            return totalVertices;
        }

        public int getTotalEdges()
        {
            return totalEdges;
        }

        public ArrayList Adjacent(int vertex)
        {
            if (vertex < 0 && vertex >= totalVertices)
            {
                throw new ArgumentException("Invalid vertex");
            }
            return adjacentMatrix[vertex];
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
        }
    }
}
