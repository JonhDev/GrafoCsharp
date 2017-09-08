using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class Arista
    {
        public int Peso { get; set; }
        public (Vertice vInicial, Vertice vFinal) Vertices { get; set; }

        public Arista() { }

        public Arista(int peso, Vertice incial, Vertice final)
        {
            Peso = peso;
            Vertices = (incial, final);
        }

        public override string ToString()
        {
            return $"{Vertices.vInicial.Nombre} <-------- {Peso} --------> {Vertices.vFinal.Nombre}";
        }
    }
}
