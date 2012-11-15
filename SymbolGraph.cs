using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SymbolGraph
    {
        private Dictionary<string, int> symbolTable;
        private String[] allLines;
        private String[] keys;
        private UndirectedGraph graph;

        public SymbolGraph(String filename, Char delimiter)
        {
            //create all as vertices
            symbolTable = new Dictionary<string, int>();
            allLines = System.IO.File.ReadAllLines(@filename);
            int count = 0;
            foreach (string line in allLines)
            {
                String[] items = line.Split(delimiter);
                for(int i = 0; i < items.Length; i++){
                    if(!symbolTable.ContainsKey(items[i])){
                        symbolTable[items[i]] = count;
                        count++;
                    }
                }
            }

            //invert index to get string keys as an array
            
            keys = new String[symbolTable.Count];
            count = 0;
            foreach (KeyValuePair<string, int> pair in symbolTable)
            {
                keys[count] = pair.Key;
                count++;
            }

            //create graph from dictionary
            graph = new UndirectedGraph(symbolTable.Count);

            for (int i = 0; i < allLines.Length; i++)
            {
                String[] items = allLines[i].Split(delimiter);
                for (int j = 1; j < items.Length; j++)
                {
                    graph.AddEdge(symbolTable[items[0]], symbolTable[items[j]]);
                }
            }
        }

        public int getSymbolKey(string vertex){
            return symbolTable[vertex];
        }

        public ArrayList getRelationships(string key)
        {
            int keyNum = symbolTable[key];
            ArrayList adj = graph.Adjacent(keyNum);
            return adj;
        }

        public String getKeyValue(int index)
        {
            return keys[index];
        }

        public UndirectedGraph getSymbolGraph()
        {
            return graph;
        }

        public static void main()
        {
            SymbolGraph s = new SymbolGraph("C:/Users/Dhana/Desktop/Learning/C#/Algorithms/Algorithms/Data/movies.txt", ' ');
        }
    }
}
