using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Club.Models
{
    public class SocioActividadModel
    {
        public int Id { get; set; }
        public int IdActividad { get; set; }
        public int CedulaSocio { get; set; }
        public DateTime Fecha { get; set; }
        public int HoraActividad { get; set; }

        public override string ToString()
        {
            return "ID: " + Id + " - IdActividad: " + IdActividad + " - CedulaSocio: " + CedulaSocio + " - Fecha: " + Fecha + " - HoraActividad: " + HoraActividad;
        }
    }
}