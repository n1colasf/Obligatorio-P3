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
            List<Socio> listadoSocios = FachadaClub.ListarSocios();
            ViewBag.listadoSocios = listadoSocios;
            return View();
        }
        public ActionResult DetalleSocio(int cedula)
        {
            Socio socio = FachadaClub.BuscarPorId(cedula);
            ViewBag.socio = socio;
            return View();
        }
        [HttpPost]
        public ActionResult DetalleSocio(int cedula, string nombre, DateTime fechaNac, DateTime fechaIngreso, bool activo)
        {
            return View();
        }
        public ActionResult PagarMensualidad(int cedula)
        {
            Socio socio = FachadaClub.BuscarPorId(cedula);
            ViewBag.socio = socio;
            return View();
        }
        [HttpPost]
        public ActionResult PagarMensualidad(int cedula, string nombre, DateTime fechaNac, DateTime fechaIngreso, bool activo, int selectMembresia, int cantActividadesCuponera = 0)
        {
            //ESTO SE ROMPE CUANDO EN EL FORMULARIO VIENE LA CANTIDAD DE ACTIVIDADES EN NULL
            double costoCuota;
            if (selectMembresia == 1)
            {
                costoCuota = FachadaClub.MostrarCostoPaseLibre(cedula);
                ViewBag.slectedOption = 1;
                ViewBag.showCuponera = "none";
            } else
            {
                costoCuota = FachadaClub.MostrarCostoCuponera(cedula, cantActividadesCuponera);
                ViewBag.slectedOption = 2;
                ViewBag.showCuponera = "block";
                ViewBag.cantActividadesCuponera = cantActividadesCuponera;
            }
            ViewBag.costoCuota = costoCuota;
            Socio socio = FachadaClub.BuscarPorId(cedula);
            ViewBag.socio = socio;
            return View();
        }
        public ActionResult Logout()
        {
            Session["Logueado"] = null;
            return Redirect("/funcionario/Login");
        }
        public ActionResult ListarActividades()
        {
            ServicioAltaSocioActividad servicioActividad = new ServicioAltaSocioActividad();
            //servicioActividad.Open(); ESTO PARA QUE ERA? NO SIRVE
            //TRAER LOS HORARIOS DE CADA ACTIVIDAD
            //ASOCIAR ACTIVIDAD AL SOCIO
            IEnumerable<DtoActividad> listaActividades = servicioActividad.ListarActividades();
            ViewBag.ListaActividades = listaActividades;
            return View();
        }
    }
}