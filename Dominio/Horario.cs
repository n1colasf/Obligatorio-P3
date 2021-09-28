using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Horario
    {
        #region Atributos
        private string dia;
        private string hora;
        #endregion

        #region Propiedades
        public string Dia
        {
            get { return dia; }
            set { dia = value; }
        }
        public string Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        #endregion

        #region Constructor
        public Horario(string dia, string hora)
        {
            this.dia = dia;
            this.hora = hora;
        }
        #endregion
    }
}
