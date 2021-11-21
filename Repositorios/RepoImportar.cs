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
    public class RepoImportar
    {
        public bool ImportarUsuarios()
        {
            bool retorno = false;
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileDirectory = Path.Combine(baseDirectory, "archivos", "Usuarios.txt");
            if (fileDirectory == "") return false;
            Stream stream = new FileStream(fileDirectory, FileMode.OpenOrCreate);

            using (StreamReader leerArchivo = new StreamReader(stream))
            {
                while (!leerArchivo.EndOfStream)
                {
                    string linea = leerArchivo.ReadLine();
                    string[] dato = linea.Split('|');

                    string email = dato[0];
                    string password = dato[1];

                    if(Funcionario.ValidarEmail(email) && Funcionario.ValidarPassword(password) && FachadaClub.BuscarFuncionario(email) == null)
                    {
                        try
                        {
                            string encriptedPassword = RepoFuncionarios.EncryptPassword(password);
                            Funcionario func = new Funcionario { Email = email, Password = encriptedPassword };
                            db.Funcionarios.Add(func);
                            db.SaveChanges();
                            retorno = true;
                        }
                        catch (Exception Ex)
                        {
                            return false;
                        }
                    }
                }
            }
            db.Dispose();
            return retorno;
        }
        public bool ImportarActividades()
        {
            bool retorno = false;
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileDirectory = Path.Combine(baseDirectory, "archivos", "Actividades.txt");
            if (fileDirectory == "") return false;
            Stream stream = new FileStream(fileDirectory, FileMode.OpenOrCreate);

            using (StreamReader leerArchivo = new StreamReader(stream))
            {
                while (!leerArchivo.EndOfStream)
                {
                    string linea = leerArchivo.ReadLine();
                    string[] dato = linea.Split('|');

                    string nombre = dato[0].ToUpper().Trim();
                    var isNumeric1 = int.TryParse(dato[1], out int n1);
                    var isNumeric2 = int.TryParse(dato[2], out int n2);
                    var isNumeric3 = int.TryParse(dato[3], out int n3);

                    int edadMin = (isNumeric1) ? n1 : 0;
                    int edadMax = (isNumeric2) ? n2 : 0;
                    int cupo = (isNumeric3) ? n3 : 0;

                    if (edadMin >= 3 && edadMax <= 90 && cupo > 0 && nombre != "" && !RepoActividades.ExisteNombre(nombre))
                    {
                        try
                        {
                            Actividad act = new Actividad { Nombre = nombre, EdadMin = edadMin, EdadMax = edadMax, Cupo = cupo};
                            db.Actividades.Add(act);
                            db.SaveChanges();
                            retorno = true;
                        }
                        catch (Exception Ex)
                        {
                            throw Ex;
                        }
                    }
                }
            }
            db.Dispose();
            return retorno;
        }
    }
}
