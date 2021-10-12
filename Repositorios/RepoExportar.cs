using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Repositorios
{
    public class RepoExportar
    {
        public bool ExportarTabla(string tabla)
        {
			string archivoAGuardar = Exportar.ArchivoAGuardar(tabla);
			string raiz = Exportar.raiz;

            string storedProcedure = Exportar.GetStoredProcedure(tabla);
			Conexion manejadorConexion = new Conexion();
			SqlConnection con = manejadorConexion.CrearConexion();

			try
			{
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = storedProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader filas = cmd.ExecuteReader();
                    StreamWriter sw = new StreamWriter(Path.Combine(raiz, archivoAGuardar));


                    while (filas.Read())
                    {
                        if(tabla == "Actividades")
                        {
                            int id = (int)filas["id"];
                            string nombre = (string)filas["nombre"];
                            int edadMin = (int)filas["edadMin"];
                            int edadMax = (int)filas["edadMax"];
                            int cupo = (int)filas["cupo"];
                            sw.WriteLine($"{id}|{nombre}|{edadMin}|{edadMax}|{cupo},");
                        }
                        else if (tabla == "Funcionarios")
                        {
                            string email = (string)filas["email"];
                            sw.WriteLine($"{email},");
                        }
                        else if (tabla == "Horarios_Actividad")
                        {
                            int idActividad = (int)filas["idActividad"];
                            int dia = (int)filas["dia"];
                            int hora = (int)filas["hora"];
                            sw.WriteLine($"{idActividad}|{dia}|{hora},");
                        }
                        else if (tabla == "Pagos")
                        {
                            int id = (int)filas["id"];
                            int cedulaSocio = (int)filas["cedulaSocio"];
                            string fecha = filas["fecha"].ToString();
                            double descuentoPL = (double)filas["descuentoPL"];
                            int antiguedadPL = (int)filas["antiguedadPL"];
                            double precioPL = (double)filas["precioPL"];
                            double descuentoC = (double)filas["descuentoC"];
                            int cantActividadesC = (int)filas["cantActividadesC"];
                            double precioTotalC = (double)filas["precioTotalC"];
                            sw.WriteLine($"{id}|{cedulaSocio}|{fecha}|{descuentoPL}|{antiguedadPL}|{precioPL}|{descuentoC}|{cantActividadesC}|{precioTotalC},");
                        }
                        else if (tabla == "Socios")
                        {
                            int cedula = (int)filas["cedula"];
                            string nombre = (string)filas["nombre"];
                            string fechaNac = filas["fechaNac"].ToString();
                            string fechaIngreso = filas["fechaIngreso"].ToString();
                            bool activo = (bool)filas["activo"];
                            sw.WriteLine($"{cedula}|{nombre}|{fechaNac}|{fechaIngreso}|{activo},");
                        }
                        else if (tabla == "Socios_Actividad")
                        {
                            int idActividad = (int)filas["idActividad"];
                            int cedulaSocio = (int)filas["cedulaSocio"];
                            string fecha = filas["fecha"].ToString();
                            int horaActividad = (int)filas["horaActividad"];
                            sw.WriteLine($"{idActividad}|{cedulaSocio}|{fecha}|{horaActividad},");
                        }
                    }
                    filas.Close();
                    sw.Close();
                    return true;
                }
            }
			catch (IOException ex)
			{
				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
			finally
			{
				manejadorConexion.CerrarConexion(con);
			}
		}
    }
}
