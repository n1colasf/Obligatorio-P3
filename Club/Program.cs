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
            //ALTA SOCIO
            //DateTime fechaNac = new DateTime(2011, 2, 19);
            //Console.WriteLine(FachadaClub.AltaSocio(61115558, "Pedro Perez", fechaNac, DateTime.Now));

            //ALTA ACTIVIDAD
            //Console.WriteLine(FachadaClub.AltaActividad("Yoga", 4, 89, 20));

            //ALTA FUNCIONARIO
            //Console.WriteLine(FachadaClub.AltaFuncionario("funcionario1@club.com", "pass123"));

            //ALTA HORARIO
            Console.WriteLine(FachadaClub.AltaHorario("Lunes", 20));
            Console.WriteLine(FachadaClub.AltaHorario("Martes", 9));
            Console.WriteLine(FachadaClub.AltaHorario("Jueves", 2));

            //Registrar Pago
            Console.WriteLine(FachadaClub.RegistrarPago(45556667));
        }
    }
}
