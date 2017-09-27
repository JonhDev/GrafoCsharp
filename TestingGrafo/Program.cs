using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo;

namespace TestingGrafo
{
    class Program
    {
        static void Main(string[] args)
        {
            GrafoObject<Pais, Distancias> grafo = new GrafoObject<Pais, Distancias>();
            List<Pais> listaPaises = new List<Pais>();
            string opc = string.Empty;

            grafo.ConexionRepetidaEventHandler += (obj, arg) =>
            {
                Console.WriteLine(arg.Mensaje + "\n¿Deseas modificar su distancia con la que acabas de dar? (s/n)");
                string res = Console.ReadLine();
                if (res.Equals("s"))
                {

                    //int costo = int.Parse(Console.ReadLine());
                    Arista<Distancias, Pais> arista = obj as Arista<Distancias, Pais>;
                    arista.Objeto = arg.Peso as Distancias;
                    Console.Write($"La nueva distancia de la conexion es: {arista.Objeto.Kilometros} ");
                }
            };

            do
            {
                Console.WriteLine("Creacion de grafos genericos");
                Console.WriteLine("a. Registrar Pais");
                Console.WriteLine("b. Crear conexion entre paises");
                Console.WriteLine("c. Mostrar conexiones");
                Console.WriteLine("d. Mostrar paises registrados");
                Console.WriteLine("e. Eliminar conexion");
                Console.WriteLine("f. Salir");
                Console.WriteLine("======================================================");
                Console.Write("Selecciona una opcion: ");
                opc = Console.ReadLine();
                Console.Clear();
                switch (opc)
                {
                    case "a":
                        Console.Write("Ingresa el nombre del pais: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingresa el codigo de pais: ");
                        int codPais = int.Parse(Console.ReadLine());
                        Console.Write("Ingresa el tipo de moneda: ");
                        string moneda = Console.ReadLine();
                        listaPaises.Add(new Pais {  Nombre = nombre, CodPais = codPais, Moneda = moneda });
                        Console.Clear();
                        Console.WriteLine($"--------------------{nombre} ha sido creado!---------------------\n\n");
                        break;
                    case "b":
                        for (int i = 0; i < listaPaises.Count; i++)
                            Console.WriteLine($"{i + 1}. {listaPaises[i]}");
                        Console.Write("Ingrese el numero del pais inicial: ");
                        int nIni = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el numero del pais final: ");
                        int nfin = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese la distancia entre paises: ");
                        double dista = double.Parse(Console.ReadLine());
                        grafo.AgregarConexion(new Vertice<Pais, Distancias>(listaPaises[nIni - 1])
                            , new Vertice<Pais, Distancias>(listaPaises[nfin - 1])
                            , new Distancias { Kilometros = dista });
                        Console.Clear();
                        Console.WriteLine("--------------------Creada!---------------------\n\n");
                        break;
                    case "c":
                        Console.WriteLine("<==============> Conexiones <==============>\n");
                        grafo.ImprimirGrafo();
                        Console.WriteLine("\n\n--------------------------------------------");
                        break;
                    case "d":
                        Console.WriteLine("<==============> Paises <==============>\n");
                        foreach (Pais item in listaPaises)
                            Console.WriteLine(item);
                        Console.WriteLine("\n\n--------------------------------------------");
                        break;
                    case "e":
                        for (int i = 1; i <= grafo.AristasLis.Count; i++)
                            Console.WriteLine($"{i}.- {grafo.AristasLis[i-1]}");
                        Console.Write("Cual deseas eliminar? ");
                        int pos = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if(grafo.EliminarConexion(grafo.AristasLis[pos]))
                            Console.WriteLine("------------------ Eliminado -----------------------");
                        else
                            Console.WriteLine("------------------ Error al eliminar -----------------------");
                        break;
                    case "f":
                        Console.WriteLine("Adios");
                        break;
                    default:
                        Console.WriteLine("!!!!!!!!!!!!!!!!!! --Opcion no vaida-- !!!!!!!!!!!!!!!!!!\n\n");
                        break;
                }
            } while (!opc.Equals("f"));
        }
    }
}
