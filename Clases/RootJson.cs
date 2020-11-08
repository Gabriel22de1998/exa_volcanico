using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Examen1.Laboratorio.Clases
{
    [DataContract]
    class RootJson
    {
        [DataMember]
        public List<PacienteJson> Lista{ get; set; }
    }
}
