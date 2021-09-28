using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Actividad
    {
        #region Atributos
        private int id;
        private static int contId;
        private string nombre;
        private int edadMin;
        private int edadMax;
        private int cupo;
        private List<Horario> horarios;
        private List<Socio> participantes;
        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int EdadMin
        {
            get { return edadMin; }
            set { edadMin = value; }
        }
        public int EdadMax
        {
            get { return edadMax; }
            set { edadMax = value; }
        }
        public int Cupo
        {
            get { return cupo; }
            set { cupo = value; }
        }
        public List<Horario> Horarios
        {
            get { return horarios; }
            set { horarios = value; }
        }
        public List<Socio> Participantes
        {
            get { return participantes; }
            set { participantes = value; }
        }
        #endregion

        #region Constructor
        public Actividad(string nombre, int edadMin, int edadMax, int cupo, List<Horario> horarios, List<Socio> participantes)
        {
            id = contId++;
            this.nombre = nombre;
            this.edadMin = edadMin;
            this.edadMax = edadMax;
            this.cupo = cupo;
            this.horarios = horarios;
            this.participantes = participantes;
        }
        #endregion
    }
}
