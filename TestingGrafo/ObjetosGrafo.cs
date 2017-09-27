using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGrafo
{
    class Pais
    {
        public string Nombre { get; set; }
        public int CodPais { get; set; }
        public string Moneda { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

    class Distancias
    {
        public double Kilometros { get; set; }

        public override string ToString()
        {
            return string.Format($"{Kilometros} Km");
        }
    }
}
