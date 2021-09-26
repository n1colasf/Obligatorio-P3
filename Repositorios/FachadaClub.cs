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
        //Este atributo va? porque me obliga a agregar el using Dominio
        //public List<Funcionario> Funcionarios { get; set; }

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
