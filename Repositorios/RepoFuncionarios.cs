using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Repositorios
{
    class RepoFuncionarios : IRepositorio<Funcionario>
    {
        public bool Alta(Funcionario obj)
        {
            if (obj == null || !Funcionario.ValidarEmail(obj.Email) || !Funcionario.ValidarPassword(obj.Password))
                return false;

            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            try
            {
                string encryptedPassword = EncryptPassword(obj.Password);
                Funcionario f = new Funcionario { Email = obj.Email, Password = encryptedPassword };
                
                db.Funcionarios.Add(f);
                db.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        public bool Baja(int id) //NO SE IMPLEMENTA
        {
            throw new NotImplementedException();
        }
        public Funcionario BuscarPorId(int id) //NO SE IMPLEMENTA
        {
            throw new NotImplementedException();
        }
        public Funcionario BuscarPorEmail(string email)
        {
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            Funcionario funcionario = new Funcionario();
            try
            {
                funcionario = db.Funcionarios.Where(f => f.Email == email).SingleOrDefault();
                return funcionario;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                db.Dispose();
            }
        }
        public bool Modificacion(Funcionario obj) //NO SE IMPLEMENTA
        {
            throw new NotImplementedException();
        }
        public List<Funcionario> TraerTodos() //NO SE IMPLEMENTA
        {
            throw new NotImplementedException();
        }
        public static string EncryptPassword(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
