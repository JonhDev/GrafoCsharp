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
            //Grafo Generico
            string opc = null;
            GrafoObject<Colonias, Informacion> gGenerico = new GrafoObject<Colonias, Informacion>();
            List<Colonias> listaColonias = new List<Colonias>();
            gGenerico.ConexionRepetidaEventHandler += (obj, arg) =>
            {
                Console.WriteLine(arg.Mensaje + "\n¿Deseas modificar su peso con el que acabas de dar? (s/n)");
                string res = Console.ReadLine();
                if (res.Equals("s"))
                {
                    
                    //int costo = int.Parse(Console.ReadLine());
                    Arista<Informacion, Colonias> arista = obj as Arista<Informacion, Colonias>;
                    arista.Objeto = arg.Peso as Informacion;
                    Console.Write($"El nuevo peso de la conexion es: {arista.Objeto.CostoTraslado} ");
                }
            };

            do
            {
                Console.WriteLine("Creacion de grafos genericos");
                Console.WriteLine("a. Crear Colonia");
                Console.WriteLine("b. Crear conexion entre colonias");
                Console.WriteLine("c. Modificar conexion entre colonias");
                Console.WriteLine("d. Mostrar conexiones");
                Console.WriteLine("e. Salir");
                Console.WriteLine("======================================================");
                Console.Write("Selecciona una opcion: ");
                opc = Console.ReadLine();
                Console.Clear();
                switch (opc)
                {
                    case "a":
                        Console.Write("Ingresa el nombre de la colonia: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingresa el codigo postal de la colonia: ");
                        string codPos = Console.ReadLine();
                        Console.Write("Ingresa el numero de poblacion de la colonia: ");
                        int pobla = int.Parse(Console.ReadLine());
                        listaColonias.Add(new Colonias { Nombre = nombre, CodPostal = codPos, Habitantes = pobla });
                        Console.Clear();
                        Console.WriteLine("--------------------Creada!---------------------\n\n");
                        break;
                    case "b":
                        for(int i = 0; i < listaColonias.Count; i++ )
                            Console.WriteLine($"{i+1}. {listaColonias[i]}");
                        Console.Write("Ingrese el numero de la colonia incial: ");
                        int nIni = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el numero de la colonia final: ");
                        int nfin = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el Costo de traslado de las colonias: ");
                        int costo = int.Parse(Console.ReadLine());
                        gGenerico.AgregarConexion(new Vertice<Colonias, Informacion>(listaColonias[nIni - 1])
                            , new Vertice<Colonias, Informacion>(listaColonias[nfin - 1])
                            , new Informacion { CostoTraslado = costo });
                        Console.Clear();
                        Console.WriteLine("--------------------Creada!---------------------\n\n");
                        break;
                    case "c":
                        break;
                    case "d":
                        Console.WriteLine("<==============> Conexiones <==============>\n");
                        gGenerico.ImprimirGrafo();
                        Console.WriteLine("\n\n--------------------------------------------");
                        break;
                    case "e":
                        Console.WriteLine("Adios");
                        break;
                    default:
                        Console.WriteLine("!!!!!!!!!!!!!!!!!! --Opcion no vaida-- !!!!!!!!!!!!!!!!!!\n\n");
                        break;
                }
            } while (!opc.Equals("e"));
        }
    }
}
