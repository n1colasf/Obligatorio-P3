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

            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            try
            {
                Socio s = new Socio { Cedula = obj.Cedula, Nombre = obj.Nombre, FechaNac = obj.FechaNac, FechaIngreso = obj.FechaIngreso, Activo = obj.Activo};

                db.Socios.Add(s);
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

        public bool Baja(int cedula)
        {
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            try
            {
                Socio socioAux = BuscarPorId(cedula);
                Socio socioDb = db.Socios.Find(socioAux.Id);
                socioDb.Activo = false;
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
        public Socio BuscarPorId(int cedula)
        {
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            Socio socio = new Socio();
            try
            {
                socio = db.Socios.Where(s => s.Cedula == cedula).Single();
                return socio;
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

        public bool Modificacion(Socio obj)
        {
            if (obj == null || !obj.ValidarCedula(obj.Cedula) || !obj.ValidarNombre(obj.Nombre) || !obj.ValidarEdad(obj.FechaNac))
                return false;
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            try
            {
                Socio socio = db.Socios.Find(obj.Id);
                socio.Nombre = obj.Nombre;
                socio.FechaNac = obj.FechaNac;
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
        public List<Socio> TraerTodos()
        {
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            try
            {
                return db.Socios.ToList();
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
        public bool ExisteSocio(int cedula)
        {
            bool existe = false;
            if (BuscarPorId(cedula) != null)
            {
                existe = true;
            }
            return existe;
        }
        public bool AltaSocioActividad(Socio obj, int idActividad, int hora)
        {
            if (obj == null)
                return false;

            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            try
            {
                //FALTAAAAA


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




            //Conexion manejadorConexion = new Conexion();
            //SqlConnection con = manejadorConexion.CrearConexion();
            //SqlTransaction trn = null;
            //try
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    if (manejadorConexion.AbrirConexion(con))
            //    {
            //        trn = con.BeginTransaction();

            //        cmd.Connection = con;
            //        cmd.CommandText = "Alta_Socio_Actividad";
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.Add(new SqlParameter("@idActividad", idActividad));
            //        cmd.Parameters.Add(new SqlParameter("@cedulaSocio", obj.Cedula));
            //        cmd.Parameters.Add(new SqlParameter("@fecha", DateTime.Now.Date));
            //        cmd.Parameters.Add(new SqlParameter("@horaActividad", hora));
            //        cmd.Transaction = trn;
            //        cmd.ExecuteNonQuery();

            //        SqlCommand cmd2 = new SqlCommand();
            //        cmd2.Connection = con;
            //        cmd2.CommandText = "Bajar_Cupo";
            //        cmd2.CommandType = CommandType.StoredProcedure;
            //        cmd2.Parameters.Add(new SqlParameter("@id", idActividad));
            //        cmd2.Transaction = trn;
            //        cmd2.ExecuteNonQuery();
            //        trn.Commit();
            //    }

            //    return true;
            //}
            //catch (SqlException Ex)
            //{
            //    return false;
            //}
            //finally
            //{
            //    con.Close();
            //}
        }
    }
}
