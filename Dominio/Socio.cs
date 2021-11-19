using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Socio
    {
        public int Id { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }
        public List<Actividad> Actividades { get; set; }
        public virtual ICollection<Actividad> SocioActividades { get; set; }//PENDIENTE PARA RELACION N-N

        public bool ValidarCedula(int cedula)
        {
            bool valido = false;
            if (cedula.ToString().Length >= 7 && cedula.ToString().Length <= 9)
            {
                valido = true;
            }

            return valido;
        }

        public bool ValidarNombre(string nombre)
        {
            bool valido = true;
            if (nombre.Length > 6)
            {
                for (int i = 0; i < nombre.Length; i++)
                {
                    if (nombre[0] == ' ' || nombre[nombre.Length - 1] == ' ' || Char.IsNumber(nombre[i]))
                    {
                        valido = false;
                        continue;
                    }
                }

            }
            return valido;
        }

        public bool ValidarEdad(DateTime fechaNac)
        {
            bool valido = false;
            int edad = calcularEdad(fechaNac);
            if (edad > 3 && edad < 90)
            {
                valido = true;
            }

            return valido;
        }
        private int calcularEdad(DateTime fechaNac)
        {
            int edad = DateTime.Today.Year - fechaNac.Year;
            if (DateTime.Today < fechaNac.AddYears(edad))
            {
                edad--;
            }
            return edad;
        }

    }

}
