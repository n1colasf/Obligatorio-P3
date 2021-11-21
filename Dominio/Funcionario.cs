using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public const string numeros = "0123456789";
        public const string minusculas = "abcdefghijklmnopqrstuvwxyz";
        public const string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static bool ValidarEmail(string email)
        {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            
        }
        public static bool ValidarPassword(string password)
        {
            bool retorno = false;
            if (password.Length >= 6 && TieneNumero(password) && TieneMayuscula(password) && TieneMinuscula(password)) 
                {
                retorno = true;
                }
            return retorno;
        } 

        private static bool TieneMinuscula(string password)
        {
            bool estado = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (minusculas.IndexOf(password[i], 0) != -1)
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }
        private static bool TieneMayuscula(string password)
        {
            {
                bool estado = false;

                for (int i = 0; i < password.Length; i++)
                {
                    if (mayusculas.IndexOf(password[i], 0) != -1)
                    {
                        estado = true;
                        break;
                    }
                }
                return estado;
            }
        }
        private static bool TieneNumero(string password)
        {
            bool estado = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (numeros.IndexOf(password[i], 0) != -1)
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }
    }
}