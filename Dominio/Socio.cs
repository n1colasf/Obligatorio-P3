using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Socio
    {
        #region Atributos
        private int cedula;
        private string nombre;
        private DateTime fechaNac;
        private DateTime fechaIngreso;
        private bool activo;
        private List<Actividad> actividades;
        #endregion

        #region Propiedades
        public int Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public List<Actividad> Actividades
        {
            get { return actividades; }
            set { actividades = value; }
        }
        #endregion

        #region Constructor
        public Socio(int cedula, string nombre, DateTime fechaNac, DateTime fechaIngreso, List<Actividad> actividades)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.fechaNac = fechaNac;
            this.fechaIngreso = fechaIngreso;
            activo = true;
            this.actividades = actividades;
        }
        #endregion

    }
}
