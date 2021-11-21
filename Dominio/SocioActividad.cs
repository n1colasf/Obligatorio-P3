using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Socios_Actividad")]
    public class SocioActividad
    {
        public int Id { get; set; }
        public int IdActividad { get; set; }
        public int CedulaSocio { get; set; }
        public DateTime Fecha { get; set; }
        public int HoraActividad { get; set; }
    }
}
