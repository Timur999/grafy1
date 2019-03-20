using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista1zad1
{
    class Program
    {
    

        static void Main(string[] args)
        {
            //int[,] array2D = new int[5, 2];
            //readGraph(array2D);

        //    Console.WriteLine(SpecialFunctions.Erf(0.5));

        //    // Solve a random linear equation system with 500 unknowns
        //    Matrix<double> A = DenseMatrix.OfArray(new double[,] {
        //{1,1,1,1},
        //{1,2,3,4},
        //{4,3,2,1}});


            Graph graph = new Graph();
            Console.WriteLine("Liczba wierzcholkow grafu G to: " + graph.vertices);
            graph.VerticesCollection();
            Console.WriteLine("Liczba krawedzi grafu G to: " + graph.edges);
            graph.EdgesCollection();
            graph.AdjacencyMatrix();
            graph.IncidentMatrix();
  
            Console.Read();
        }
    }
}
