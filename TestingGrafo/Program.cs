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
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Creacion de grafos genericos");
                Console.ForegroundColor = ConsoleColor.White;
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
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"--------------------{nombre} ha sido creado!---------------------\n\n");
                        Console.ForegroundColor = ConsoleColor.White;
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
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("--------------------Creada!---------------------\n\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "c":
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("<==============> Conexiones <==============>\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        grafo.ImprimirGrafo();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\n--------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "d":
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("<==============> Paises <==============>\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (Pais item in listaPaises)
                            Console.WriteLine(item);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\n--------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "e":
                        for (int i = 1; i <= grafo.AristasLis.Count; i++)
                            Console.WriteLine($"{i}.- {grafo.AristasLis[i-1]}");
                        Console.Write("Cual deseas eliminar? ");
                        int pos = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        if (grafo.EliminarConexion(grafo.AristasLis[pos-1]))
                            Console.WriteLine("------------------ Eliminado -----------------------");
                        else
                            Console.WriteLine("------------------ Error al eliminar -----------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "f":
                        Console.WriteLine("Adios");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("!!!!!!!!!!!!!!!!!! --Opcion no vaida-- !!!!!!!!!!!!!!!!!!\n\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            } while (!opc.Equals("f"));
        }
    }
}
