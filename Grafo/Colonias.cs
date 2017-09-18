using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class Colonias
    {
        public string Nombre { get; set; }
        public int Habitantes { get; set; }
        public string CodPostal { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

    public class Informacion
    {
        public double CostoTraslado { get; set; }

        public override string ToString()
        {
            return $"{CostoTraslado}";
        }
    }
}
