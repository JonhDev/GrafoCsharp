using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    class Program
    {
        static void Main(string[] args)
        {


            GrafoObject g = new GrafoObject();
            Vertice a = new Vertice("A");
            Vertice b = new Vertice("B");
            Vertice c = new Vertice("C");
            Vertice d = new Vertice("D");
            Vertice e = new Vertice("E");
            Vertice f = new Vertice("F");
            Vertice gV = new Vertice("G");

            g.AgregarConexion(a, b, 5);
            g.AgregarConexion(a, d, 4);
            g.AgregarConexion(b, c, 10);
            g.AgregarConexion(b, d, 7);
            g.AgregarConexion(d, c, 3);

            foreach (var item in g.VerticesL)
            {
                Console.WriteLine($"{item.Nombre} \n");
            }

            foreach (var item in g.AristasL)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n\n");

            var matriz  = g.ConvertirListaVerticesAArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < g.VerticesL.Count; i++)
            {
                sb.Append(g.VerticesL[i].Nombre + "    ");
                for (int j = 0; j < g.VerticesL.Count; j++)
                {
                    sb.Append(matriz[i, j] + " ");
                }

                sb.Append("\n");
            }
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }
}
