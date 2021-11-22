using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Club.Models
{
    public class ActividadModel
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "El largo del nombre puede contener hasta 50 caracteres")]
        [Required]
        public string Nombre { get; set; }
        [Required, Range(3, 89)]
        public int EdadMin { get; set; }
        [Required, Range(4, 90)]
        public int EdadMax { get; set; }
        [Required, Range(1, 100)]
        public int Cupo { get; set; }

        public override string ToString()
        {
            return "ID: " + Id + " - Nombre: " + Nombre + " - Edad Mínima: " + EdadMin + " - Edad Máxima: " + EdadMax + " - Cupo: " + Cupo;
        }

    }
}