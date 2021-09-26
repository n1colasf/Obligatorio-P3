using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class FormaDePago
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Socio Socio { get; set; }
        
        //FixMe: Este atributo era necesario?
        private int ContId { get; set; }

        public abstract double CalcularCosto();
    }
}
