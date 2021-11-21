using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Pagos")]
    public class Pago
    {
        public int Id { get; set; }
        public int CedulaSocio { get; set; }
        public DateTime Fecha { get; set; }
        public double DescuentoPL { get; set; }
        public double AntiguedadPL { get; set; }
        public double PrecioPL { get; set; }
        public double DescuentoC { get; set; }
        public int CantActividadesC { get; set; }
        public double PrecioTotalC { get; set; }
    }
}
