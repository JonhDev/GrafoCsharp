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
            g.AgregarConexion(new Vertice() { Nombre = "A" }, new Vertice() { Nombre = "B" }, 5);
            Console.WriteLine(g.AristasL[0].ToString());
            Console.ReadKey();
        }
    }
}
