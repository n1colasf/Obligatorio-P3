using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorios;

namespace MVC_Club.Controllers
{
    public class ImportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Importar(string mensaje = "")
        {
            ViewBag.mensaje = mensaje;
            return View();
        }
        public ActionResult ImportarUsuarios()
        {
            RepoImportar repoImportar = new RepoImportar();
            bool usuariosImportados = repoImportar.ImportarUsuarios();
            ViewBag.mensaje = (usuariosImportados) ? "Se han importado Usuarios con éxito" : "No se pudo importar datos";
            return Redirect("/Import/Importar?mensaje=" + ViewBag.mensaje);
        }
        public ActionResult ImportarActividades()
        {
            RepoImportar repoImportar = new RepoImportar();
            bool actividadesImportadas = repoImportar.ImportarActividades();
            ViewBag.mensaje = (actividadesImportadas) ? "Se han importado Actividades con éxito" : "No se pudo importar datos";
            return Redirect("/Import/Importar?mensaje=" + ViewBag.mensaje);
        }
    }
}