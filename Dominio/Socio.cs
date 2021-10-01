using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Socio
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }
        public List<Actividad> Actividades { get; set; }

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
            //6<caracteres &
            //sin espacios al principio o al final & 
            //caracteres alfabeticos
            bool valido = true;

            //FixMe: ver de hacer con una expresion regular
            if (nombre.Length > 6)
            {
                for (int i = 0; i < nombre.Length; i++)
                {
                    if (nombre[0] == ' ' || nombre[nombre.Length - 1] == ' ' || !Double.IsNaN(nombre[i]))
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

            //Determino una variable fechaDeHoy a la que le doy el valor de la fecha actual
            DateTime fechaDeHoy = DateTime.Today;
            //Determino una variable edad la cual iguala a la resta del año de la fecha, menos el año de nacimiento
            int edad = DateTime.Today.Year - fechaNac.Year;
            //Si la fecha de cumpleaños todavia no paso, resto un año al resultado anterior
            if (DateTime.Today < fechaNac.AddYears(edad))
            {
                edad--;
            }

            if (edad > 3 && edad < 90)
            {
                valido = true;
            }

            return valido;
        }
    }
}
