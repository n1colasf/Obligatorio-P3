using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;


namespace Repositorios
{
    class RepoSocios : IRepositorio<Socio>
    {
        public bool Alta(Socio obj)
        {

            if (obj == null || !obj.ValidarCedula(obj.Cedula) || !obj.ValidarNombre(obj.Nombre) || !obj.ValidarEdad(obj.FechaNac) || ExisteSocio(obj.Cedula))
            	return false;
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();

            try
            {
                using(SqlCommand cmd = new SqlCommand()){
                    cmd.Connection = con;
                    cmd.CommandText = "Alta_Socio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cedula", obj.Cedula));
                    cmd.Parameters.Add(new SqlParameter("@nombre", obj.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@fechaNac", obj.FechaNac));
                    cmd.Parameters.Add(new SqlParameter("@fechaIngreso", obj.FechaIngreso));
                    cmd.Parameters.Add(new SqlParameter("@activo", obj.Activo));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    
                }

				
				return true;
			}
			catch (SqlException Ex)
			{
                return false;
            }
            finally
			{
                con.Close();
            }
		}

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Socio BuscarPorId(int id)
        {
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Buscar_por_Cedula";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cedula", id));
                    con.Open();


                    SqlDataReader filas = cmd.ExecuteReader();
                    while (filas.Read())
                    {
                        Socio socio = new Socio
                        {
                            Cedula = (int)filas["cedula"],
                            Nombre = (string)filas["nombre"],
                            FechaNac = (DateTime)filas["fechaNac"],
                            FechaIngreso = (DateTime)filas["fechaIngreso"],
                            Activo = (bool)filas["activo"]
                        };
                        return socio;
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

        public bool Modificacion(Socio obj)
        {
            throw new NotImplementedException();
        }

        public List<Socio> TraerTodos()
        {
            throw new NotImplementedException();
        }
        public bool ExisteSocio(int cedula)
        {

            bool existe = false;
            if (BuscarPorId(cedula) != null)
            {
                existe = true;
            }
            return existe;
        }
    }
}
