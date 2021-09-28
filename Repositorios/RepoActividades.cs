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
    class RepoActividades : IRepositorio<Actividad>
    {
        public bool Alta(Actividad obj)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Actividad BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Actividad obj)
        {
            throw new NotImplementedException();
        }

        public List<Actividad> TraerTodos()
        {
            throw new NotImplementedException();
        }

        //Fix me: Van aca los metodos del repo socios
        public bool existeNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public bool verificarCupo()
        {
            throw new NotImplementedException();
        }

        public bool aptoEdad(Socio socio)
        {
            throw new NotImplementedException();
        }
    }
}
