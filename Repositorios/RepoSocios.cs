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
			IDbConnection cn = manejadorConexion.CrearConexion();
            SqlTransaction trn = null;
            try
			{
				//código que quiero que se ejecute
				//preparar comando para guardar la fila del cliente
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				//indico que voy a ejecutar un procedimiento almacenado en la bd
				cmd.CommandText = "Alta_Socio";//indico el procedimiento
				cmd.Parameters.AddWithValue("@cedula", obj.Cedula);
				cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
				cmd.Parameters.AddWithValue("@fechaNac", obj.FechaNac);
				cmd.Parameters.AddWithValue("@fechaIngreso", obj.FechaIngreso);
				cmd.Parameters.AddWithValue("@activo", obj.Activo);
				manejadorConexion.AbrirConexion(cn);
				cmd.ExecuteNonQuery();

				
				return true;
			}
			catch (SqlException Ex)
			{
                trn.Rollback();
                return false;
            }
            finally
			{
				manejadorConexion.CerrarConexion(cn);
			}
		}

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Socio BuscarPorId(int id)
        {
            throw new NotImplementedException();
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
