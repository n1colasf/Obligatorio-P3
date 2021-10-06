using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class FormaDePago
    {
        public int Id { get; }
        public DateTime Fecha { get; set; }
        public Socio Socio { get; set; }

        //FixMe: Este atributo era necesario?
        private static int ContId;

        public abstract double CalcularCosto();
        public abstract double CalcularDescAplicado();
    }
}