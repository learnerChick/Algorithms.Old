using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Vertex
    {
        public bool wasVisited;
        public string label;

        public Vertex(string l)
        {
            label = l;
            wasVisited = false;
        }
    }

    public class Graph
    {
        private int totalVertices = 0;
        private int totalEdges;
        private ArrayList[] adjacentMatrix;
        

        public Graph(int v)
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

        public void AddEdge(int start, int end)
        {
            if ((start < 0 || start >= totalVertices) || (end < 0 || end >= totalVertices) { 
                throw new IndexOutOfRangeException;
            }
            totalEdges++;
            adjacentMatrix[start].Add(end);
            adjacentMatrix[end].Add(start);

        }
    }

    
}
