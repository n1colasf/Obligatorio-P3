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
    class RepoPagos : IRepositorio<FormaDePago>
    {
        public bool Alta(FormaDePago obj)
        {
            if (obj == null)
                return false;
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Alta_Pago";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cedulaSocio", obj.Socio.Cedula));
                    cmd.Parameters.Add(new SqlParameter("@fecha", obj.Fecha));
                    if (obj is Cuponera)
                    {
                        Cuponera cup = (Cuponera)obj;
                        cmd.Parameters.Add(new SqlParameter("@descuentoC", Cuponera.DescuentoC));
                        cmd.Parameters.Add(new SqlParameter("@cantActividadesC", cup.CantActividades));
                        cmd.Parameters.Add(new SqlParameter("@precioTotalC", cup.CalcularCosto()));
                    }
                    else if (obj is PaseLibre)
                    {
                        PaseLibre pas = (PaseLibre)obj;
                        cmd.Parameters.Add(new SqlParameter("@descuentoPL", PaseLibre.DescuentoPL));
                        cmd.Parameters.Add(new SqlParameter("@antiguedadPL", pas.Antiguedad));
                        cmd.Parameters.Add(new SqlParameter("@precioPL", pas.PrecioPL));//FALTA ESTO
                    }
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

        public FormaDePago BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(FormaDePago obj)
        {
            throw new NotImplementedException();
        }

        public List<FormaDePago> TraerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
