using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PagoSocio
    {
        public int Id { get; set; }
        public int CedulaSocio { get; set; }
        public string NombreSocio { get; set; }
        public DateTime Fecha { get; set; }
        public double DescuentoPL { get; set; }
        public double PrecioPL { get; set; }
        public double DescuentoC { get; set; }
        public double PrecioTotalC { get; set; }
    }
}
