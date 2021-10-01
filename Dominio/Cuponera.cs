using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuponera : FormaDePago
    {
        public int DescuentoC { get; set; }
        public int CantActividades { get; set; }
        private double PrecioActividad { get; set; }
        public override double CalcularCosto()
        {
            throw new NotImplementedException();
        }
        public bool DescontarActividad()
        {
            throw new NotImplementedException();
        }
    }
}