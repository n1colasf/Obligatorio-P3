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
    public class RepoActividades : IRepositorio<Actividad>
    {
        public bool Alta(Actividad obj)
        {
            if (obj == null || ExisteNombre(obj.Nombre))
                return false;
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Alta_Actividad";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nombre", obj.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@edadMin", obj.EdadMin));
                    cmd.Parameters.Add(new SqlParameter("@edadMax", obj.EdadMax));
                    cmd.Parameters.Add(new SqlParameter("@cupo", obj.Cupo));
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

        public Actividad BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Actividad obj)
        {
            throw new NotImplementedException();
        }

        public List<Actividad> TraerTodos()
        {
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Listar_Actividades";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    List<Actividad> listaActividades = new List<Actividad>();
                    SqlDataReader filas = cmd.ExecuteReader();
                    while (filas.Read())
                    {
                        Actividad act = new Actividad
                        {
                            Id = (int)filas["id"],
                            Nombre = (string)filas["nombre"],
                            EdadMin = (int)filas["edadMin"],
                            EdadMax = (int)filas["edadMax"],
                            Cupo = (int)filas["cupo"]
                        };
                        listaActividades.Add(act);
                    }
                    return listaActividades;
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

        //Fix me: Van aca los metodos del repo socios
        public bool ExisteNombre(string nombre)
        {
            //IMPLEMENTAR PARA VALIDACION
            return false;
        }

        public bool VerificarCupo()
        {
            throw new NotImplementedException();
        }

        public bool AptoEdad(Socio socio)
        {
            throw new NotImplementedException();
        }
    }
}
