using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;

namespace Club
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime fechaNac = new DateTime(2011, 2, 19);
            Console.WriteLine(FachadaClub.AltaSocio(61115558, "Pedro Perez", fechaNac, DateTime.Now));
        }
    }
}
