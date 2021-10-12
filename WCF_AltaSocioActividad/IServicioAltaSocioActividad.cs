using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using Dominio;
using Repositorios;

namespace WCF_AltaSocioActividad
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioAltaSocioActividad" in both code and config file together.
    [ServiceContract]
    public interface IServicioAltaSocioActividad
    {
        [OperationContract]
        bool AnotarseAActividad(DtoSocio dtoSocio, int idActividad, int hora);
        [OperationContract]
        IEnumerable<DtoActividad> ListarActividades(int cedula);
        IEnumerable<DtoHorarioActividad> ListarHorarios();
    }

    public class DtoSocio
    {
        [DataMember]
        public int Cedula { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public DateTime FechaNac { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public bool Activo { get; set; }
        [DataMember]
        public List<Actividad> Actividades { get; set; } //VER SI SE UTILIZA
    }
    public class DtoActividad : IComparable<DtoActividad>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int EdadMin { get; set; }
        [DataMember]
        public int EdadMax { get; set; }
        [DataMember]
        public int Cupo { get; set; }
        [DataMember]
        public List<DtoHorarioActividad> Horarios { get; set; }
        [DataMember]
        public List<DtoSocio> Participantes { get; set; }

        public int CompareTo(DtoActividad other)
        {
            int res;
            if (this.Nombre.CompareTo(other.Nombre) > 0)
            {
                res = 1;
            }
            else if (this.Nombre.CompareTo(other.Nombre) < 0)
            {
                res = -1;
            }
            else
            {
                res = 0;
            }
            return res;
        }
    }
    public class DtoHorarioActividad
    {
        [DataMember]
        public int IdActividad { get; set; }
        [DataMember]
        public int Dia { get; set; }
        [DataMember]
        public int Hora { get; set; }
    }
}
