using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public class Conexion
	{
		private string stringConexion =
			@"Server=NICOLASFERNA298;Database=Obligatorio_P3;Integrated Security=True; MultipleActiveResultSets=true";
		public SqlConnection CrearConexion()
		{
			return new SqlConnection(stringConexion);
		}
		public bool AbrirConexion(IDbConnection cn)
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
		public bool CerrarConexion(IDbConnection cn)
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
