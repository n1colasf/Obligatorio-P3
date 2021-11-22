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
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            try
            {
                Actividad act = new Actividad { Nombre = obj.Nombre.ToUpper(), EdadMin = obj.EdadMin, EdadMax = obj.EdadMax, Cupo = obj.Cupo};
                db.Actividades.Add(act);
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
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            try
            {
                return db.Actividades.ToList();
            }
            catch (Exception Ex)
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static bool ExisteNombre(string nombre)
        {
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            bool retorno = false;
            try
            {
                Actividad act = db.Actividades.Where(a => a.Nombre == nombre).SingleOrDefault();
                if (act != null) retorno = true;
                return retorno;
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

        public bool VerificarCupo()
        {
            throw new NotImplementedException();
        }

        public bool AptoEdad(Socio socio)
        {
            throw new NotImplementedException();
        }

        public bool SocioInscriptoActividad(int idActividad, int cedula, int horaActividad)
        {
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            bool retorno = false;
            try
            {
                SocioActividad socAct = db.SociosActividad
                    .Where(sa => sa.IdActividad == idActividad)
                    .Where(sa => sa.CedulaSocio == cedula)
                    .Where(sa => sa.HoraActividad == horaActividad).SingleOrDefault();

                if (socAct != null) retorno = true;

                return retorno;
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
        public static List<Actividad> IngresosPorSocio(int idActividad, int cedula, DateTime fecha) //FALTA IMPLEMENTAR!!!!
        {
            List<Actividad> listaActividades = new List<Actividad>();
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Ingresos_Por_Socio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
                    cmd.Parameters.Add(new SqlParameter("@fecha", fecha.Date));
                    con.Open();
                    SqlDataReader filas = cmd.ExecuteReader();
                    while (filas.Read())
                    {
                        Actividad act = new Actividad
                        {
                            //FALTA IMPLEMENTAR
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
    }
}
