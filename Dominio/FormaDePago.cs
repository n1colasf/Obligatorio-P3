using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class FormaDePago
    {
        #region Atributos
        private int id;
        private static int contId;
        private DateTime fecha;
        private Socio socio;
        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public Socio Socio
        {
            get { return socio; }
        }
        #endregion

        #region Constructor
        public FormaDePago(DateTime fecha, Socio socio)
        {
            id = contId++;
            this.fecha = fecha;
            this.socio = socio;
        }
        #endregion

        #region MetodosDeClase
        public abstract double CalcularCosto();
        #endregion
    }
}
