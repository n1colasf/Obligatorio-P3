using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Actividad
    {
        public int Id { get; }
        private static int ContId;
        public string Nombre { get; set; }
        public int EdadMin { get; set; }
        public int EdadMax { get; set; }
        public int Cupo { get; set; }
        public static double PrecioActividad { get; set; } = 500;
        public List<Horario> Horarios { get; set; }
        public List<Socio> Participantes { get; set; }
    }
}