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
        public double PrecioPL { get; set; } = 2500; //Precio Cuota Fija
        public override double CalcularCosto()
        {
            double costo = PrecioPL;
            if (Antiguedad >= 5)
            {
                costo *= (1-DescuentoPL);
            }
            return costo;
        }
        public override double CalcularDescAplicado()
        {
            return (Antiguedad >= 5) ? PrecioPL - CalcularCosto() : 0;
        }
    }
}
