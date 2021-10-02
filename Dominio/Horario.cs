using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Horario
    {
        public string Dia { get; set; }
        public int Hora { get; set; }

        public bool ValidarHora(int hora)
        {
            return hora >= 7 && hora <= 23;
        }
    }
}