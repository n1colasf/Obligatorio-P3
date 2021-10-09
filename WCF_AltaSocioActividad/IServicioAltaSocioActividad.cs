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
        bool AnotarseAActividad(Socio socio, Actividad actividad);
        [OperationContract]
        IEnumerable<DtoActividad> ListarActividades();
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
    public class DtoActividad
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
        public List<Horario> Horarios { get; set; }
    }
}
