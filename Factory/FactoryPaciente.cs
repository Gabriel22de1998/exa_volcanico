using appExamen1Laboratorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Examen1.Laboratorio.Clases;

namespace UTN.Winform.Examen1.Laboratorio.Factory
{
    class FactoryPaciente
    {
        public Paciente CreatePaciente(Sexo oSexo)
        {
            Paciente oPaciente = null;

            if (Sexo.Hombre == oSexo)
            {
                oPaciente = new Hombre();
            }
            else if (Sexo.Mujer==oSexo)
            {
                oPaciente = new Mujer();
            } 
            return oPaciente;
        }
    }
}
