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
        public static bool AltaFuncionario(string email, string password)
        {
            Funcionario func = BuscarFuncionario(email);
            if (func != null)
                return false;
            func = new Funcionario()
            {
                Email = email,
                Password = password
            };
            RepoFuncionarios repoFunc = new RepoFuncionarios();
            bool ret = repoFunc.Alta(func);
            return ret;

        }
        public static bool AltaSocio(int cedula, string nombre, DateTime fechaNac)
        {
            bool ret = false;
            List<Actividad> actividades = new List<Actividad>();
            Socio socio = new Socio()
            {
                Cedula = cedula,
                Nombre = nombre,
                FechaNac = fechaNac,
                Actividades = actividades,
                FechaIngreso = DateTime.Now,
                Activo = true
            };
            RepoSocios repoSocios = new RepoSocios();
            ret = repoSocios.Alta(socio);
            return ret;

        }
        public static bool ModificarSocio(int cedula, string nombre, DateTime fechaNac)
        {
            bool ret = false;
            Socio socio = BuscarPorId(cedula);
            if (!socio.Activo) return false;

            if (socio != null) 
            { 
            socio.Nombre = nombre;
            socio.FechaNac = fechaNac;
            
            RepoSocios repoSocios = new RepoSocios();
            ret = repoSocios.Modificacion(socio);
            }
            return ret;

        }
        public static bool DarDeBajaSocio(int cedula)
        {
            bool ret;
            RepoSocios repoSocios = new RepoSocios();
            ret = repoSocios.Baja(cedula);
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
        public static bool AltaHorario(int dia, int hora)
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
        public static Funcionario LogIn(string email, string password)
        {
            Funcionario func = BuscarFuncionario(email);
            if (func != null && func.Email == email && func.Password == password)
            {
                return func;
            } else
            {
                return null;
            }
        }
        public static bool AnotarseAActividad(Socio socio, int idActividad, int hora)
        {
            bool ret = false;
            if (VerificarMensualidad(socio))
            {
                RepoSocios repoSocios = new RepoSocios();
                ret = repoSocios.AltaSocioActividad(socio, idActividad, hora);
            }
            return ret;
        }
        public static bool SocioInscriptoActividad(int idActividad, int cedula, int horaActividad)
        {
            RepoActividades repoActividades = new RepoActividades();
            return repoActividades.SocioInscriptoActividad(idActividad, cedula, horaActividad);
        }
        public List<Actividad> IngresosPorFecha(int cedula, DateTime fecha)
        {
            throw new NotImplementedException();
        }
        public List<Actividad> ProximasActividades(DateTime fecha)
        {
            throw new NotImplementedException();
        }
        public static Cuponera CalcularCuponera(int cedula, int cantidadActividades)
        {
            if (cantidadActividades < 8 || cantidadActividades > 60)
                return null;
            RepoSocios repoSocios = new RepoSocios();
            Socio socio = repoSocios.BuscarPorId(cedula);
            Cuponera cup = new Cuponera()
            {
                Socio = socio,
                Fecha = DateTime.Now,
                CantActividades = cantidadActividades
            };
            return cup;
        }
        public static bool VerificarMensualidad(Socio socio)
        {
           RepoPagos repoPagos = new RepoPagos();
           return repoPagos.VerificarMensualidad(socio);
        }
        public static double MostrarCostoCuponera(int cedula, int cantidadActividades)
        {
            return CalcularCuponera(cedula,cantidadActividades).CalcularCosto();
        }
        public static bool RegistrarPagoCuponera(int cedula, int cantidadActividades)
        {
            Socio socio = BuscarPorId(cedula);
            bool mensualidadPaga = false;
            if (socio != null) mensualidadPaga = VerificarMensualidad(socio);
            if (cantidadActividades <= 8 || cantidadActividades > 60 || mensualidadPaga) return false;
            Cuponera cup = CalcularCuponera(cedula, cantidadActividades);
            RepoPagos repoPagos = new RepoPagos();
            bool ret = repoPagos.Alta(cup);
            return ret;
        }
        private static PaseLibre CalcularPaseLibre(int cedula)
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
                return pas;
            } catch(Exception ex)
            {
                return null; // VER QUE HACEMOS CON LAS EXEPCIONES
            }
        }
        public static double MostrarCostoPaseLibre(int cedula)
        {
            return CalcularPaseLibre(cedula).CalcularCosto();
        }
        public static bool RegistrarPagoPaseLibre(int cedula)
        {
            PaseLibre pas = CalcularPaseLibre(cedula);
            RepoPagos repoPagos = new RepoPagos();
            bool ret = repoPagos.Alta(pas);
            return ret;        
        }
        public void ExportarInformacion()
        {
            throw new NotImplementedException();
        }
        public static Funcionario BuscarFuncionario(string email)
        {
            RepoFuncionarios repoFunc = new RepoFuncionarios();
            return repoFunc.BuscarPorEmail(email);
        }
        public static Socio BuscarPorId(int cedula)
        {
            RepoSocios repoSocios = new RepoSocios();
            return repoSocios.BuscarPorId(cedula);
        }
        public static List<Socio> ListarSocios()
        {
            RepoSocios repoSocios = new RepoSocios();
            return repoSocios.TraerTodos();
        }
    }
}
