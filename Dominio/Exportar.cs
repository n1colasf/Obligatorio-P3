using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Dominio
{
	public class Exportar
	{
		public static string raiz = AppDomain.CurrentDomain.BaseDirectory;

		public static string ArchivoAGuardar(string tabla)
		{
			return tabla + ".csv";
		}
		public static string GetStoredProcedure(string tabla)
		{
			return "Exportar_" + tabla;
		}
	}
}
