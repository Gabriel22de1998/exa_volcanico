using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;

namespace UTN.Winform.Examen1.Laboratorio.Clases
{
    [DataContract]
    class PacienteJson
    {
        [DataMember]
        public string Nombre { set; get; }
        [DataMember]
        public string Apellidos { set; get; }
        [DataMember]
        public string FechaNacimiento { set; get; }
        [DataMember]
        public string ARN { set; get; }
        [DataMember]
        public string Sexo { set; get; }
        [DataMember]
        public string MatrixProteina { set; get; }
        [DataMember]
        public string IsEmbarazada { set; get; }
        [DataMember]
        public string PresionAlta { set; get; }
    }
}
