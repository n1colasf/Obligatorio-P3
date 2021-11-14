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
        public ActionResult Buscar()
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/Inicio/Login");
            }
            return View();
        }
        public ActionResult Listar()
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/Inicio/Login");
            }
            List<Socio> listadoSocios = FachadaClub.ListarSocios();
            return View(listadoSocios);
        }
        public ActionResult DetalleSocio(int cedula = 0)
        {
            ViewBag.mensajeDatosActualizados = "";
            ViewBag.SocioModificado = false;
            if(cedula == 0)
            {
                ViewBag.mensaje = "Ingresa una cédula válida para ver el detalle.";
                return View("Buscar");
            }
            ViewBag.mensaje = "";
            if (Session["Logueado"] == null)
            {
                return Redirect("/Inicio/Login");
            }
            Socio socio = FachadaClub.BuscarPorId(cedula);
            if(socio == null)
            {
                ViewBag.mensaje = "No se encontró socio con la cédula ingresada.";
                return View("Buscar");
            }
            ViewBag.mensualidadPaga = FachadaClub.VerificarMensualidad(socio);
            return View(socio);
        }
        [HttpPost]
        public ActionResult DetalleSocio(int cedula, string nombre, DateTime fechaNac)
        {
            ViewBag.mensualidadPaga = false;
            ViewBag.mensajeDatosActualizados = "";
            bool socioModificado = FachadaClub.ModificarSocio(cedula, nombre, fechaNac);
            ViewBag.mensajeDatosActualizados = (socioModificado) ? "Se modificaron los datos con éxito." : "No se pudo actualizar datos.";
            ViewBag.socioModificado = socioModificado;
            Socio socio = FachadaClub.BuscarPorId(cedula);
            ViewBag.mensualidadPaga = FachadaClub.VerificarMensualidad(socio);
            return View(socio);
        }
        public ActionResult PagarMensualidad(int cedula = 0)
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/Inicio/Login");
            }
            Socio socio = FachadaClub.BuscarPorId(cedula);
            return View(socio);
        }
        [HttpPost]
        public ActionResult PagarMensualidad(int cedula, int membresia, int cantActividades = 0)
        {
            Socio socio = FachadaClub.BuscarPorId(cedula);
            ViewBag.mensualidadPaga = FachadaClub.VerificarMensualidad(socio);
            if (membresia == 1 && !ViewBag.mensualidadPaga)
            {
                ViewBag.mensualidadPaga = FachadaClub.RegistrarPagoPaseLibre(cedula);
            } else if(membresia == 2 && !ViewBag.mensualidadPaga)
            {
                ViewBag.mensualidadPaga = FachadaClub.RegistrarPagoCuponera(cedula, cantActividades);
            }
            if (ViewBag.mensualidadPaga)
            {
                ViewBag.mensaje = "El pago ha sido realizado con éxito.";
                ViewBag.textMensualidadPaga = "success";
            } else
            {
                ViewBag.mensaje = "No se pudo realizar el pago.";
                ViewBag.textMensualidadPaga = "danger";
            }
            return View(socio);
        }
        public ActionResult MostrarCostoMensualidad(int cedula)
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/Inicio/Login");
            }
            Socio socio = FachadaClub.BuscarPorId(cedula);

            return View("PagarMensualidad",socio);
        }
        [HttpPost]
        public ActionResult MostrarCostoMensualidad(int cedula, string nombre, DateTime fechaNac, DateTime fechaIngreso, int selectMembresia, int cantActividades = 0)
        {
            Socio socio = FachadaClub.BuscarPorId(cedula);
            ViewBag.mensualidadPaga = FachadaClub.VerificarMensualidad(socio);
            if (ViewBag.mensualidadPaga)
            {
                ViewBag.mensaje = "El socio ya tiene la cuota paga.";
                ViewBag.textMensualidadPaga = "danger";
                return View("PagarMensualidad",socio);
            }
            double costoCuota;
            if (selectMembresia == 1)
            {
                costoCuota = FachadaClub.MostrarCostoPaseLibre(cedula);
                ViewBag.slectedOption = 1;
                ViewBag.showCuponera = "none";
            }
            else
            {
                costoCuota = FachadaClub.MostrarCostoCuponera(cedula, cantActividades);
                ViewBag.slectedOption = 2;
                ViewBag.showCuponera = "block";
                ViewBag.cantActividades = cantActividades;
            }
            ViewBag.costoCuota = costoCuota;
            
            return View("PagarMensualidad",socio);
        }
        public ActionResult DarDeBaja(int cedula = 0)
        {
            bool dadoDeBaja = FachadaClub.DarDeBajaSocio(cedula);
            ViewBag.mensajeDatosActualizados = (dadoDeBaja) ? "El socio fue dado de baja." : "";
            Socio socio = FachadaClub.BuscarPorId(cedula);
            return View("DetalleSocio",socio);
        }
        public ActionResult Logout()
        {
            Session["Logueado"] = null;
            return Redirect("/Inicio/Login");
        }
        public ActionResult ListarActividades(int cedula = 0, string mensaje = "")
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/Inicio/Login");
            }
            Socio socio = FachadaClub.BuscarPorId(cedula);
            if (socio == null) return View("Buscar");
            ServicioAltaSocioActividad servicioActividad = new ServicioAltaSocioActividad();
            IEnumerable<DtoActividad> listaActividades = servicioActividad.ListarActividades(cedula);
            ViewBag.cedulaSocio = socio.Cedula;
            ViewBag.mensaje = mensaje;
            return View(listaActividades);
        }
        public ActionResult AnotarseAActividad(int cedula, int idActividad, int hora)
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/Inicio/Login");
            }
            Socio socio = FachadaClub.BuscarPorId(cedula);
            if(socio == null) return View("Buscar");
            DtoSocio dtoSocio = new DtoSocio
            {
                Cedula = socio.Cedula,
                Nombre = socio.Nombre,
                FechaNac = socio.FechaNac,
                FechaIngreso = socio.FechaIngreso,
                Activo = socio.Activo,
                Actividades = socio.Actividades
            };
            ServicioAltaSocioActividad servicioActividad = new ServicioAltaSocioActividad();
            bool anotadoAactividad = servicioActividad.AnotarseAActividad(dtoSocio, idActividad,hora);
            ViewBag.mensaje = (anotadoAactividad) ? "El socio se inscribió corretamente." : "No se puede inscribir a una misma actividad mas de una vez en el mismo día.";
            return Redirect("/Funcionario/ListarActividades?cedula="+cedula+"&mensaje="+ ViewBag.mensaje);
        }
        public ActionResult IngresosPorFecha(int cedula)
        {
            return View();
        } //FALTA TERMINAR DE IMPLEMENTAR
        [HttpPost]
        public ActionResult IngresosPorFecha(int cedula, DateTime fecha) //FALTA TERMINAR DE IMPLEMENTAR
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/Inicio/Login");
            }
            Socio socio = FachadaClub.BuscarPorId(cedula);
            if (socio == null) return View("Buscar");

            List<Actividad> ingresosPorFecha = FachadaClub.IngresosPorFecha(cedula, fecha);
            ViewBag.ingresosPorFecha = ingresosPorFecha;
            return View();
        }
    }
}