using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class Vertice
    {
        public string Nombre { get; set; }
        public List<Arista> Aristas { get; set; }

        public Vertice() { Aristas = new List<Arista>(); }

        public Vertice(string nombre) { Nombre = nombre; Aristas = new List<Arista>(); }

        public Vertice(string nombre, params Arista[] aristas)
        {
            Aristas = new List<Arista>();
            Nombre = nombre;
            foreach (var item in aristas)
                Aristas.Add(item);
        }

    }

    /// <summary>
    /// Crea un Vertice generico de dos tipos, T como tipo de vertice y U como tipo de arista
    /// </summary>
    /// <typeparam name="T">Tipo de vertice</typeparam>
    /// <typeparam name="U">Tipo de arista</typeparam>
    public class Vertice<T, U>
    {
        public T Objeto { get; set; }
        public List<Arista<U, T>> Aristas { get; set; }

        public Vertice(T vertice)
        {
            Objeto = vertice;
            Aristas = new List<Arista<U, T>>();
        }

        public override string ToString()
        {
            return Objeto.ToString();
        }
    }

}
