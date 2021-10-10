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
            } else
            {
                ViewBag.mensaje = "No se pudo registrar el funcionario.";
                return View("");
            }
        }
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult RegistroSocio()
        {
            ViewBag.socioCreado = false;
            return View();
        }
        [HttpPost]
        public ActionResult RegistroSocio(int cedula, string nombre, DateTime fechaNac)
        {
            bool socioCreado = FachadaClub.AltaSocio(cedula, nombre, fechaNac);
            ViewBag.mensaje = (socioCreado) ? "Socio registrado con éxito." : "No se pudo registrar el socio.";
            ViewBag.socioCreado = socioCreado;
            return View();
        }
        public ActionResult ModificarSocio(int cedula = 0)
        {
            // NO ESTA FUNCIONANDO
            ViewBag.socioModificado = false;
            return View("DetalleSocio");
        }
        [HttpPost]
        public ActionResult ModificarSocio(int cedula, string nombre, DateTime fechaNac, DateTime fechaIngreso, bool activo)
        {
            //NO ESTA FUNCIONANDO
            bool socioModificado = FachadaClub.ModificarSocio(cedula, nombre, fechaNac, activo);
            ViewBag.mensaje = (socioModificado) ? "Se modificaron los datos con éxito." : "No se pudo actualizar datos.";
            ViewBag.socioCreado = socioModificado;
            Socio socio = FachadaClub.BuscarPorId(cedula);
            ViewBag.socio = socio;
            return View("DetalleSocio");
        }
        public ActionResult Buscar()
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/funcionario/Login");
            }
            return View();
        }
        public ActionResult Listar()
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/funcionario/Login");
            }
            List<Socio> listadoSocios = FachadaClub.ListarSocios();
            ViewBag.listadoSocios = listadoSocios;
            return View();
        }
        public ActionResult DetalleSocio(int cedula = 0)
        {
            if(cedula == 0)
            {
                ViewBag.mensaje = "Ingresa una cédula válida para ver el detalle.";
                return View("Buscar");
            }
            ViewBag.mensaje = "";
            if (Session["Logueado"] == null)
            {
                return Redirect("/funcionario/Login");
            }
            Socio socio = FachadaClub.BuscarPorId(cedula);
            if(socio == null)
            {
                ViewBag.mensaje = "No se encontró socio con la cédula ingresada.";
                return View("Buscar");
            }
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
            if (Session["Logueado"] == null)
            {
                return Redirect("/funcionario/Login");
            }
            Socio socio = FachadaClub.BuscarPorId(cedula);
            ViewBag.socio = socio;
            return View();
        }
        public ActionResult DarDeBaja(int cedula = 0)
        {
            bool dadoDeBaja = FachadaClub.DarDeBajaSocio(cedula);
            ViewBag.mensajeDatosActualizados = (dadoDeBaja) ? "El socio fue dado de baja." : "";
            Socio socio = FachadaClub.BuscarPorId(cedula);
            ViewBag.socio = socio;
            return View("DetalleSocio");
        }
        [HttpPost]
        public ActionResult PagarMensualidad(int cedula, string nombre, DateTime fechaNac, DateTime fechaIngreso, bool activo, int selectMembresia, int cantActividadesCuponera = 0)
        {
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
            if (Session["Logueado"] == null)
            {
                return Redirect("/funcionario/Login");
            }
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