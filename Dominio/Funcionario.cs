using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Funcionario
    {
        #region Atributos
        private string email;
        private string password;
        #endregion

        #region Propiedades
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        #endregion

        #region Constructor
        public Funcionario(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
        #endregion
    }
}
