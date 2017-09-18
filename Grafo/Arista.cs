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

    /// <summary>
    /// Crea una Arista generica de dos tipos T como tipo de arista y U como tipo de vertice
    /// </summary>
    /// <typeparam name="T">Tipo de arista</typeparam>
    /// <typeparam name="U">Tipo de vertice</typeparam>
    public class Arista<T, U>
    {
        //Peso u objeto peso
        public T Objeto { get; set; }
        public (Vertice<U, T> inicial, Vertice<U, T> final) Vertices { get; set; }

        public Arista(T objeto, Vertice<U, T> inicial, Vertice<U, T> final)
        {
            Objeto = objeto;
            Vertices = (inicial, final);
        }

        public void ModificarVertices(Vertice<U, T> inicial, Vertice<U, T> final)
        {
            Vertices=(inicial, final);
        }

        public override string ToString()
        {
            return $"{Vertices.inicial.Objeto.ToString()} ----{Objeto.ToString()}---->{Vertices.final.Objeto.ToString()}";
        }

    }
}
