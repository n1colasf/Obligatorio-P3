using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorios;

namespace MVC_Club.Controllers
{
    public class ExportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Exportar(string mensaje = "")
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/Inicio/Login");
            }
            ViewBag.mensaje = mensaje;
            return View();
        }
        public ActionResult GuardarTabla(string tabla = "")
        {
            RepoExportar repoExportar = new RepoExportar();
            bool tablaExportada = repoExportar.ExportarTabla(tabla);
            ViewBag.mensaje = (tablaExportada) ? "Tabla exportada con éxito" : "No se pudo exportar la tabla";
            return Redirect("/Export/Exportar?mensaje="+ViewBag.mensaje);
        }

    }
}