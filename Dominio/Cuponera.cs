using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuponera : FormaDePago
    {
        #region Atributos
        private int descuentoC;
        private int cantActividades;
        private double precioActividad;
        #endregion

        #region Propiedades
        public int DescuentoC
        {
            get { return descuentoC; }
            set { descuentoC = value; }
        }
        public int CantActividades
        {
            get { return cantActividades; }
            set { cantActividades = value; }
        }
        public double PrecioActividad
        {
            get { return precioActividad; }
            set { precioActividad = value; }
        }
        #endregion

        #region Constructor
        //FixMe: no me doy cuenta por que no me deja pasarle los parametros padre
        public Cuponera(int descuentoC, int cantActividades, double precioActividad) : base(fecha, socio)
        {
            this.descuentoC = descuentoC;
            this.cantActividades = cantActividades;
            this.precioActividad = precioActividad;

        }
        #endregion

        #region MetodosDeInstancia
        public override double CalcularCosto()
        {
            throw new NotImplementedException();
        }
        public bool DescontarActividad()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
