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

        public const int INF = 99999;

        public GrafoObject()
        {
            VerticesL = new List<Vertice>();
            AristasL = new List<Arista>();
        }

        //Crea una arista entre dos vertices dados
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
        private bool ExisteVertice(Vertice aBuscar)
        {
            var it = VerticesL.Where(x => x.Nombre == aBuscar.Nombre).FirstOrDefault();
            if (it == null)
                return false;
            return true;             
        }

        public int[,] ConvertirListaVerticesAArray()
        {
            int[,] matriz = new int[VerticesL.Count, VerticesL.Count];
            byte c = 0;

            for (int i = 0; i<VerticesL.Count; i++)
            {
                for (int j = 0; j< VerticesL.Count; j++)
                {
                    matriz[i, j] = INF;
                }
            }
            
            foreach (var vertice in VerticesL)
            {
                foreach (var arista in AristasL)
                {
                    bool entro = false;
                    if (arista.Vertices.vInicial.Nombre.Equals(vertice.Nombre))
                    {
                        for (int i = 0; i<VerticesL.Count; i++)
                        {
                            if (arista.Vertices.vFinal.Nombre.Equals(VerticesL[i].Nombre))
                            {
                                matriz[c, i] = arista.Peso;
                                matriz[i, c] = arista.Peso;
                            }
                            
                        }
                    }
                }
                c++;
            }


            for (int t = 0; t < VerticesL.Count; t++)
            {
                matriz[t, t] = 0;
            }

            return matriz;
        }
        
    }
}
