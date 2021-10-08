using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using Dominio;

namespace WCF_AltaSocioActividad
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioAltaSocioActividad" in both code and config file together.
    [ServiceContract]
    public interface IServicioAltaSocioActividad
    {
        [OperationContract]
        bool AnotarseAActividad(Socio socio, Actividad actividad);
    }
}
