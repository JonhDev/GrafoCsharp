using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class GrafoObject
    {
        public List<Vertice> VerticesL { get; set; }
        public List<Arista> AristasL { get; set; }

        public GrafoObject()
        {
            VerticesL = new List<Vertice>();
            AristasL = new List<Arista>();
        }

        public void AgregarConexion(Vertice verticeInicial, Vertice verticeFinal, int peso)
        {
            //se crea una nueva arista con los parametros del metodo
            var arista = new Arista(peso, verticeInicial, verticeFinal);

            //Al vertice inicial y final se le avisan sus aristas
            verticeInicial.Aristas.Add(arista);
            verticeFinal.Aristas.Add(arista);

            //Se agregan los vertices y aristas a la lista del grafo para que sepa cuales tiene, se usa ExisteVertice que retorna un bool
            if(!ExisteVertice(verticeInicial))
                VerticesL.Add(verticeInicial);
            if(!ExisteVertice(verticeFinal))
                VerticesL.Add(verticeFinal);
            AristasL.Add(arista);
        }


        //Permite atravez de una expresion lamda saber si existe o no el vertice
        public bool ExisteVertice(Vertice aBuscar)
        {
            var it = VerticesL.Where(x => x.Nombre == aBuscar.Nombre).FirstOrDefault();
            if (it == null)
                return false;
            return true;             
        }

    }
}
