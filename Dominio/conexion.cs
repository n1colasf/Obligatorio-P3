using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Dominio
{
	public class Conexion
	{
		//private string stringConexion = @"Server=NICOLASFERNA298;Database=Obligatorio_P3;Integrated Security=True; MultipleActiveResultSets=true";
		//private string stringConexion = @"Server=ACER-GON\SQLEXPRESS;Database=Club;Integrated Security=True; MultipleActiveResultSets=true";
		private string stringConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
		public string getConectionString()
        {
			return stringConexion;
        }
		public SqlConnection CrearConexion()
		{
			return new SqlConnection(stringConexion);
		}
		public bool AbrirConexion(SqlConnection cn)
		{

			if (cn == null)
				return false;
			if (cn.State != ConnectionState.Open)
			{
				cn.Open();
				return true;
			}
			return false;
		}
		public bool CerrarConexion(SqlConnection cn)
		{
			if (cn == null)
				return false;
			if (cn.State != ConnectionState.Closed)
			{
				cn.Close();
				cn.Dispose();
				return true;
			}
			return false;
		}
	}
}
