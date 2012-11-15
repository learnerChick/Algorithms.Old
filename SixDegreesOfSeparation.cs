using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SixDegreesOfSeparation
    {
        SymbolGraph s;


        public SixDegreesOfSeparation(string toFind)
        {
            s = new SymbolGraph("C:/Users/Dhana/Desktop/Learning/C#/Algorithms/Algorithms/Data/movies.txt", '/');
            int vertex = s.getSymbolKey(toFind);
            UndirectedGraph graph = s.getSymbolGraph();
            UndirectedGraphBreadthFirst searchTool = new UndirectedGraphBreadthFirst(graph);
            int[] matrix = searchTool.getShortestPath(graph, vertex);

            int MAX_BACON = 100;
            int[] hist = new int[MAX_BACON + 1];

            for (int i = 0; i < graph.getTotalVertices(); i++)
            {
                int bacon = 0;
                if (matrix[i] > 0)
                {
                    bacon = Math.Min(MAX_BACON, matrix[i]);
                    hist[bacon]++;
                }
            }

            for (int i = 0; i < hist.Length; i++)
            {
                Console.WriteLine(i + " " + hist[i]);
            }

        }

       
    }
}
