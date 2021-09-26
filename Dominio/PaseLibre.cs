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
        private int DescuentoPL { get; set; }
        private int PrecioPL { get; set; }
        public override double CalcularCosto()
        {
            throw new NotImplementedException();
        }
    }
}
