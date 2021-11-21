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
                SocioActividad sa = new SocioActividad { IdActividad = idActividad, CedulaSocio = obj.Cedula, Fecha = DateTime.Now.Date, HoraActividad = hora };
                db.SociosActividad.Add(sa);
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
    }
}
