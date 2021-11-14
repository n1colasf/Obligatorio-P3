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
            if (obj == null || !obj.ValidarEmail(obj.Email) || !obj.ValidarPassword(obj.Password))
                return false;

            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString()); //VER DE TRAER EL CONSTRING DE WEB.CONFIG
            try
            {
                string encryptedPassword = EncryptPassword(obj.Password);
                Funcionario f = new Funcionario { Email = obj.Email, Password = encryptedPassword };
                
                db.Funcionarios.Add(f);
                db.SaveChanges(); //ESTO VA ACÁ O EN EL FINALLY?
                return true;
            }
            catch (SqlException Ex)
            {
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }
        public Funcionario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
        public Funcionario BuscarPorEmail(string email)
        {
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Buscar_Funcionario";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@email", email));
                    con.Open();
                    SqlDataReader filas = cmd.ExecuteReader();
                    while (filas.Read())
                    {
                        Funcionario func = new Funcionario
                        {
                            Email = (string)filas["email"],
                            Password = (string)filas["password"]
                        };
                        return func;
                    }

                }
                return null;
            }
            catch (SqlException Ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool Modificacion(Funcionario obj)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> TraerTodos()
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
