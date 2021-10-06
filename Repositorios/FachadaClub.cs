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
        private List<Funcionario> funcionarios { get; set; }
        public static bool AltaFuncionario(string email, string password)
        {
            bool ret = false;
            Funcionario func = new Funcionario()
            {
                Email = email,
                Password = password
            };
            RepoFuncionarios repoFunc = new RepoFuncionarios();
            ret = repoFunc.Alta(func);
            return ret;

        }
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

        public static bool AltaActividad(string nombre, int edadMin, int edadMax, int cupo)
        {
            bool ret = false;
            Actividad act = new Actividad()
            {
                Nombre = nombre,
                EdadMin = edadMin,
                EdadMax = edadMax,
                Cupo = cupo
            };
            RepoActividades repoAct = new RepoActividades();
            ret = repoAct.Alta(act);
            return ret;

        }
        public static bool AltaHorario(string dia, int hora)
        {
            bool ret = false;
            Horario horario = new Horario()
            {
                Dia = dia,
                Hora = hora
            };
            RepoHorarios repoHorario = new RepoHorarios();
            ret = repoHorario.Alta(horario);
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
        public bool MostrarCostoCuponera(int cedula, int cantidadActividades)
        {
            //double totalAPagar = cup.CalcularCosto();
            return false;
        }
        public bool MostrarCostoPaseLibre(int cedula)
        {

            return false;
        }
        public static bool RegistrarPagoCuponera(int cedula, int cantidadActividades)
        {
            RepoSocios repoSocios = new RepoSocios();
            Socio socio = repoSocios.BuscarPorId(cedula);
            if (cantidadActividades < 8 || cantidadActividades > 60)
                return false;
            Cuponera cup = new Cuponera()
            {
                Socio = socio,
                Fecha = DateTime.Now,
                CantActividades = cantidadActividades
            };
            RepoPagos repoPagos = new RepoPagos();
            bool ret = repoPagos.Alta(cup);
            return ret;
        }
        public static bool RegistrarPagoPaseLibre(int cedula)
        {
            RepoSocios repoSocios = new RepoSocios();
            Socio socio = repoSocios.BuscarPorId(cedula);
            try
            {
                PaseLibre pas = new PaseLibre()
                {
                    Socio = socio,
                    Fecha = DateTime.Now,
                    Antiguedad = DateTime.Now.Year - socio.FechaIngreso.Year
                };
                RepoPagos repoPagos = new RepoPagos();
                bool ret = repoPagos.Alta(pas);
                return ret;
            } catch(Exception ex)
            {
                return false;
            }
            
        }
        public void ExportarInformacion()
        {
            throw new NotImplementedException();
        }
        public Funcionario VerificarFuncionario(string email, string password)
        {
            Funcionario funcEncontrado = null;
            foreach (Funcionario func in funcionarios) //DE DONDE OBTENEMOS LA LISTA DE FUNCIOARIOS
            {
                if (func.Email == email && func.Password == password)
                {
                    funcEncontrado = func;
                }
            }
            return funcEncontrado;
        }
    }
}
