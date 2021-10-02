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
    class RepoHorarios : IRepositorio<Horario>
    {
        public bool Alta(Horario obj)
        {
            if (obj == null || !obj.ValidarHora(obj.Hora))
                return false;
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    int idActividad = 1;//new Actividad().Id;
                    //VER COMO PASAMOS EL ID DE LA ACTIVIDAD
                    cmd.Connection = con;
                    cmd.CommandText = "Alta_Horario";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idActividad", idActividad));
                    cmd.Parameters.Add(new SqlParameter("@hora", obj.Hora));
                    cmd.Parameters.Add(new SqlParameter("@dia", obj.Dia));
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

        public Horario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Horario obj)
        {
            throw new NotImplementedException();
        }

        public List<Horario> TraerTodos()
        {
            throw new NotImplementedException();
        }

    }
}
