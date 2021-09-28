using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Repositorios
{
    class RepoSocios : IRepositorio<Socio>
    {
        public bool Alta(Socio obj)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Socio BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Socio obj)
        {
            throw new NotImplementedException();
        }

        public List<Socio> TraerTodos()
        {
            throw new NotImplementedException();
        }

        //Fix me: Van aca los metodos del repo socios
        public bool existeSocio(int cedula)
        {

            //PRUEBAA
            bool existe = false;
            if(BuscarPorId(cedula) != null)
            {
                existe = true;
            }
            return existe;
        }

        public bool validarCedula (string cedula)
        {
            bool valido = false;
            if (cedula.Length >= 7 && cedula.Length <= 9)
            {
                valido = true;
            }

            return valido;
        }

        public bool validarNombre(string nombre)
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
                    if (nombre[0] == ' ' || nombre[nombre.Length-1] == ' ' || !Double.IsNaN(nombre[i]) )
                    {
                        valido = false;
                        continue;
                    }
                }

            }
            return valido;
        }

        public bool validarEdad(DateTime fechaNac)
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

            if (edad >3 && edad < 90)
            {
                valido = true;
            }

            return valido;
        }

    }
}
