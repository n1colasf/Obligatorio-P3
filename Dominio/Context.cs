using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dominio
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(string conString) { 
            this.Database.Connection.ConnectionString = conString; 
        }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<SocioActividad> SociosActividad { get; set; }
        public DbSet<Pago> Pagos { get; set; }

    }
}
