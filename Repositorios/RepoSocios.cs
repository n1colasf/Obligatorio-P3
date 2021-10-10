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

        public bool Baja(int cedula)
        {
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Baja_Socio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
                    cmd.Parameters.Add(new SqlParameter("@activo", false));
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

        public Socio BuscarPorId(int cedula)
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
                    cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
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
            if (obj == null || !obj.ValidarCedula(obj.Cedula) || !obj.ValidarNombre(obj.Nombre) || !obj.ValidarEdad(obj.FechaNac))
                return false;
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Modificar_Socio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cedula", obj.Cedula));
                    cmd.Parameters.Add(new SqlParameter("@nombre", obj.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@fechaNac", obj.FechaNac));
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

        public List<Socio> TraerTodos()
        {
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Listar_Socios";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    List<Socio> listaSocios = new List<Socio>();
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
                        listaSocios.Add(socio);
                    }
                    return listaSocios;
                }
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
