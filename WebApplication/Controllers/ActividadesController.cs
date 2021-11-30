using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repositorios;
using Dominio;

namespace WebApplication.Controllers
{
    public class ActividadesController : ApiController
    {
        // GET: api/Actividades
        public IEnumerable<Actividad> Get()
        {
            RepoActividades repoActividades = new RepoActividades();
            var actividades = repoActividades.TraerTodos();
            return actividades;
        }

        //NO FUNCIONA EL METODO RECIBIENDO MAS DE 1 PARAMETRO!!
        // GET: api/Actividades/5
        //[Route("api/actividades/filter")] //Creo que esto ya no es necesario porque tiene la ruta en la config
        //[HttpPost]
        //public IEnumerable<Actividad> Get(string nameContent, int edad, int dia, int hora)
        //{
        //    RepoActividades repoActividades = new RepoActividades();
        //    var actividades = repoActividades.FiltrarActividades(nameContent, edad, dia, hora);
        //    return actividades;
        //}
        [Route("api/actividades/filter")] //Creo que esto ya no es necesario porque tiene la ruta en la config
        public IEnumerable<Actividad> Get(string nameContent)
        {
            RepoActividades repoActividades = new RepoActividades();
            var actividades = repoActividades.FiltrarActividades(nameContent);
            return actividades;
        }
        //[Route("api/actividades/ingresos")] //Creo que esto ya no es necesario porque tiene la ruta en la config
        //public IEnumerable<SocioActividad> Get(int cedula)
        //{
        //    RepoActividades repoActividades = new RepoActividades();
        //    var actividades = repoActividades.ListarActividadesSocio(cedula);
        //    return actividades;
        //}

        // POST: api/Actividades-
        public void Post([FromBody]Actividad nuevaActividad)
        {
            RepoActividades repoActividades = new RepoActividades();
            repoActividades.Alta(nuevaActividad);
        }

        // PUT: api/Actividades/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Actividades/5
        public void Delete(int id)
        {
        }
    }
}
