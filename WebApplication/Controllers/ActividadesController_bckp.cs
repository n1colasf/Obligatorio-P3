﻿using System;
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

        // GET: api/Actividades/5
        [Route("{nameContent}/{edad}/{dia}/{hora}")]
        public IEnumerable<Actividad> Get(string nameContent, int edad, int dia, int hora)
        {
            RepoActividades repoActividades = new RepoActividades();
            var actividades = repoActividades.FiltrarActividades(nameContent, edad, dia, hora);
            return actividades;
        }

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
