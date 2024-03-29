﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using MVC_Club.Models;
using Dominio;

namespace MVC_Club.Controllers
{
    public class ActividadesController : Controller
    {
        private HttpClient clienteApi = new HttpClient();
        private HttpResponseMessage respuesta = new HttpResponseMessage();
        private Uri UriBase = new Uri(@"https://localhost:44395/api/actividades");

        private void ConfigurarCliente()
        {
            clienteApi.BaseAddress = UriBase;
            clienteApi.DefaultRequestHeaders.Accept.Clear();
            clienteApi.DefaultRequestHeaders.Accept.Add
            (new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Actividades
        public ActionResult Index()
        {
            try
            {
                ConfigurarCliente();
                respuesta = clienteApi.GetAsync(clienteApi.BaseAddress).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = respuesta.Content.ReadAsAsync<IEnumerable<Actividad>>().Result;
                    if (contenido != null)
                    {
                        IEnumerable<Actividad> contenidoAux = contenido;
                        IEnumerable<ActividadModel> actividadesModel = castActividadToActividadModel(contenidoAux);
                        return View(actividadesModel);
                    }
                }
                ModelState.AddModelError("Error Api", "No se obtuvo respuesta " +
                respuesta.ReasonPhrase);
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Se produjo una excepción: ", ex.Message);
                return View();
            }
        }

        //GET: Actividades/Filter
        public ActionResult Filter()
        {
            return View();
        }

        //POST: Actividades/Filter
        [HttpPost]
        public ActionResult Filter(string nombreContent = "", int edadMin = 0, int dia = 0, int hora = 0)
        {
            try
            {
                //ConfigurarCliente();
                //respuesta = clienteApi.GetAsync(clienteApi.BaseAddress + "nombreContent=" + nombreContent
                //    + "edadMin=" + edadMin + "dia=" + dia + "hora=" + hora).Result;

                ConfigurarCliente();
                respuesta = clienteApi.GetAsync(clienteApi.BaseAddress).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = respuesta.Content.ReadAsAsync<IEnumerable<Actividad>>().Result;
                    if (contenido != null)
                    {
                        IEnumerable<Actividad> contenidoAux = contenido;
                        IEnumerable<ActividadModel> actividadesModel = castActividadToActividadModel(contenidoAux);
                        return View(actividadesModel);
                    }
                }
                ModelState.AddModelError("Error Api", "No se obtuvo respuesta " +
                respuesta.ReasonPhrase);
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Se produjo una excepción: ", ex.Message);
                return View();
            }
        }
        // GET: Actividades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actividades/Create
        [HttpPost]
        public ActionResult Create(ActividadModel act)
        {
            try
            {
                if (act != null && ModelState.IsValid)
                {
                    ConfigurarCliente();
                    var ruta = clienteApi.BaseAddress;
                    var accesoApi = clienteApi.PostAsJsonAsync(ruta, act);
                    accesoApi.Wait();
                    respuesta = accesoApi.Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        TempData["ResultadoOperacion"] = "Actividad Agregada ";
                        return RedirectToAction("Index");
                    }
                    ViewBag.Mensaje = "No fue posible ingresar la Actividad. Error: " + respuesta.StatusCode;
                    return View(act);
                }
                else
                {
                    ViewBag.Mensaje = "Por favor, verifique los datos ingresados";
                    return View(act);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        private IEnumerable<ActividadModel> castActividadToActividadModel(IEnumerable<Actividad> actividades)
        {
            List<ActividadModel> actividadesModel = new List<ActividadModel>();

            foreach (Actividad act in actividades)
            {
                actividadesModel.Add(new ActividadModel
                {
                    Nombre = act.Nombre,
                    EdadMin = act.EdadMin,
                    EdadMax = act.EdadMax,
                    Cupo = act.Cupo
                });
            }

            return actividadesModel;

        }

        // GET: Actividades/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Actividades/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Actividades/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Actividades/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Actividades/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
