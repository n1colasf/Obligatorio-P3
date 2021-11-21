using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuponera : FormaDePago
    {
        public static double DescuentoC { get; set; } = 0.15; //En porcentaje
        public int CantActividades { get; set; }
        public static int MinActParaDesc { get; set; } = 30;
        public override double CalcularCosto()
        {
            double precioActividad = Actividad.PrecioActividad;
            double total = CantActividades * precioActividad;
            if (DescontarActividad())
            {
                total *= (1-DescuentoC);
            }
            return total;
        }
        public override double CalcularDescAplicado()
        {
            return DescontarActividad() ? CantActividades * Actividad.PrecioActividad - CalcularCosto() : 0; 
        }

        private bool DescontarActividad()
        {
            return CantActividades > MinActParaDesc;
        }
    }
}