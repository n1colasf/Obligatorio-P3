using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Repositorios;

namespace MVC_Club.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
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
            Funcionario funcLoggedin = FachadaClub.LogIn(email,contrasena);
            if (funcLoggedin != null)
            {
                Session["Logueado"] = true;
                return Redirect("/funcionario/Buscar");
            }
            else
            {
                ViewBag.mensaje = "Error de login";
            }
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult RegistroSocio()
        {
            return View();
        }
        public ActionResult Buscar()
        {
            return View();
        }
        public ActionResult Listar()
        {
            return View();
        }
        public ActionResult DetalleSocio()
        {
            return View();
        }
        public ActionResult PagarMensualidad()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["Logueado"] = null;
            return Redirect("/funcionario/Login");
        }
    }
}