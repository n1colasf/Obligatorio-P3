using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Repositorios;
using WCF_AltaSocioActividad;

namespace MVC_Club.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string contrasena)
        {
            Funcionario funcLoggedin = FachadaClub.LogIn(email, contrasena);
            if (funcLoggedin != null)
            {
                Session["Logueado"] = true;
                return Redirect("/funcionario/Buscar");
            }
            else
            {
                ViewBag.mensaje = "El funcionario no existe.";
            }
            return View();
        }
        public ActionResult Registro()
        {
            ViewBag.funcionarioCreado = false;
            return View();
        }
        [HttpPost]
        public ActionResult Registro(string email, string password)
        {
            bool funcionarioCreado = FachadaClub.AltaFuncionario(email, password);
            ViewBag.funcionarioCreado = funcionarioCreado;
            if (funcionarioCreado)
            {
                ViewBag.mensajeExito = "Funcionario registrado con éxito.";
                Session["Logueado"] = true;
                return View("Buscar");
            }
            else
            {
                ViewBag.mensaje = "No se pudo registrar el funcionario.";
                return View("");
            }
        }
    }
}