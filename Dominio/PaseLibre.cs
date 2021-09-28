using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PaseLibre : FormaDePago
    {
        #region Atributos
        private int antiguedad;
        private int descuentoPL;
        private int precioPL;
        #endregion

        #region Propiedades
        public int Antiguedad
        {
            get { return antiguedad; }
            set { antiguedad = value; }
        }
        public int DescuentoPL
        {
            get { return descuentoPL; }
            set { descuentoPL = value; }
        }
        public int PrecioPL
        {
            get { return precioPL; }
            set { precioPL = value; }
        }
        #endregion

        #region Constructor
        //FixMe: no me doy cuenta por que no me deja pasarle los parametros padre
        public PaseLibre(int antiguedad, int descuentoPL, int precioPL) : base (fecha, socio)
        {
            this.antiguedad = antiguedad;
            this.descuentoPL = descuentoPL;
            this.precioPL = precioPL;
        }
        #endregion

        #region MetodosDeInstancia
        public override double CalcularCosto()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
