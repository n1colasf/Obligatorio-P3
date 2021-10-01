using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Socio
    {
        private int cedula { get; set; }
        private string nombre { get; set; }
        private DateTime fechaNac { get; set; }
        private DateTime fechaIngreso { get; set; }
        private bool activo { get; set; }
        private List<Actividad> actividades { get; set; }
    }
}
