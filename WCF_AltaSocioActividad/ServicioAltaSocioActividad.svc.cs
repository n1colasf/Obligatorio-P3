using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dominio;
using Repositorios;

namespace WCF_AltaSocioActividad
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioAltaSocioActividad" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioAltaSocioActividad.svc or ServicioAltaSocioActividad.svc.cs at the Solution Explorer and start debugging.
    public class ServicioAltaSocioActividad : IServicioAltaSocioActividad
    {
        private RepoActividades repoActividades = new RepoActividades();
        private RepoHorarios repoHorarios = new RepoHorarios();
        public bool AnotarseAActividad(DtoSocio dtoSocio, int idActividad, int hora)
        {
            Socio socio = new Socio
            {
                Cedula = dtoSocio.Cedula,
                Nombre = dtoSocio.Nombre,
                FechaNac = dtoSocio.FechaNac,
                FechaIngreso = dtoSocio.FechaIngreso,
                Activo = dtoSocio.Activo,
                Actividades = dtoSocio.Actividades
            };
            return FachadaClub.AnotarseAActividad(socio, idActividad, hora);
        }
        public IEnumerable<DtoActividad> ListarActividades(int cedula) //FALTA FILTRAR LAS ACTIVIDADES QUE EL SOCIO YA HAYA REALIZADO
        {
            List<DtoActividad> listaActividadesConHorario = new List<DtoActividad>();
            Socio socio = FachadaClub.BuscarPorId(cedula);
            bool mensualidadPaga = FachadaClub.VerificarMensualidad(socio);
            IEnumerable<Actividad> listaActividadesDB = repoActividades.TraerTodos();
            IEnumerable<DtoActividad> listaActividades = ObtenerListaDtosActividades(listaActividadesDB);
            IEnumerable<DtoHorarioActividad> listHorarios = ListarHorarios();

            foreach (DtoActividad unaA in listaActividades)
            {
                if(calcularEdad(socio.FechaNac) >= unaA.EdadMin && calcularEdad(socio.FechaNac) <= unaA.EdadMax && mensualidadPaga)
                {
                    foreach (DtoHorarioActividad unH in listHorarios)
                    {
                        if (
                            unaA.Id == unH.IdActividad &&
                            unH.Dia == (int)DateTime.Now.DayOfWeek &&
                            unH.Hora > DateTime.Now.Hour
                            )
                        {
                            unaA.Horarios = new List<DtoHorarioActividad>();
                            unaA.Horarios.Add(unH);
                            listaActividadesConHorario.Add(new DtoActividad
                            {
                                Id = unaA.Id,
                                Nombre = unaA.Nombre,
                                EdadMin = unaA.EdadMin,
                                EdadMax = unaA.EdadMax,
                                Cupo = unaA.Cupo,
                                Horarios = unaA.Horarios
                            });
                        }
                    }
                }
            }
            //FALTA FILTRAR LAS ACTIVIDADES QUE EL SOCIO YA HAYA REALIZADO


            return listaActividadesConHorario;
        }
        public IEnumerable<DtoHorarioActividad> ListarHorarios()
        {
            IEnumerable<Horario> listaHorariosDB = repoHorarios.TraerTodos();
            IEnumerable<DtoHorarioActividad> listaHorarios = ObtenerListaDtosHorarios(listaHorariosDB);
            return listaHorarios;
        }
        private IEnumerable<DtoActividad> ObtenerListaDtosActividades(IEnumerable<Actividad> listaActividadesDB)
        {
            if (listaActividadesDB == null) return null;
            List<DtoActividad> actividadesAux = new List<DtoActividad>();
            foreach (Actividad a in listaActividadesDB)
            {
                actividadesAux.Add(new DtoActividad
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    EdadMin = a.EdadMin,
                    EdadMax = a.EdadMax,
                    Cupo = a.Cupo
                });
            }
            return actividadesAux;
        }
        private IEnumerable<DtoHorarioActividad> ObtenerListaDtosHorarios(IEnumerable<Horario> listaHorariosDB)
        {
            if (listaHorariosDB == null) return null;
            List<DtoHorarioActividad> horariosAux = new List<DtoHorarioActividad>();
            foreach (Horario h in listaHorariosDB)
            {
                horariosAux.Add(new DtoHorarioActividad
                {
                    IdActividad = h.Id,
                    Dia = h.Dia,
                    Hora = h.Hora
                });
            }
            return horariosAux;
        }
        private DtoSocio buscarDtoSocio(int cedula)
        {
            DtoSocio dtoSocio = null;
            Socio socio = FachadaClub.BuscarPorId(cedula);
            if (socio != null)
            {
                dtoSocio = new DtoSocio
                {
                    Cedula = socio.Cedula,
                    Nombre = socio.Nombre,
                    FechaNac = socio.FechaNac,
                    FechaIngreso = socio.FechaIngreso,
                    Activo = socio.Activo,
                    Actividades = socio.Actividades

                };
            }
            return dtoSocio;
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
