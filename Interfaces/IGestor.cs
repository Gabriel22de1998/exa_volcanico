using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Examen1.Laboratorio.Clases;

namespace appExamen1Laboratorio.Interfaces
{
    interface IGestor
    {
        void AddPaciente(Paciente oPasiente);
        String getXML();
    }
}
