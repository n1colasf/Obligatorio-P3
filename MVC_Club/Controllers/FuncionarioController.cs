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
            //ViewBag.Funcionario = FachadaClub.VerificarFuncionario(email, contrasena);
            //Usuario unU = ViewBag.Usuario;
            //if (unU != null)
            //{
            //    Session["LogueadoRol"] = unU.Rol;
            //    Session["LogueadoCedula"] = unU.Cedula;
            //    Session["Logueado"] = true;
            //    if (unU.Rol == "Cliente")
            //    {
            //        return Redirect("/Usuario/AccesoCliente?cedula=" + usuario);
            //    }
            //    else if (unU.Rol == "Operador")
            //    {
            //        return Redirect("/Usuario/AccesoOperador");
            //    }
            //}
            //else
            //{
            //    ViewBag.mensaje = "Error de login";
            //}
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
    }
}