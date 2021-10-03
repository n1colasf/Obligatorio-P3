using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PaseLibre : FormaDePago
    {
        public int Antiguedad { get; set; }
        public static int MinAntiguedad { get; set; } = 5; //Años
        public static double DescuentoPL { get; set; } = 0.15; //Porcentaje
        public int PrecioPL { get; set; } = 2500; //Precio Cuota Fija
        public override double CalcularCosto()
        {
            throw new NotImplementedException();
        }
    }
}
