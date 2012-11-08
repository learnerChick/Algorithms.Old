using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /*
     *  Adding an edge – O(1);
        Deleting an edge – O(1);
        Answering the question “is there an edge between i and j” – O(1);
        Finding the successors of a given vertex – O(n);
        Finding (if exists) a path between two vertices – O(n2);
     */

    public class UndirectedGraph
    {
        private int totalVertices = 0;
        private int totalEdges;
        private ArrayList[] adjacentMatrix;


        public UndirectedGraph(int v)
        {
            if (v < 0)
            {
                throw new ArgumentException("Number of vertices has to be greater than 0");
            }

            totalVertices = v;
            totalEdges = 0;
            adjacentMatrix = new ArrayList[totalVertices];
            for (int i = 0; i < totalVertices; i++)
            {
                adjacentMatrix[i] = new ArrayList();
            }
        }

        /* 
         * Complextity: O(n)
         */
        public void AddEdge(int start, int end)
        {
            if ((start < 0 || start >= totalVertices) || (end < 0 || end >= totalVertices)) { 
                throw new IndexOutOfRangeException();
            }
            
            if(!adjacentMatrix[start].Contains(end) && !adjacentMatrix[end].Contains(start))
            {
                adjacentMatrix[start].Add(end);
                adjacentMatrix[end].Add(start);
                totalEdges++;
            }
          
        }

        public int getTotalVertices()
        {
            return totalVertices;
        }

        public int getTotalEdges()
        {
            return totalEdges ;
        }

        public ArrayList Adjacent(int vertex)
        {
            if (vertex < 0 && vertex >= totalVertices)
            {
                throw new ArgumentException("Invalid vertex");
            }
            return adjacentMatrix[vertex];
        }

        public String toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Total Vertices:" + getTotalVertices() + " , Total Edges: " + getTotalEdges());
            for(int i = 0; i < getTotalVertices(); i++)
            {
                sb.AppendLine();
                sb.Append("Vertex: " + i + " Adjacent: ");
                for(int j = 0; j < adjacentMatrix[i].Count; j++)
                {
                    sb.Append(adjacentMatrix[i][j] + ", ");
                }
            }
            return sb.ToString();
        }

        public static void main()
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
        }
    }
}