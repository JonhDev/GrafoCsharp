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

        private void Imprimir(int[,] distance, int verticesCount)
        {
            Console.WriteLine("Caminos cortos: ");

            for (int i = 0; i < verticesCount; ++i)
            {
                for (int j = 0; j < verticesCount; ++j)
                {
                    if (distance[i, j] == INF)
                        Console.Write("INF".PadLeft(7));
                    else
                        Console.Write(distance[i, j].ToString().PadLeft(7));
                }

                Console.WriteLine();
            }
        }

        public void ImprimirCaminosCortos(int[,] graph, int verticesCount) 
        {
            int[,] distance = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; ++i)
                for (int j = 0; j < verticesCount; ++j)
                    distance[i, j] = graph[i, j];

            for (int k = 0; k < verticesCount; ++k)
            {
                for (int i = 0; i < verticesCount; ++i)
                {
                    for (int j = 0; j < verticesCount; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                            distance[i, j] = distance[i, k] + distance[k, j];
                    }
                }
            }

            Imprimir(distance, verticesCount);
        }
    }

    /// <summary>
    /// Crear un grafo generico de dos tipos, T como tipo de vertices a manejar y U como tipo de aristas a manejar
    /// </summary>
    /// <typeparam name="T">Tipo de Vertices que manejara el grafo</typeparam>
    /// <typeparam name="U">Tipo de aristas que manejara el grafo</typeparam>
    public class GrafoObject<T, U>
    {
        public List<Vertice<T, U>> VerticesLis { get; set; }
        public List<Arista<U, T>> AristasLis { get; set; }

        //Se crea delegado y evento de una conexion repetida
        public delegate void ConexionRepetidaEvent(Object sender, ConexionEventArgs args);
        public event ConexionRepetidaEvent ConexionRepetidaEventHandler;

        public GrafoObject()
        {
            VerticesLis = new List<Vertice<T, U>>();
            AristasLis = new List<Arista<U, T>>();
        }

        /// <summary>
        /// Agrega conexion entre dos vertices con una arista
        /// </summary>
        /// <param name="inicial">Vertice inicial de la conexión</param>
        /// <param name="final">Vertice final de la conexión</param>
        /// <param name="peso">Objeto que representa el peso de la arista</param>
        public void AgregarConexion(Vertice<T,U> inicial, Vertice<T,U> final, U peso)
        {
            //Se verifica que la conexión no exista, si existe se lanza un evento para que el usuario controle el cambio
            Arista<U, T> aris = AristasLis.Where(a =>
            a.Vertices.inicial.ToString().Equals(inicial.ToString()) 
            && a.Vertices.final.ToString().Equals(final.ToString())).FirstOrDefault();
            if(aris != null)
            {
                if (ConexionRepetidaEventHandler != null)
                    ConexionRepetidaEventHandler(aris, new ConexionEventArgs("La conexion ya existe") { Peso = peso });
            }
            //Si no se agrega normalmente la conexión
            else
            {
                Arista<U, T> arista = new Arista<U, T>(peso, inicial, final);
                //Al vertice inicial y final se le avisan sus aristas
                //inicial.Aristas.Add(arista);
                final.Aristas.Add(arista);

                //Se agregan los vertices y aristas a la lista del grafo para que sepa cuales tiene, se usa ExisteVertice que retorna un bool
                if (!ExisteVertice(inicial))
                    VerticesLis.Add(inicial);
                if (!ExisteVertice(final))
                    VerticesLis.Add(final);
                AristasLis.Add(arista);
            }
        }

        private bool ExisteVertice(Vertice<T,U> vertice)
        {
            var it = VerticesLis.Where(x => x.ToString().Equals(vertice.ToString())).FirstOrDefault();
            if (it == null)
                return false;
            return true;
        }

        public void ImprimirGrafo()
        {
            foreach (var item in AristasLis)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public class ConexionEventArgs: EventArgs
    {
        public string Mensaje { get; set; }
        public object Peso { get; set; }

        public ConexionEventArgs(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}
