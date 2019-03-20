using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lista1zad1
{
    class Graph
    {
        public int vertices;
        public int edges;

        public int[,] array2D = new int[5, 2];
        public List<Edge> allEdges = new List<Edge>();

        public Graph()
        {
            string[] array;
            try
            {   // Open the text file using a stream reader.
                //string path1 = @"D:\Visual Studio 2010\Projects\TomekGrafy\graf1.txt";
                string path1 = @"D:\project folder\TomekGrafy\graf1.txt";

                using (StreamReader sr = new StreamReader(path1))
                {
                    String line;
                    int j = 0;
                    bool firstElement = true;
                    while ((line = sr.ReadLine()) != null)
                    {
                        array = line.Split(' ');

                        if (firstElement)
                        {
                            firstElement = false;
                            this.vertices = int.Parse(array[0]);
                            this.edges = int.Parse(array[1]);
                            continue;
                        }

                        for (int i = 0; i < 2; i++)
                        {
                            this.array2D[j, i] = int.Parse(array[i]);
                        }
                        j++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            GetListOfEdge();
        }

        public void GetListOfEdge()
        {
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                Edge node = new Edge(array2D[i, 0], array2D[i, 1], 1, i);
                allEdges.Add(node);
            }
        }

        public void AdjacencyMatrix()
        {
            int[,] adj = new int[this.vertices, this.vertices];
            // Display the array elements.
            for (int i = 0; i < this.vertices; i++)
            {
                for (int j = 0; j < this.vertices; j++)
                {
                    Edge elementMatrix = allEdges.Where(x => x.Parent - 1 == i && x.Child - 1 == j).FirstOrDefault();
                    if (elementMatrix != null)
                    {
                        adj[elementMatrix.Parent - 1, elementMatrix.Child - 1] = elementMatrix.Weight;
                        adj[elementMatrix.Child - 1, elementMatrix.Parent - 1] = elementMatrix.Weight;
                    }
                    else { }
                }
            }

            Console.WriteLine("Macierz sasiedztwa A = \n"); 
            for (int i = 0; i < this.vertices; i++)
            {
                for (int j = 0; j < this.vertices; j++)
                {
                    Console.Write(adj[i,j] + "  ");
                }
                Console.WriteLine("\n");
            }
        }


        public void IncidentMatrix()
        {
            int[,] inc = new int[this.vertices, this.allEdges.Count];
            
            for (int i = 0; i < this.vertices; i++)
            {
                for (int j = 0; j < this.allEdges.Count; j++)
                {
                    Edge elementMatrix = allEdges.Where(x => x.Id == j && x.Parent - 1 == i).FirstOrDefault();
                    if (elementMatrix != null)
                    {
                        inc[i, elementMatrix.Id] = elementMatrix.Weight;
                        inc[elementMatrix.Child - 1, elementMatrix.Id] = elementMatrix.Weight;
                    }
                    else { }
                }
            }

            Console.WriteLine("Macierz incydencji M  = \n");
            for (int i = 0; i < this.vertices; i++)
            {
                for (int j = 0; j < this.allEdges.Count; j++)
                {
                    Console.Write(inc[i, j] + "  ");
                }
                Console.WriteLine("\n");
            }
        }

        public void VerticesCollection()
        {
            Console.Write("Zbior wierzcholkow V = ");
            for(int i=1; i<=allEdges.Count+1; i++)
            {
                Edge elementMatrix = allEdges.Where(x => x.Child == i || x.Parent == i).FirstOrDefault();
                if(elementMatrix != null)
                  Console.Write(i + ",");
            }
            Console.WriteLine("\n");
        }

        public void EdgesCollection()
        {
            Console.Write("Zbior krawedzi E = ");
            foreach (Edge e in allEdges)
            {
                Console.Write("{" + e.Parent + '-' + e.Child + "} ");
            }
            Console.WriteLine("\n");
        }

        public override string ToString()
        {
            string s = "";
            // Display the array elements.
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    s += "Element(" + i + ",{1}" + j + ")={2}" + array2D[i, j] + "\n";
                }
            }

            return s;
        }
    }
}
