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
}
