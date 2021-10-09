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
        public bool AnotarseAActividad(Socio socio, Actividad actividad)
        {
            return true;
        }
        public IEnumerable<DtoActividad> ListarActividades()
        {
            IEnumerable<Actividad> listaActividadesDB = repoActividades.TraerTodos();
            IEnumerable<DtoActividad> listaActividades = ObtenerListaDtosActividades(listaActividadesDB);
            return listaActividades;
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
    }
}
