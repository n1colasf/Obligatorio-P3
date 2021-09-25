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
    class RepoPago : IRepositorio<FormaDePago>
    {
        public bool Alta(FormaDePago obj)
        {
            //asdasd
            throw new NotImplementedException();
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
