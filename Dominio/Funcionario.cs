using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Funcionario
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool ValidarEmail(string email)
        {
            //IMPLEMENTAR
            return true;
        }
        public bool ValidarPassword(string password)
        {
            //IMPLEMENTAR
            return true;
        }
    }
}