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
        public Context(string conString) { 
            this.Database.Connection.ConnectionString = conString; 
        }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Socio> Socios { get; set; }
    }
}
