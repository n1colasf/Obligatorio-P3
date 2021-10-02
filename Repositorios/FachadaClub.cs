using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class FachadaClub
    {
        public static bool AltaSocio(int cedula, string nombre, DateTime fechaNac, DateTime fechaIngreso)
        {
            bool ret = false;
            List<Actividad> actividades = new List<Actividad>();
            Socio socio = new Socio()
            {
                Cedula = cedula,
                Nombre = nombre,
                FechaNac = fechaNac,
                Actividades = actividades,
                FechaIngreso = fechaIngreso,
                Activo = true
            };
            RepoSocios repoSocios = new RepoSocios();
            ret = repoSocios.Alta(socio);
            return ret;

        }

        public bool LogIn(string email, string password)
        {
            throw new NotImplementedException();
        }
        public bool LogOut()
        {
            throw new NotImplementedException();
        }
        public bool AnotarseAActividad(Socio socio, Actividad actividad)
        {
            throw new NotImplementedException();
        }
        public List<Actividad> IngresosPorFecha(int cedula, DateTime fecha)
        {
            throw new NotImplementedException();
        }
        public List<Actividad> ProximasActividades(DateTime fecha)
        {
            throw new NotImplementedException();
        }
        public bool RegistrarPago(int id)
        {
            throw new NotImplementedException();
        }
        public void ExportarInformacion()
        {
            throw new NotImplementedException();
        }

    }
}
