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

            if (obj == null || !obj.ValidarCedula(obj.Cedula) || !obj.ValidarNombre(obj.Nombre) || !obj.ValidarEdad(obj.FechaNac) || this.ExisteSocio(obj.Cedula))
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
            //IMPLEMENTAR (VALIDACION PARA ALTA DE SOCIO)
            return null;
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
