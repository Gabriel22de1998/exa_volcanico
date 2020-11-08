using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Examen1.Laboratorio.Clases
{
    class Paciente
    {
        public Muestra _Muestra { get; set; }
        public String Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Nombre { get; set; }
        public String Sexo { get; set; }

        public override string ToString()
        {
            return Nombre+" "+Apellidos;
        }

    }
}
